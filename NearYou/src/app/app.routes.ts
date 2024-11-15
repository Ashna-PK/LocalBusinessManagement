import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { BakeriesComponent } from './components/bakeries/bakeries.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { SellerRegisterComponent } from './components/seller-register/seller-register.component';
import { UserRegisterComponent } from './components/user-register/user-register.component';
import { SellerHomeComponent } from './components/seller-home/seller-home.component';


export const routes: Routes = [
{path: 'login', component:LoginComponent},
{path: 'profile', component:ProfileComponent},
{path:'home', component:HomeComponent},
{path:'', redirectTo:'home',pathMatch:'full'},
{path:'bakeries', component:BakeriesComponent},
{ path: 'product_list/:shopId', component: ProductListComponent },
{path:'Seller_Register', component: SellerRegisterComponent},
{path:'User_Register', component: UserRegisterComponent},
{path:'Seller_home',component: SellerHomeComponent}


];
