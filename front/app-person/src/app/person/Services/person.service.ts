import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable, tap } from 'rxjs';
import { Person } from 'src/app/model/Person';
import { PersonPhone } from 'src/app/model/PersonPhone';
import { ResponsePersonApi, ResponsePhoneTypeApi } from 'src/app/model/ResponseApi';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private apiUrl = "http://localhost:5000/api/";

  constructor(private http: HttpClient) { }

  GetAllPersonPhoneNumber(idPerson: number): PersonPhone[] {
    return [
      {
        "id": 1,
        "phoneNumber": "(19)99999-2883",
        "phoneNumberTypeId": 1,
        "phoneNumberTypeName": "Local phone"
      },
      {
        "id": 1,
        "phoneNumber": "(19)99999-4021",
        "phoneNumberTypeId": 2,
        "phoneNumberTypeName": "Cellphone"
      }
    ];
  }

  GetAllPerson(): Person[] {
    return [
      {
        "id": 1,
        "name": "Paulo"
      },
      {
        "id": 2,
        "name": "João"
      }
    ];
  }
/*
  GetAllPersonApi(): Observable<ResponseApi> {

    var getlocal = this.http.get<ResponseApi>("http://localhost:5000/api/Person").pipe(
       map((res: ResponseApi) => {
        console.log(res)
       }));

     getlocal.subscribe();

     return this.http.get<ResponseApi>(this.apiUrl +"Person");
  } */

  GetAllPersonApi(): Observable<ResponsePersonApi> {
    return this.http.get<ResponsePersonApi>(`${this.apiUrl}Person`);
   }

   GetAllPhoneNumberTypeApi():Observable<ResponsePhoneTypeApi> {
    return this.http.get<ResponsePhoneTypeApi>(`${this.apiUrl}Person/list-phone-number-type`);
   } 



   
}
