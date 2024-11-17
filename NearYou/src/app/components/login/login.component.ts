import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';


  
  onSubmit() {
    if (this.username && this.password) {
      alert(`Welcome, ${this.username}!`);
      // Add logic for authentication here
    } else {
      alert('Please fill in both fields.');
    }
  }
  
  constructor(private router: Router) {}

  RegisterSeller() {
    this.router.navigate(['/Seller_Register']);
  }
  RegisterUser(){
    this.router.navigate(['/User_Register']); 
  }

}
