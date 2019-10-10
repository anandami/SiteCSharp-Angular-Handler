import { Component, OnInit } from '@angular/core';
import { Book } from '../book';
import { BookService } from '../book.service';
import { ConfirmationService } from 'primeng/components/common/confirmationservice';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css'],
  providers:[ConfirmationService]
})
export class BookComponent implements OnInit {

  public book:Book = new Book()
  
  public books:Book[]

  constructor(private bookService:BookService, private confirmationService:ConfirmationService,private activatedRoute: ActivatedRoute ) { }

  ngOnInit() {
    this.listBook()
  }

  public listBook(){
    this.bookService.listBook().subscribe(
      response => {
        this.books = response
      }, 
      error => {
        alert("There is something wrong :/")
      }
    )
  }
  public delete(id:number){

    this.confirmationService.confirm({
      message: 'Are you sure that you want to delete this?',
      accept: () => {
        this.bookService.delete(id).subscribe(
          r => {
            console.log(this.listBook);
            this.listBook();
            
          }
        )
      }
    });
  }
  public search(id:number){
    this.bookService.search(id).subscribe(
      r => {
        alert("Busca feita com sucesso")
        this.books = r;
      }, 
      error => {
        alert("There is something wrong :/")
    });
  }
}