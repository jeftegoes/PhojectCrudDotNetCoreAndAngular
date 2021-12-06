import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PhoneNumberTypeListComponent } from './phone-number-type-list/phone-number-type-list.component';
import { PhoneNumberTypeFormComponent } from './phone-number-type-form/phone-number-type-form.component';
import { PhoneNumberTypeRoutingModule } from './phone-number-type-routing.module';


@NgModule({
  declarations: [
    PhoneNumberTypeFormComponent,
    PhoneNumberTypeListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PhoneNumberTypeRoutingModule
  ]
})
export class PhoneNumberTypeModule { }
