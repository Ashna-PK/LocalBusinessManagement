import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  shopId?: number;
  products: any[] = [];

  constructor(private route: ActivatedRoute, private http: HttpClient) {}
  

  ngOnInit(): void {
    this.initializeSeller();
  }
  
  initializeSeller(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('shopId');
      console.log(id);
      if (id) {
        
        this.getProducts(id);
      } else {
        console.error('ShopId not found in route parameters.');
      }
    });
  }
  increaseQuantity(product: any): void {
    if (product.quantity > 0) {
      // Ensure selectedQuantity is initialized
      if (!product.selectedQuantity) {
        product.selectedQuantity = 0;
      }
      product.selectedQuantity++; // Increment selected quantity
      product.quantity--; // Decrease available quantity
    }
  }
  
  decreaseQuantity(product: any): void {
    if (product.selectedQuantity > 0) {
      product.selectedQuantity--; // Decrement selected quantity
      product.quantity++; // Increase available quantity
    }
  }
  // bookProduct(product: any): void {
  //   if (product.selectedQuantity > 0) {
  //     // Display an alert message
  //     alert(`Your product '${product.name}' was booked successfully!`);
  //     product.selectedQuantity = 0; // Reset selected quantity
  //   } else {
  //     alert('Please select at least one quantity to book the product.');
  //   }
  // }
  
  bookProduct(product: any): void {
    if (product.selectedQuantity > 0) {
      const apiUrl = `https://localhost:7162/api/Product/${product.id}/${product.selectedQuantity}`;
  
      this.http.put(apiUrl, {}).subscribe({
        next: () => {
          alert(`Your ${product.selectedQuantity} '${product.name}' has been Booked successfully!`);
          product.selectedQuantity = 0; // Reset selected quantity
        },
        error: (err) => {
          console.error('Error booking product:', err);
          alert('An error occurred while booking the product. Please try again.');
        }
      });
    } else {
      alert('Please select at least one quantity to book the product.');
    }
  }
  
  
  getProducts(id:string): void {
    const apiUrl = `https://localhost:7162/api/Product/shop?shopId=${id}`;
    this.http.get<any>(apiUrl).subscribe({
      next: (res) => {
        console.log(res);
        this.products = res;
      },
      error: (err) => {
        console.error('Error fetching products:', err);
      }
    });
  }
}