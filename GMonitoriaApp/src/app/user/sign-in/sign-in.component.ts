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
  xUsuario : string = "";
  msgError2 : string = ""; 

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
      this.LimparTodosDados();  
      if (this.isValidateMatricula == false)
      {
        this.userService.getMatricula(matricula).subscribe((data : any)=>{ 
          if (data.isExists)
          {
            this.xUsuario = data.nome;
            this.labelButtonLogin  = "Entrar";
            this.isValidateMatricula = true; 
            this.matricula = matricula;
          }
          else 
          {
            this.LimparTodosDados();
            this.isLoginError = true;
            this.msgError2 = "Matrícula não encontrada";
          }
          
        },
        (err : HttpErrorResponse)=>{
          this.LimparTodosDados();
          this.isLoginError = true;
          this.msgError2 = "Erro ao requisitar a matrícula; " + err.message;
        });
        }
      else
      {} 
  }
     
  OnSubmitPassword(password){ 
    if (this.isValidateMatricula)
    {
      this.userService.userAuthentication(this.matricula,password).subscribe((data : any)=>{
        if (data.authenticated)
        {
          localStorage.setItem('userToken',data.access_token);
          this.router.navigate(['/home']); 
        }
        else 
        {
          this.isLoginError = true;
          this.msgError2 = "Senha inválida";
        }
      },
      (err : HttpErrorResponse)=>{
        this.isLoginError = true;
        this.msgError2 = err.message;
      });
    } 
    else
    {
      this.MudarConta();
    }

  }

  MudarConta(){ 
    this.LimparTodosDados(); 
  }

  LimparAvisos(){
    this.msgError2 = "";
    this.isLoginError = false;
  }

  LimparTodosDados()
  {
    this.LimparAvisos();
    this.xUsuario = "";
    this.matricula = "";
    this.isValidateMatricula = false;
  }
} 
     
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
