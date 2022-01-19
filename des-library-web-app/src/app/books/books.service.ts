import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../user/user';
import { Book } from './book';

@Injectable()
export class BooksService {
  httpParams = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>('http://localhost:5000/book');
  }

  returnBook(id: number, userId: User): Observable<Object> {
    let url = 'http://localhost:5000/book/return/' + id;
    return this.http.put(url, JSON.stringify(userId), this.httpParams);
  }

  borrowBook(id: number, userId: User): Observable<Object> {
    let url = 'http://localhost:5000/book/borrow/' + id;
    return this.http.put(url, JSON.stringify(userId), this.httpParams);
  }
}
