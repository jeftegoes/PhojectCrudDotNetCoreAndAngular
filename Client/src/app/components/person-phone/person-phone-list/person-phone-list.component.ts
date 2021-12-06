import { Component, OnInit, ViewChild } from '@angular/core';
import { PersonPhone } from '../../../models/person-phone';
import { PersonPhoneService } from '../../../services/person-phone.service';

@Component({
  selector: 'app-person-phone-list',
  templateUrl: './person-phone-list.component.html',
})
export class PersonPhoneListComponent implements OnInit {
  personPhones: PersonPhone[];

  constructor(private personPhoneService: PersonPhoneService) {}

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.personPhoneService.getPersonPhones().subscribe(
      (result) => {
        this.personPhones = result;
        console.log(this.personPhones);
      },
      (error) => {
        alert(error);
      }
    );
  }

  onDelete(personPhone: PersonPhone) {
    this.personPhoneService.delete(personPhone).subscribe(
      (result) => {
        alert('Person deleted with success!');
        this.loadData();
      },
      (error) => {
        alert(error);
      }
    );
  }
}
