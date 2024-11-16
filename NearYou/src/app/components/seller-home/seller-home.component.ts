import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-seller-home',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './seller-home.component.html',
  styleUrl: './seller-home.component.css'
})
export class SellerHomeComponent {
  products = [
    { name: 'Product 1', rating: 4, description: 'Description 1', price: 20, quantity: 100 },
    { name: 'Product 2', rating: 5, description: 'Description 2', price: 30, quantity: 50 }
  ];

  selectedProduct: any = null;
  isAddMode: boolean = false;

  openUpdateModal(index: number) {
    this.isAddMode = false;
    this.selectedProduct = { ...this.products[index], index };
  }

  openAddModal() {
    this.isAddMode = true;
    this.selectedProduct = { name: '', rating: null, description: '', price: null, quantity: null };
  }

  saveProduct() {
    if (this.isAddMode) {
      this.products.push(this.selectedProduct);
    } else {
      const index = this.selectedProduct.index;
      this.products[index] = { ...this.selectedProduct };
    }
    this.selectedProduct = null; // Close modal
  }

  deleteProduct(index: number) {
    this.products.splice(index, 1);
  }

  closeModal() {
    this.selectedProduct = null;
  }
  
}
