import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { CookieModule } from 'ngx-cookie';
import { Book } from './book';
import { BooksService } from './books.service';


describe('BooksService', () => {
  let service: BooksService;
  let httpTestingController: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        CookieModule.forRoot(),
        HttpClientTestingModule
      ],
      providers: [BooksService]
    });
    service = TestBed.inject(BooksService);
    httpTestingController = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('getBooks should call correct link', () => {
    const testBook: Book = { id: 1, name: "mockBook", language: "english", author: "me", pages: 10, borrowedBy: "" };
    service.getBooks()
      .subscribe(books => {
        expect(books[0].name).toEqual("mockBook");
      });

    const req = httpTestingController.expectOne('http://localhost:5000/book');

    expect(req.request.method).toEqual('GET');

    req.flush([testBook]);
  });
});
