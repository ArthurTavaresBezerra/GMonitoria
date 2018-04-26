import { ProcessoSeletivoService } from './processoSeletivo.service';
import { ProcessoSeletivoModel } from './model/processoSeletivoModel';



import {CdkTableModule} from '@angular/cdk/table';
import {A11yModule} from '@angular/cdk/a11y';
import {HttpClientModule} from '@angular/common/http';
import {NgModule, Component, Inject} from '@angular/core'; 
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';

import {BrowserModule} from '@angular/platform-browser';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'; 

import { UserService } from './shared/user.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { UserComponent } from './user/user.component';
import { SignInComponent } from './user/sign-in/sign-in.component';
import { HomeComponent } from './home/home.component';
import { SignUpComponent } from './user/sign-up/sign-up.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthInterceptor } from './auth/auth.interceptor'; 
import { DialogGeral } from './shared/dialogs/dialog-geral';


/** Materal Angular */
import {
  MatAutocompleteModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  /*Dialog*/ 
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
    A11yModule,
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
/** MdbBootstap */
import { MDBBootstrapModule } from 'angular-bootstrap-md';
  
//Routes
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';

import { AppComponent } from './app.component';
import { PageMainCollaboratorComponent } from './page-main-collaborator/page-main-collaborator.component';
import { PageMainStudentComponent } from './page-main-student/page-main-student.component';
import { PageMainProcessoSeletivoComponent } from './page-main-processo-seletivo/page-main-processo-seletivo.component'; 
 
@NgModule({
  declarations: [  
    AppComponent,
    SignInComponent,
    SignUpComponent,
    UserComponent,
    HomeComponent, 
    PageMainStudentComponent, 
    PageMainCollaboratorComponent,
    PageMainProcessoSeletivoComponent,
    DialogGeral
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
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes,{ enableTracing: true }) // <-- debugging purposes only 
    //BsDropdownModule.forRoot(),TooltipModule.forRoot(),ModalModule.forRoot(),MDBBootstrapModule.forRoot()
  ],
  entryComponents: [
    DialogGeral
  ],
  providers: [
    UserService, 
    AuthGuard,
    ProcessoSeletivoService,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
 
platformBrowserDynamic().bootstrapModule(AppModule);
 