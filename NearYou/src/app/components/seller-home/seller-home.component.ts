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
  products: any[] = [];  // Store product data
  showAddProductModal: boolean = false;  // Control visibility of modal
  newProduct: { name: string; quantity: number } = { name: '', quantity: 0 };  // New product details

  constructor(private http: HttpClient) {}  // Inject HttpClient

  ngOnInit(): void {
    this.fetchProducts();  // Fetch products on component initialization
  }

  // Fetch products from the backend
  fetchProducts() {
    const url = 'http://localhost:5000/api/products';  // URL of your .NET backend API
    this.http.get<any[]>(url)  // HTTP GET request to backend
      .subscribe(data => {
        this.products = data;  // Store the fetched products in products array
      }, error => {
        console.error('Error fetching products', error);
      });
  }

  // Add a new product
  onSubmitNewProduct() {
    const url = 'http://localhost:5000/api/products';  // URL of your .NET backend API
    this.http.post(url, this.newProduct)  // HTTP POST request to backend to add new product
      .subscribe(() => {
        this.fetchProducts();  // Refresh the product list
        this.onCloseModal();  // Close the modal
      }, error => {
        console.error('Error adding product', error);
      });
  }

  // Update a product (Placeholder for actual logic)
  onUpdateProduct(product: any) {
    const url = `http://localhost:5000/api/products/${product.id}`;  // URL of your .NET backend API
    this.http.put(url, product)  // HTTP PUT request to backend to update product
      .subscribe(() => {
        this.fetchProducts();  // Refresh the product list
      }, error => {
        console.error('Error updating product', error);
      });
  }

  // Delete a product
  onDeleteProduct(id: number) {
    const url = `http://localhost:5000/api/products/${id}`;  // URL of your .NET backend API
    this.http.delete(url)  // HTTP DELETE request to backend to delete a product
      .subscribe(() => {
        this.fetchProducts();  // Refresh the product list
      }, error => {
        console.error('Error deleting product', error);
      });
  }

  // Open modal for adding a new product
  onAddProduct() {
    this.showAddProductModal = true;
  }

  // Close the modal
  onCloseModal() {
    this.showAddProductModal = false;
    this.newProduct = { name: '', quantity: 0 };  // Reset new product data
  }
}
