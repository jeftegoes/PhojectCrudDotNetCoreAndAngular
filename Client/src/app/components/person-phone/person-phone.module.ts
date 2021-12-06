import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonPhoneRoutingModule } from './person-phone-routing.module';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PersonPhoneFormComponent } from './person-phone-form/person-phone-form.component';
import { PersonPhoneListComponent } from './person-phone-list/person-phone-list.component';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [PersonPhoneFormComponent, PersonPhoneListComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PersonPhoneRoutingModule,
    NgxMaskModule.forRoot(),
  ],
})
export class PersonPhoneModule {}
