import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [],
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  sellerId?: number;
  products: any[] = [];

  constructor(private route: ActivatedRoute, private http: HttpClient) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('sellerId');
      if (id) {
        this.sellerId = +id;
        this.getProducts();
      } else {
        console.error('Seller ID not found in route parameters.');
      }
    });
  }

  getProducts(): void {
    const apiUrl = `https://localhost:7162/api/Product/shop?shopId=${this.sellerId}`;
    this.http.get<any[]>(apiUrl).subscribe({
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