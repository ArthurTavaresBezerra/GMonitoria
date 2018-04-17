import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../../shared/user.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
 
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import {FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';
import {ErrorStateMatcher} from '@angular/material/core';

import { DialogGeral } from '../../shared/dialogs/dialog-geral';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  isLoginError : boolean = false;
  isValidateMatricula : boolean = false;
  labelButtonLogin : string = "Continuar";
  matricula : string = "";
  msgMatricula : string = "";
  msgSenha : string = "";

  emailFormControl = new FormControl('', [
    Validators.required,
    Validators.email,
  ]);

  matcher = new MyErrorStateMatcher();
  
  constructor(private userService : UserService,private router : Router, public dialog: MatDialog) { }
 
  openDialog(str): void {
    let dialogRef = this.dialog.open(DialogGeral, { width: '250px', data: { v1: str  } });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      //this.result = result;
    });
  } 

  ngOnInit() { 
  }

  OnSubmitMatricula(matricula){ 
  
    console.log('m:'+matricula); 
    if (this.isValidateMatricula == false)
    {
      this.userService.isMatriculaExists(matricula).subscribe((data : any)=>{ 
        if (data)
        {
          this.labelButtonLogin  = "Entrar";
          this.isValidateMatricula = true; 
          this.matricula = matricula;
        }
        else 
        {
          this.matricula = null;
          this.isLoginError = true;
          this.msgMatricula = "Matrícula não encontrada";
        }
        
      },
      (err : HttpErrorResponse)=>{
        this.isLoginError = true;
        this.msgMatricula = "Matrícula não encontrada";
      });
      }
    else
    {}

}
     
  OnSubmitPassword(password){ 
 

    console.log('p:'+password); 
    if (this.isValidateMatricula)
    {
      this.userService.userAuthentication(this.matricula,password).subscribe((data : any)=>{
        localStorage.setItem('userToken',data.access_token);
        this.router.navigate(['/home']); 
      },
      (err : HttpErrorResponse)=>{
        this.isLoginError = true;
      });
    } 
    else
    {   }

  }
} 
     
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
