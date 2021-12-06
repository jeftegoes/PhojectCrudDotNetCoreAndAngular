import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { Person } from 'src/app/models/person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-person-form',
  templateUrl: './person-form.component.html',
})
export class PersonFormComponent implements OnInit {
  personForm: FormGroup;
  person: Person;

  constructor(
    private fb: FormBuilder,
    private personService: PersonService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.createForm();
    this.person = new Person();

    this.route.params.subscribe((p) => {
      this.person.businessEntityID = p['id'] || 0;
    });
  }

  ngOnInit() {
    if (this.person.businessEntityID != 0) {
      this.personService
        .getPerson(this.person.businessEntityID)
        .subscribe((data) => {
          this.personForm.setValue(data);
        });
    } else {
    }
  }

  createForm() {
    this.personForm = this.fb.group({
      businessEntityID: [0],
      name: ['', Validators.required],
    });
  }

  headTitle() {
    return this.person.businessEntityID != 0 ? 'Edit person' : 'New person';
  }

  onCancel() {
    this.router.navigate(['/person']);
  }

  onSubmit() {
    const controls = this.personForm.controls;

    this.person.name = this.personForm.get('name').value;

    if (this.onValidate(this.person.name) === false) return;

    var result$ = this.person.businessEntityID
      ? this.personService.update(this.person)
      : this.personService.create(this.person);

    result$.subscribe(
      (data) => {
        alert('The person created with success!');

        this.router.navigate(['/person']);
      },
      (error) => {
        alert('Error creating person: ' + error);
      }
    );
  }

  onValidate(name: string): boolean {
    var isValid: boolean = true;
    var field: string = '';

    if (name === null || name.trim() === '') {
      field = 'name';
      isValid = false;
    }

    if (isValid === false) {
      alert('Field ' + field + ' is required!');
      return false;
    }

    return true;
  }
}
