import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookComponent } from './book.component';
import { BookInsertComponent } from './insert/book-insert.component';
import { BookUpdateComponent } from './update/book-update.component';
import { Book } from '../book';

const routes: Routes = [
  { 
    path: '',
    component:BookComponent,
  },
  { 
    path: 'add',
    component:BookInsertComponent,
  },
  { 
    path: 'update/:id',
    component:BookUpdateComponent,
  },
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [ RouterModule ]
})

export class BookRoutingModule { }