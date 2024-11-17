import { CommonModule } from '@angular/common';
import { Component, TemplateRef, ViewChild } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-your-orders',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './your-orders.component.html',
  styleUrl: './your-orders.component.css',
  
})
export class YourOrdersComponent {
  role: 'user' | 'seller' = 'user'; // Change to 'seller' to see seller data
  orders: any[] = [];
  reviewText = '';
  rating: number | null = null; // Store the rating
  showReviewModal = false;
  selectedOrder: any = null;

  constructor() {
    this.loadOrders();
  }

  loadOrders() {
    if (this.role === 'user') {
      this.orders = [
        { shopName: 'Shop A', productName: 'Product 1', quantity: 2, totalPrice: 500 },
        { shopName: 'Shop B', productName: 'Product 2', quantity: 1, totalPrice: 250 }
      ];
    } else if (this.role === 'seller') {
      this.orders = [
        { username: 'User1', productName: 'Product 1', quantity: 2, totalPrice: 500, stars: 4 },
        { username: 'User2', productName: 'Product 2', quantity: 1, totalPrice: 250, stars: 5 }
      ];
    }
  }

  openReviewModal(order: any) {
    this.showReviewModal = true;
    this.selectedOrder = order;
    this.reviewText = '';
    this.rating = null; // Reset the rating
  }

  closeReviewModal() {
    this.showReviewModal = false;
    this.selectedOrder = null;
  }

  submitReview() {
    if (this.reviewText.trim() === '') {
      alert('Review text cannot be empty.');
      return;
    }
    if (!this.rating) {
      alert('Please select a rating.');
      return;
    }

    console.log('Review Submitted for:', this.selectedOrder, 'with text:', this.reviewText, 'and rating:', this.rating);
    this.closeReviewModal();
  }
}
