import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PersonRoutingModule } from './person-routing.module';
import { PersonFormComponent } from './person-form/person-form.component';
import { PersonListComponent } from './person-list/person-list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PersonFormComponent,
    PersonListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    PersonRoutingModule
  ]
})
export class PersonModule { }
