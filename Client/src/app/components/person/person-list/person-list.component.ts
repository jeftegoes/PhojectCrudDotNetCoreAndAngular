import { Component, OnInit, ViewChild } from '@angular/core';
import { Person } from '../../../models/person';
import { PersonService } from '../../../services/person.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html'
})
export class PersonListComponent implements OnInit {

	persons: Person[];

	constructor(private personService: PersonService) {
		
	}

	ngOnInit() {
		this.loadData();
	}

	loadData() {
		this.personService.getPersons().subscribe(result => {
			this.persons = result;
			console.log(this.persons);

		}, error => {
			alert(error);
		});
	}

	onDelete(person: Person) {
		this.personService.delete(person).subscribe(result => {
			alert("Pessoa excluída com sucesso!");
			this.loadData();
		}, error => {
			alert(error);
		});
	}
}
