import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { PhoneNumberType } from 'src/app/models/phone-number-type';
import { PhoneNumberTypeService } from 'src/app/services/phone-number-type.service';

@Component({
  selector: 'app-PhoneNumberType-form',
  templateUrl: './phone-number-type-form.component.html',
})
export class PhoneNumberTypeFormComponent implements OnInit {
  phoneNumberTypeForm: FormGroup;
  phoneNumberType: PhoneNumberType;

  constructor(
    private fb: FormBuilder,
    private phoneNumberTypeService: PhoneNumberTypeService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.createForm();
    this.phoneNumberType = new PhoneNumberType();

    this.route.params.subscribe((p) => {
      this.phoneNumberType.phoneNumberTypeID = p['id'] || 0;
    });
  }

  ngOnInit() {
    if (this.phoneNumberType.phoneNumberTypeID != 0) {
      this.phoneNumberTypeService
        .getPhoneNumberType(this.phoneNumberType.phoneNumberTypeID)
        .subscribe((data) => {
          this.phoneNumberTypeForm.setValue(data);
        });
    } else {
    }
  }

  createForm() {
    this.phoneNumberTypeForm = this.fb.group({
      businessEntityID: [0],
      name: ['', Validators.required],
    });
  }

  headTitle() {
    return this.phoneNumberType.phoneNumberTypeID != 0 ? 'Edit phone number type' : 'New phone number type';
  }

  onCancel() {
    this.router.navigate(['/phoneNumberType']);
  }

  onSubmit() {
    const controls = this.phoneNumberTypeForm.controls;

    this.phoneNumberType.name = this.phoneNumberTypeForm.get('name').value;

    if (this.onValidate(this.phoneNumberType.name) === false) return;

    var result$ = this.phoneNumberType.phoneNumberTypeID
      ? this.phoneNumberTypeService.update(this.phoneNumberType)
      : this.phoneNumberTypeService.create(this.phoneNumberType);

    result$.subscribe(
      (data) => {
        alert('The phone number type created with success!');

        this.router.navigate(['/phoneNumberType']);
      },
      (error) => {
        alert('Error creating phone number type: ' + error);
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
