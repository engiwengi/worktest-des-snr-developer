import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { User } from '../user/user';
import { UserService } from '../user/user.service';
import { Book } from './book';
import { BooksService } from './books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {
  booksSubject: BehaviorSubject<Book[]> = new BehaviorSubject<Book[]>([]);
  books: Observable<Book[]>;
  user: User;
  emptyGuid = '00000000-0000-0000-0000-000000000000';
  constructor(private booksService: BooksService, private userService: UserService) { }

  ngOnInit(): void {
    this.books = this.booksSubject.asObservable();
    this.booksService.getBooks().subscribe(books => this.booksSubject.next(books));
    this.userService.user.subscribe(user => this.user = user);
  }

  borrowedByOther(book: Book): boolean {
    return book.borrowedBy != this.user.id && book.borrowedBy != this.emptyGuid;
  }

  borrowedByUser(book: Book): boolean {
    return book.borrowedBy == this.user.id;
  }

  textContent(book: Book): string {
    if (book.borrowedBy == this.user.id) {
      return 'Return';
    } else if (book.borrowedBy != this.emptyGuid) {
      return 'Borrowed';
    } else {
      return 'Borrow';
    }
  }

  buttonColor(book: Book): ThemePalette {
    if (book.borrowedBy != this.user.id) {
      return 'primary';
    } else {
      return 'accent';
    }
  }

  borrow(book: Book) {
    if (this.borrowedByUser(book)) {
      this.booksService.returnBook(book.id, this.user).subscribe(_ => this.booksService.getBooks().subscribe(books => this.booksSubject.next(books)));
    } else {
      this.booksService.borrowBook(book.id, this.user).subscribe(_ => this.booksService.getBooks().subscribe(books => this.booksSubject.next(books)));
    }
  }
}
