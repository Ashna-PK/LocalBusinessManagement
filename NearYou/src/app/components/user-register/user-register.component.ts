import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-user-register',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './user-register.component.html',
  styleUrl: './user-register.component.css'
})
export class UserRegisterComponent {
  name: string = '';
  email: string = '';
  address: string = '';
  phoneNumber: string = '';

  onRegister() {
    if (this.name && this.email && this.address && this.phoneNumber) {
      alert(`Registration Successful!\nWelcome, ${this.name}!`);
      // Add logic to handle registration (e.g., API call) here
    } else {
      alert('Please fill in all the fields.');
    }
  }
}
