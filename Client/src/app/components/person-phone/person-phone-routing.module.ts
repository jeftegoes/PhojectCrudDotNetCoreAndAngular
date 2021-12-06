import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonPhoneFormComponent } from './person-phone-form/person-phone-form.component';
import { PersonPhoneListComponent } from './person-phone-list/person-phone-list.component';

const routes: Routes = [
  { path: '', component: PersonPhoneListComponent },
  {
    path: 'new',
    component: PersonPhoneFormComponent,
  },
  {
    path: 'edit/:businessEntityID/:phoneNumber/:phoneNumberTypeID',
    component: PersonPhoneFormComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PersonPhoneRoutingModule {}
