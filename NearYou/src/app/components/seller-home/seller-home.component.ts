import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-seller-home',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './seller-home.component.html',
  styleUrl: './seller-home.component.css'
})
export class SellerHomeComponent {
  products = [
    { name: 'Product 1', rating: 4, description: 'Description 1', price: 20, quantity: 100 },
    { name: 'Product 2', rating: 5, description: 'Description 2', price: 30, quantity: 50 }
  ];

  openUpdateModal(index: number) {
    // Open modal with current product details
    const product = this.products[index];
    // You can create a modal form and pre-fill the data
    // Example: this.selectedProduct = { ...product };
    // Show modal for the update form
  }

  updateProductDetails(index: number, updatedProduct: any) {
    this.products[index] = updatedProduct;
    // Close the modal after updating
  }
  deleteProduct(index: number) {
    this.products.splice(index, 1);
  }
  
}
