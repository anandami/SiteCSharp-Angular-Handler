import { Injectable } from '@angular/core';
import { Book } from './book';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BookService {

  constructor(private http:HttpClient) { }
  
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      'Authorization': 'my-auth-token'
    })
  };

  public save(book:Book):Observable<Book>{
    console.log(book);
    return this.http.post<Book>(environment.host + "?method=post", book,this.httpOptions);
    
  }

  public listBook():Observable<Book[]>{
    return this.http.get<Book[]>(environment.host + "?method=getall");
  }

  public delete(id:number):Observable<any>{
    return this.http.delete(environment.host + "?method=delete&id=" + id);
  }

  public search(id:number):Observable<Book[]>{
    return this.http.get<Book[]>(environment.host + "?method=getbyid&id=" + id);
    
  }
  public update(id:number,book:Book):Observable<Book[]>{
    return this.http.put<Book[]>(environment.host + "?method=update&id=" + id, book,this.httpOptions);
    
  }
  public getBook(id):Observable<Book[]>{
    return this.http.get<Book[]>(`${environment.host}/${id}`);
  }
}
