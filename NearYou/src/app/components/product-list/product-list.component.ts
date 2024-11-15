import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule],
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
        this.shopId = +id;
        this.getProducts();
      } else {
        console.error('ShopId not found in route parameters.');
      }
    });
  }

  getProducts(): void {
    const apiUrl = `https://localhost:7162/api/Product/shop?shopId=${this.shopId}`;
    // const apiUrl = `https://localhost:7162/api/Product/shop?shopId=2`;
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