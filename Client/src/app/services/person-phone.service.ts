import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PersonPhoneDto } from '../dto/person-phone-dto';
import { PersonPhone } from '../models/person-phone';

@Injectable({
  providedIn: 'root',
})
export class PersonPhoneService {
  private readonly personPhoneEndpoint = environment.urlWebApi + 'Api/PersonPhone/';

  constructor(private http: HttpClient) {}

  getPersonPhones() {
    return this.http.get<PersonPhone[]>(this.personPhoneEndpoint).pipe(
      map((responseApi: any) => {
        return responseApi.data.personPhoneObjects as PersonPhone[];
      })
    );
  }

  getPersonPhone(businessEntityID: number, phoneNumber: string, phoneNumberTypeID: number) {
    return this.http.get<PersonPhone>(this.personPhoneEndpoint + businessEntityID + "/" + phoneNumber + "/" + phoneNumberTypeID).pipe(
      map((responseApi: any) => {
        return responseApi.data as PersonPhone;
      })
    );
  }

  create(personPhone: PersonPhone) {
    return this.http.post(this.personPhoneEndpoint, personPhone);
  }

  update(personPhoneDto: PersonPhoneDto) {
    return this.http.put(this.personPhoneEndpoint, personPhoneDto);
  }

  delete(personPhone: PersonPhone) {
    return this.http.delete(this.personPhoneEndpoint, { body: personPhone });
  }
}
