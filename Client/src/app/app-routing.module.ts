import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  {
    path: 'person',
    loadChildren: () =>
      import('./components/person/person.module').then((m) => m.PersonModule),
  },
  {
    path: 'personPhone',
    loadChildren: () =>
      import('./components/person-phone/person-phone.module').then(
        (m) => m.PersonPhoneModule
      ),
  },
  {
    path: 'phoneNumberType',
    loadChildren: () =>
      import('./components/phone-number-type/phone-number-type.module').then(
        (m) => m.PhoneNumberTypeModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
