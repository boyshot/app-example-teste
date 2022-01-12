import { Person } from "./Person";
import { PhoneType } from "./PhoneType";

export interface ResponsePersonApi {
   success : boolean;
   data : IDataPerson;    
 }

 export interface IDataPerson {
   personObjects: Person[];
   success : boolean;
   errors  : any;
 }

 export interface ResponsePhoneTypeApi {
  success : boolean;
  data : IDataPhonetype;    
}

export interface IDataPhonetype {
  phoneNumberTypeObjects: PhoneType[];
  success : boolean;
  errors  : any;
}

 


 