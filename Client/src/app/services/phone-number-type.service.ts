import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PhoneNumberType } from '../models/phone-number-type';

@Injectable({
  providedIn: 'root'
})
export class PhoneNumberTypeService {

  private readonly phoneNumberTypeEndpoint = environment.urlWebApi + 'Api/PhoneNumberType/';

  constructor(private http: HttpClient) {}

  getPhoneNumberTypes() {
    return this.http.get<PhoneNumberType[]>(this.phoneNumberTypeEndpoint).pipe(
      map((responseApi: any) => {
        return responseApi.data.phoneNumberTypeObjects as PhoneNumberType[];
      })
    );
  }

  getPhoneNumberType(id: number) {
    return this.http.get<PhoneNumberType>(this.phoneNumberTypeEndpoint + id).pipe(
      map((responseApi: any) => {
        return responseApi.data as PhoneNumberType;
      })
    );
  }

  create(phoneNumberType: PhoneNumberType) {
    return this.http.post(this.phoneNumberTypeEndpoint, phoneNumberType);
  }

  update(phoneNumberType: PhoneNumberType) {
    return this.http.put(this.phoneNumberTypeEndpoint + phoneNumberType.phoneNumberTypeID, phoneNumberType);
  }

  delete(phoneNumberType: PhoneNumberType) {
    return this.http.delete(this.phoneNumberTypeEndpoint + phoneNumberType.phoneNumberTypeID);
  }
}
