import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie';
import { BehaviorSubject } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  user: BehaviorSubject<User> = new BehaviorSubject<User>(null);

  constructor(private cookieService: CookieService, private http: HttpClient) {
    if (cookieService.hasKey('user-id')) {
      let user = JSON.parse(cookieService.get('user-id'));
      this.user.next(user);
    } else {
      http.post<User>('http://localhost:5000/book/create_user', '').subscribe(user => {
        this.user.next(user);
        cookieService.put('user-id', JSON.stringify(user));
      });
    }
  }
}
