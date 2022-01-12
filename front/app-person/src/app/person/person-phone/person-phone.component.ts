import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { map } from 'rxjs';
import { PhoneType } from 'src/app/model/PhoneType';
import { ResponsePhoneTypeApi } from 'src/app/model/ResponseApi';
//import { ResponseApi } from 'src/app/model/ResponseApi';
import { PersonService } from '../Services/person.service';

@Component({
  selector: 'person-phone',
  templateUrl: './person-phone.component.html',
  styleUrls: ['./person-phone.component.css']
})
export class PersonPhoneComponent implements OnInit {

  phoneTypes: PhoneType[] = [];
  phoneNumberForm!: FormGroup;

  constructor(private personService: PersonService, private fb: FormBuilder) { }

  ngOnInit(): void {

   this.phoneNumberForm = this.fb.group({
    PhoneNumber: '',
    PhoneType: '',
    Id: '',
    IdPhoneType: ''
    });

    this.personService.GetAllPhoneNumberTypeApi().subscribe(
      (res: ResponsePhoneTypeApi) => {
        res.data.phoneNumberTypeObjects.forEach(value => {
            this.phoneTypes.push(value);
          });}                
    );  
  }  

  InsertPhoneNumber(){
    if(this.phoneNumberForm.valid){     



    }
  }
}
