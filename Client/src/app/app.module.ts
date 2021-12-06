import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
//
import { NavbarComponent } from './core/navbar/navbar.component';
import { SidebarComponent } from './core/sidebar/sidebar.component';
//
import { PersonService } from './services/person.service';
import { PersonPhoneService } from './services/person-phone.service';
import { PhoneNumberTypeService } from './services/phone-number-type.service';
import { NgxMaskModule } from 'ngx-mask';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    SidebarComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
  ],
  providers: [PersonService, PersonPhoneService, PhoneNumberTypeService],
  bootstrap: [AppComponent],
})
export class AppModule {}
