import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BookComponent } from './book.component';
import { BookRoutingModule } from './book.routing.module';
import { BookInsertComponent } from './insert/book-insert.component';
import { BookUpdateComponent } from './update/book-update.component';
import {FormsModule} from '@angular/forms';
import {TableModule} from 'primeng/table';
import {MultiSelectModule} from 'primeng/multiselect';
import {ButtonModule} from 'primeng/button';
import {InputTextModule} from 'primeng/inputtext';
import {ConfirmDialogModule} from 'primeng/confirmdialog';




@NgModule({
  declarations: [BookComponent, BookInsertComponent, BookUpdateComponent],
  imports: [
    CommonModule,
    BookRoutingModule,
    FormsModule,
    TableModule,
    MultiSelectModule,
    ButtonModule,
    InputTextModule,
    ConfirmDialogModule,
  ]
})
export class BookModule { }
