import {Component, Inject, OnInit} from '@angular/core';
import {User} from '../user/user.component';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-list-user',
  templateUrl: './list-user.component.html',
  styleUrls: ['./list-user.component.css']
})
export class ListUserComponent implements OnInit {

  users: User[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    http.get<User[]>(baseUrl + 'api/v1/User/all').subscribe(result => {
      this.users = result;
      console.log(this.users);
    }, error => console.error('Erro getAllUsers: ' + error));
  }

  ngOnInit() {
  }

  delete(email: string, index: number) {
    this.http.delete(this.baseUrl + `api/v1/User/${email}`).subscribe(result => {
      console.log(result);
      this.users.splice(index, 1);
    }, error => console.error('Erro getAllUsers: ' + error));
  }
}
