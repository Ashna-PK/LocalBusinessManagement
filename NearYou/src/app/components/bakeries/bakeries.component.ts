import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bakeries',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bakeries.component.html',
  styleUrl: './bakeries.component.css'
})
export class BakeriesComponent implements OnInit{
  
  bakeries:any[]=[];
  http= inject(HttpClient);
  
  ngOnInit(): void {

    this.getShops()
  
   }
   constructor(private router: Router) {}

   goToProducts(shopId: number) {
    this.router.navigate(['/product_list', shopId]);
  }
  
  goToOrders()
  {
    this.router.navigate(['/your_orders']);
  }
   getShops(){
  
    this.http.get("https://localhost:7162/api/shop").subscribe((res:any)=>{
  
     console.log(res)
  
     if (res) {
  
      this.bakeries =res
  
     }
  
    })
  
   }
  

}

