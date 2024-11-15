import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { HomeComponent } from './components/home/home.component';
import { BakeriesComponent } from './components/bakeries/bakeries.component';
import { ProductListComponent } from './components/product-list/product-list.component';

export const routes: Routes = [
{path: 'login', component:LoginComponent},
{path: 'profile', component:ProfileComponent},
{path:'home', component:HomeComponent},
{path:'', redirectTo:'home',pathMatch:'full'},
{path:'bakeries', component:BakeriesComponent},
{ path: 'product_list/:sellerId', component: ProductListComponent },

];
