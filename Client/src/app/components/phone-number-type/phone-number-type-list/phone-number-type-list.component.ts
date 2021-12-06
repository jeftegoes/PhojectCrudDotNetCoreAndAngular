import { Component, OnInit, ViewChild } from '@angular/core';
import { PhoneNumberType } from '../../../models/phone-number-type';
import { PhoneNumberTypeService } from '../../../services/phone-number-type.service';

@Component({
  selector: 'app-PhoneNumberType-list',
  templateUrl: './phone-number-type-list.component.html'
})
export class PhoneNumberTypeListComponent implements OnInit {

	phoneNumberTypes: PhoneNumberType[];

	constructor(private phoneNumberTypeService: PhoneNumberTypeService) {
		
	}

	ngOnInit() {
		this.loadData();
	}

	loadData() {
		this.phoneNumberTypeService.getPhoneNumberTypes().subscribe(result => {
			this.phoneNumberTypes = result;
			console.log(this.phoneNumberTypes);

		}, error => {
			alert(error);
		});
	}

	onDelete(phoneNumberType: PhoneNumberType) {
		this.phoneNumberTypeService.delete(phoneNumberType).subscribe(result => {
			alert("Phone number type deleted with success!");
			this.loadData();
		}, error => {
			alert(error);
		});
	}
}
