import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BakeryService {
private apiUrl= "https://localhost:7162/api/shop";
  constructor(private http:HttpClient) { }
  getShop(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);}
}
