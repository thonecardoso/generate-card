import {Component, Inject, OnInit} from '@angular/core';
import {User} from '../user/user.component';
import {ActivatedRoute} from '@angular/router';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-generate-card',
  templateUrl: './generate-card.component.html',
  styleUrls: ['./generate-card.component.css']
})
export class GenerateCardComponent implements OnInit {

  user: User;
  email: string;

  constructor(private route: ActivatedRoute, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit() {
    this.route.params.subscribe(
      (object: any) => {
        this.email = object.email;
      },
      err => {
        console.log(`erro: ${err}`);
      }
    );
    this.http.get<User>(this.baseUrl + `api/v1/User/${this.email}` ).subscribe(result => {
      this.user = result;
      console.log(result);
    }, error => console.error(error));
  }

  loadUser(value: string) {
    this.http.get<User>(this.baseUrl + `api/v1/User/${value}` ).subscribe(result => {
      this.user = result;
    }, error => console.error(error));
  }

  generateCard(email: string) {
    console.log(email);
    this.http.post<User>(this.baseUrl + `api/v1/Card?email=${email}`,  '' ).subscribe(result => {
      const user: User = result;
      this.user.cards.push(user.cards[0]);
    }, error => console.error(error));
  }

  delete(id: number, index: number) {
    this.http.delete(this.baseUrl + `api/v1/Card?id=${id}` ).subscribe(result => {
      this.user.cards.splice(index, 1);
      console.log(result);
    }, error => console.error(error));
  }
}



