import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/model/Person';
import { ResponsePersonApi } from 'src/app/model/ResponseApi';
import { PersonService } from '../Services/person.service';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  persons : Person[] = [];

  constructor(private personService: PersonService) { }

  ngOnInit(): void {

    this.persons = [];

    this.personService.GetAllPersonApi().subscribe(
      (res: ResponsePersonApi) => {
        res.data.personObjects.forEach(value => {
            this.persons.push(value);
          });}                
    );  
  }
}
