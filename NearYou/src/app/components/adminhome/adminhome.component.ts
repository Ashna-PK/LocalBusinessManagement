import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../Services/auth.service';

@Component({
  selector: 'app-adminhome',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './adminhome.component.html',
  styleUrl: './adminhome.component.css'
})
export class AdminhomeComponent {
  records = [
    {
      name: 'Business 1',
      description: 'Description of Business 1',
      address: 'Address 1',
      createdAt: '2024-11-16',
      openTime: '09:00 AM',
      closeTime: '05:00 PM',
      verified: false,
      rating: null  // Initially no rating
    },
    {
      name: 'Business 2',
      description: 'Description of Business 2',
      address: 'Address 2',
      createdAt: '2024-11-15',
      openTime: '10:00 AM',
      closeTime: '06:00 PM',
      verified: false,
      rating: null  // Initially no rating
    }
    // More records here...
  ];

  deleteRecord(index: number): void {
    // Remove the record from the list
    this.records.splice(index, 1);
  }
  validateRating(record: any): void {
    if (record.rating > 5) {
      record.rating = 5; // Restrict the value to 5 if it exceeds
    } else if (record.rating < 1) {
      record.rating = 1; // Restrict the value to 1 if it is less
    }
  }
  

  verifyRecord(record: any): void {
    // Update the record's verified status and rating
    if (record.rating) {
      record.verified = true;  // Mark as verified
    }
  }



  dropdownOpen = false;

  constructor(private router: Router, public authService: AuthService) {}

  toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  goToProfile() {
    this.router.navigate(['/profile']);
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  goToUsers(){
    this.router.navigate(['/admin_user']);  
  }
}
