import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/book';
import { BookService } from 'src/app/book.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-book-update',
  templateUrl: './book-update.component.html',
  styleUrls: ['../book.component.css']
})
export class BookUpdateComponent implements OnInit {

  public book:Book = new Book()
  public books:Book[]
 
  constructor(private bookService:BookService, private route: ActivatedRoute) {
  }


  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      console.log(params.get('id'))
      this.book.Id = parseInt(params.get('id'));
    })
    this.listabook(this.book.Id);
  }
  public update(id:number){
    this.bookService.update(id,this.book).subscribe(
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
  public listabook(id:number){
    this.bookService.search(id).subscribe(
      r => {
        this.book=r[0];
        console.log(this.book);
      });
  }
}
