import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { 
    path: 'home',
    loadChildren:'./home/home.module#HomeModule'
  },
  { 
    path: 'book',
    loadChildren:'./book/book.module#BookModule'
  },
  { 
    path: '',
    pathMatch: 'full',
    redirectTo:'/home'
  },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes, {useHash:true})
  ],
  exports: [ RouterModule ]
})
export class AppRoutingModule { }
