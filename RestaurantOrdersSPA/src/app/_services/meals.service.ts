import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MealsService {

constructor(private http: HttpClient) { }

GetAllMeals(){
  return this.http.get('http://localhost:5000/api/restaurant/meals');
}

}
