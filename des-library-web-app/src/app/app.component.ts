import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Book } from './books/book';
import { BooksService } from './books/books.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  books: Observable<Book[]>;
  title: string = 'front-end';

  constructor(private booksService: BooksService) {
  }

  ngOnInit(): void {
    this.books = this.booksService.getBooks();
  }
}
