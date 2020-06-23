import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

constructor(private http: HttpClient) { }

login(model: any){
  return this.http.post('http://localhost:5000/api/auth/login', model)
    .pipe(
      map((response: any) =>{
        const authToken = response;
        if(authToken){
          localStorage.setItem('token', authToken.token);
        }
      })
    );
}

register(model: any){
  return this.http.post('http://localhost:5000/api/auth/register', model);
}

}
