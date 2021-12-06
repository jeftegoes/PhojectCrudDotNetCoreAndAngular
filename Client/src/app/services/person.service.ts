import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from '../models/person';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class PersonService {
  private readonly personEndpoint = environment.urlWebApi + 'Api/Person/';

  constructor(private http: HttpClient) {}

  getPersons() {
    return this.http.get<Person[]>(this.personEndpoint).pipe(
      map((responseApi: any) => {
        return responseApi.data.personObjects as Person[];
      })
    );
  }

  getPerson(id: number) {
    return this.http.get<Person>(this.personEndpoint + id).pipe(
      map((responseApi: any) => {
        return responseApi.data as Person;
      })
    );
  }

  create(person: Person) {
    return this.http.post(this.personEndpoint, person);
  }

  update(person: Person) {
    return this.http.put(this.personEndpoint + person.businessEntityID, person);
  }

  delete(person: Person) {
    return this.http.delete(this.personEndpoint + person.businessEntityID);
  }
}
