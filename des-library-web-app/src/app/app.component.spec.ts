import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { MatMenuModule } from '@angular/material/menu';
import { Router } from '@angular/router';
import { RouterTestingModule } from '@angular/router/testing';
import { routes } from './app-routing.module';
import { AppComponent } from './app.component';
import { BooksComponent } from './books/books.component';
import { BooksService } from './books/books.service';
import { HomeComponent } from './home/home.component';

describe('AppComponent', () => {

  let router: Router;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        RouterTestingModule.withRoutes(routes),
        HttpClientTestingModule,
        MatMenuModule,
      ],
      declarations: [
        AppComponent,
        HomeComponent,
        BooksComponent
      ],
      providers: [BooksService]
    }).compileComponents();

    router = TestBed.inject(Router);
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it("navigate to '' redirects you to /home", fakeAsync(() => {
    router.navigate(['']);
    tick();
    expect(router.url).toBe('/home');
  }));
});
