import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PhoneNumberTypeFormComponent } from './phone-number-type-form/phone-number-type-form.component';
import { PhoneNumberTypeListComponent } from './phone-number-type-list/phone-number-type-list.component';

const routes: Routes = [
  { path: '', component: PhoneNumberTypeListComponent },
  {
    path: 'new',
    component: PhoneNumberTypeFormComponent,
  },
  {
    path: 'edit/:id',
    component: PhoneNumberTypeFormComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PhoneNumberTypeRoutingModule {}
