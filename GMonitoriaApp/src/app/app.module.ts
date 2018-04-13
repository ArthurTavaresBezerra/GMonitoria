
import {CdkTableModule} from '@angular/cdk/table';
import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {BrowserModule} from '@angular/platform-browser';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'; 

/** Materal Angular */
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
} from '@angular/material';

@NgModule({
  exports: [
    CdkTableModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
  ]
})
export class MaterialModule {}

import { NoopAnimationsModule } from '@angular/platform-browser/animations';
/**ngx-bootStrap */
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({ exports: [BsDropdownModule, TooltipModule, ModalModule]})  export class NgxBootstrapModule {}
/** MdbBoots */
import { MDBBootstrapModule } from 'angular-bootstrap-md';
  

import {RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PageMainCollaboratorComponent } from './page-main-collaborator/page-main-collaborator.component';
import { PageMainStudentComponent } from './page-main-student/page-main-student.component';
import { LoginComponent } from './login/login.component';


const appRoutes: Routes = [
  { path: '',
    component: LoginComponent,
    pathMatch: 'full'
  },
  {
    path: 'page',
    component: PageMainStudentComponent,
    data: { title: 'Heroes List' }
  },{
    path: 'collaborator',
    component: PageMainCollaboratorComponent
  },
  { path: '**', component: LoginComponent }
];

@NgModule({
  declarations: [  
    AppComponent,
    LoginComponent,
    PageMainStudentComponent,
    PageMainCollaboratorComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    MaterialModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    NoopAnimationsModule,
    NgxBootstrapModule,
    RouterModule.forRoot(appRoutes,{ enableTracing: true }), // <-- debugging purposes only
    
    //BsDropdownModule.forRoot(),TooltipModule.forRoot(),ModalModule.forRoot(),MDBBootstrapModule.forRoot()


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
 
platformBrowserDynamic().bootstrapModule(AppModule);