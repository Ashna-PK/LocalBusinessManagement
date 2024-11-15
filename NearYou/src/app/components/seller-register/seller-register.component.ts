import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-seller-register',
  standalone: true,
  imports: [],
  templateUrl: './seller-register.component.html',
  styleUrl: './seller-register.component.css'
})
export class SellerRegisterComponent {

  constructor(private router: Router) {}

  goToLogin() {
    this.router.navigate(['/login']); // Adjust the path as needed
  }
}
