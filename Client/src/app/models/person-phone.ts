import { Person } from "./person";
import { PhoneNumberType } from "./phone-number-type";

export class PersonPhone {
  public businessEntityID: number;
  public phoneNumber: string;
  public phoneNumberTypeID: number;
  public phoneNumberType: PhoneNumberType;
  public person: Person;
}
