import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators,  ReactiveFormsModule } from '@angular/forms';

import { Router } from '@angular/router';

@Component({
  selector: 'app-seller-register',
  standalone: true,
  imports: [CommonModule,
    ReactiveFormsModule ],
  templateUrl: './seller-register.component.html',
  styleUrl: './seller-register.component.css'
})
export class SellerRegisterComponent {

  shopForm: FormGroup;

  constructor(private fb: FormBuilder,private router: Router) {
    this.shopForm = this.fb.group({
      shopName: ['', Validators.required],
      shopDescription: ['', Validators.required],
      openingTime: ['', Validators.required],
      closingTime: ['', Validators.required],
      shopAddress: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', [Validators.required, Validators.pattern(/^\d{10}$/)]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.shopForm.valid) {
      const formData = this.shopForm.value;
      console.log('Form Submitted Successfully:', formData);
      // Implement further logic, e.g., sending data to the server.
    } else {
      console.log('Form is invalid');
    }
  }

  goToLogin() {
    this.router.navigate(['/login']); // Adjust the path as needed
  }
}
