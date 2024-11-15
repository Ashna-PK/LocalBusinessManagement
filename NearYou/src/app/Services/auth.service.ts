import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;  // This variable tracks the login status

  constructor() {}

  // This method simulates logging in
  login() {
    this.isLoggedIn = true;
    // You could add more logic here, like storing a token
  }

  // This method simulates logging out
  logout() {
    this.isLoggedIn = false;
    // Clear any stored data if necessary
  }
  
}
