
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = 'https://yourapi.com/api/users'; // Replace with your API URL

  constructor(private http: HttpClient) {}

  getUserById(userId: string | null): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/${userId}`);
  }

  updateUserProfile(userId: string | null, profileData: any): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/${userId}`, profileData);
  }
}
