import {Component, OnInit} from '@angular/core';
import {BooksService} from './books/books.service';
import {Book} from './books/book';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  books: Observable<Book[]>;

  constructor(private booksService: BooksService) {
  }

  ngOnInit(): void {
    this.books = this.booksService.getBooks();
  }
}
