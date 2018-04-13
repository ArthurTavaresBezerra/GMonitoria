import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatFormField, MatSelect, MatOption } from '@angular/material';
import { LoginComponent } from './login/login.component';
import { MatInputModule } from '@angular/material/input';

import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
 
import { MDBBootstrapModule } from 'angular-bootstrap-md';
  
import { PageMainStudentComponent } from './page-main-student/page-main-student.component';

import {RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  {
    path: 'page',
    component: PageMainStudentComponent,
    data: { title: 'Heroes List' }
  },{
    path: 'heroes',
    component: PageMainStudentComponent,
    data: { title: 'Heroes List' }
  },
  { path: '',
    component: LoginComponent,
    pathMatch: 'full'
  },
  { path: '**', component: LoginComponent }
];

@NgModule({
  declarations: [ 
    AppComponent,
    LoginComponent,
    PageMainStudentComponent
  ],
  imports: [
    BrowserModule,

    RouterModule.forRoot(appRoutes,{ enableTracing: true }), // <-- debugging purposes only
    //Material Design
    BrowserAnimationsModule,NoopAnimationsModule,MatButtonModule,MatCheckboxModule,MatInputModule,
    //BootsTrap Js Actions
    BsDropdownModule.forRoot(),TooltipModule.forRoot(),ModalModule.forRoot(),MDBBootstrapModule.forRoot()


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
