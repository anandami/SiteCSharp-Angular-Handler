import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/book';
import { BookService } from 'src/app/book.service';

@Component({
  selector: 'app-book-insert',
  templateUrl: './book-insert.component.html',
  styleUrls: ['../book.component.css']
})
export class BookInsertComponent implements OnInit {

    public book:Book;

    constructor(private bookService:BookService) { }

  ngOnInit() {
    this.book = new Book();
    this.book.Id=0;
  }
  public save(){
    console.log(this.book);
    this.bookService.save(this.book).subscribe(
      response => {
        alert("Successfully saved!")
        console.log(this.book)
      },
      error =>{
        alert("There is something wrong :/")
        console.log(this.book)
      }
    )
     
  }

}
