import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

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
    },
    {
      name: 'Business 2',
      description: 'Description of Business 2',
      address: 'Address 2',
      createdAt: '2024-11-15',
      openTime: '10:00 AM',
      closeTime: '06:00 PM',
    },
    // Add more records here
  ];

  verifyRecord(index: number): void {
    // Implement your verify logic here
    console.log('Verifying record at index', index);
  }

  deleteRecord(index: number): void {
    // Remove the record from the list
    this.records.splice(index, 1);
  }

}
