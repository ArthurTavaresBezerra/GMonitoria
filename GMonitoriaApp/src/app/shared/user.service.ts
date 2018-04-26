import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { User } from './user.model';

@Injectable()
export class UserService {
  readonly rootUrl = 'http://localhost:5000';
  //readonly rootUrl = 'http://1e847382.ngrok.io';
  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    const body: User = {
      UserName: user.UserName, 
      Password: user.Password,
      Email: user.Email,
      FirstName: user.FirstName,
      LastName: user.LastName
    }
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.post(this.rootUrl + '/api/User/Register', body,{headers : reqHeader});
  }

  getMatricula(matricula) {
    var data =  this.rootUrl + '/api/Auth/getMatricula/' + "?UserID=" + matricula; 
    var reqHeader = new HttpHeaders({'No-Auth':'True'});
    return this.http.get(data, { headers: reqHeader });
  }
  
  userAuthentication(userName, password) {
    var data = { userID : userName, accessKey : password}
    //var data = '{userID="' + userName + '"&accessKey="' + password + '"}'; //"&grant_type=password";
    var reqHeader = new HttpHeaders({ 'Content-Type': 'application/json;','No-Auth':'True' });  
    return this.http.post(this.rootUrl + '/api/Auth/', data, { headers: reqHeader });
  }

  getUserClaims(){
   return  this.http.get(this.rootUrl+'/api/Auth/GetUserClaims');
  }

}
