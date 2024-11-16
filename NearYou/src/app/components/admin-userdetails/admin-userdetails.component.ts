import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-admin-userdetails',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './admin-userdetails.component.html',
  styleUrl: './admin-userdetails.component.css'
})
export class AdminUserdetailsComponent {
  hoveredRow: number | null = null;


  users = [
    { name: 'John Doe', address: '123 Elm Street, Springfield', phone: '123-456-7890', email: 'john.doe@example.com' },
    { name: 'Jane Smith', address: '456 Oak Avenue, Shelbyville', phone: '234-567-8901', email: 'jane.smith@example.com' },
    { name: 'Alice Johnson', address: '789 Maple Lane, Capital City', phone: '345-678-9012', email: 'alice.johnson@example.com' },
    { name: 'Bob Brown', address: '321 Pine Street, Ogdenville', phone: '456-789-0123', email: 'bob.brown@example.com' },
    { name: 'Charlie White', address: '654 Cedar Road, North Haverbrook', phone: '567-890-1234', email: 'charlie.white@example.com' },
  ];

  deleteUser(index: number) {
    this.users.splice(index, 1);
  }
}
