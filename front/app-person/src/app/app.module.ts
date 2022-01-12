import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HttpClientModule } from '@angular/common/http';
import { PersonPhoneComponent } from './person/person-phone/person-phone.component';
import { PersonComponent } from './person/person/person.component';
import { ListPersonPhoneComponent } from './person/list-person-phone/list-person-phone.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonPhoneComponent,
    PersonComponent,
    ListPersonPhoneComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
