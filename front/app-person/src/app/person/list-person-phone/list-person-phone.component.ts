import { Component, OnInit } from '@angular/core';
import { PersonPhone } from 'src/app/model/PersonPhone';
import { PersonService } from '../Services/person.service';

@Component({
  selector: 'list-person-phone',
  templateUrl: './list-person-phone.component.html',
  styleUrls: ['./list-person-phone.component.css']
})
export class ListPersonPhoneComponent implements OnInit {

  public phoneNumbers: PersonPhone[] = [];

  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.phoneNumbers = this.personService.GetAllPersonPhoneNumber(1);
  }
}
