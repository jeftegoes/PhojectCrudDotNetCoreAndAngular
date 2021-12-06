import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { PersonPhoneDto } from 'src/app/dto/person-phone-dto';
import { Person } from 'src/app/models/person';

import { PersonPhone } from 'src/app/models/person-phone';
import { PhoneNumberType } from 'src/app/models/phone-number-type';
import { PersonPhoneService } from 'src/app/services/person-phone.service';
import { PersonService } from 'src/app/services/person.service';
import { PhoneNumberTypeService } from 'src/app/services/phone-number-type.service';

@Component({
  selector: 'app-person-phone-form',
  templateUrl: './person-phone-form.component.html',
})
export class PersonPhoneFormComponent implements OnInit {
  personPhoneForm: FormGroup;
  personPhone: PersonPhone;
  personPhoneOld: PersonPhone;
  personPhoneDto: PersonPhoneDto;
  phoneNumberTypes: PhoneNumberType[];
  persons: Person[];
  typeCrud: string;

  constructor(
    private fb: FormBuilder,
    private personPhoneService: PersonPhoneService,
    private phoneNumberTypeService: PhoneNumberTypeService,
    private personService: PersonService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.createForm();
    this.personPhone = new PersonPhone();

    this.route.params.subscribe((p) => {
      if (p['businessEntityID'])
      {
        this.personPhone.businessEntityID = p['businessEntityID'];
        this.personPhone.phoneNumber = p['phoneNumber'];
        this.personPhone.phoneNumberTypeID = p['phoneNumberTypeID'];

        this.personPhoneOld = new PersonPhone();
        this.personPhoneOld = Object.assign({}, this.personPhone);

        this.personPhoneDto = new PersonPhoneDto();

        this.typeCrud = "Edit";
      } else {
        this.personPhone.businessEntityID = 0;
        this.typeCrud = "New";
      }
    });
  }

  ngOnInit() {
    this.phoneNumberTypeService.getPhoneNumberTypes().subscribe(phoneNumberTypes => {
      this.phoneNumberTypes = phoneNumberTypes;

      this.personService.getPersons().subscribe(persons => {
        this.persons = persons;
        
        if (this.personPhone.businessEntityID != 0) {
          this.personPhoneService
            .getPersonPhone(this.personPhone.businessEntityID, 
              this.personPhone.phoneNumber,
              this.personPhone.phoneNumberTypeID)
            .subscribe((data) => {
              this.personPhoneForm.setValue(data);
            });
        } else {
          //
        }
        
      });
    });
  }

  createForm() {
    this.personPhoneForm = this.fb.group({
      businessEntityID: [0],
      phoneNumber: ['', Validators.required],
      phoneNumberTypeID: ['', Validators.required],
    });
  }

  headTitle() {
    return this.personPhone.businessEntityID != 0 ? 'Edit person phone' : 'New person phone';
  }

  onCancel() {
    this.router.navigate(['personPhone']);
  }

  onSubmit() {
    const controls = this.personPhoneForm.controls;

    this.personPhone.businessEntityID = this.personPhoneForm.get('businessEntityID').value;
    this.personPhone.phoneNumber = this.personPhoneForm.get('phoneNumber').value;
    this.personPhone.phoneNumberTypeID = this.personPhoneForm.get('phoneNumberTypeID').value;

    if (this.onValidate(this.personPhone.phoneNumber) === false)
      return;

    var result$ = new Observable<Object>();
    
    if (this.typeCrud == "Edit")
    {
      this.personPhoneDto.personPhoneDtoOld = this.personPhoneOld;
      this.personPhoneDto.personPhoneDtoNew = this.personPhone;

      result$ = this.personPhoneService.update(this.personPhoneDto)
    } else {
      result$ = this.personPhoneService.create(this.personPhone);
    }

    result$.subscribe(
      (data) => {
        alert('The person phone created with success!');

        this.router.navigate(['/personPhone']);
      },
      (error) => {
        alert('Error creating person phone: ' + error);
      }
    );
  }

  onValidate(phone: string): boolean {
    var isValid: boolean = true;
    var field: string = '';

    if (phone === null || phone.trim() === '') {
      field = 'phone';
      isValid = false;
    }

    if (isValid === false) {
      alert('Field ' + field + ' is required!');
      return false;
    }

    return true;
  }
}
