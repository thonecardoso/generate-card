import {Component, Inject, OnInit} from '@angular/core';
import {Card} from '../card/card.component';
import {HttpClient} from '@angular/common/http';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  changeRegisterList: boolean = false;
  currentUser: User;
  users: User[];
  userFormGroup: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    http.get<User[]>(baseUrl + 'api/v1/User/all').subscribe(result => {
      this.users = result;
      this.currentUser = this.users[0];
    }, error => console.error(error));

    this.setFormGroup();
    this.router.navigate(['/']);
  }

  ngOnInit() {
  }

  setChangeRegisterList(): void {
    this.changeRegisterList = !this.changeRegisterList;
  }

  setCurrentUser(user: User): void {
    this.currentUser = user;
    console.log(user);
  }

  onSubmitting() {
    const userToPost: User = this.userFormGroup.value;
    this.http.post<User[]>(this.baseUrl + 'api/v1/User', userToPost).subscribe(result => {
      this.users = result;
      this.currentUser = this.users[0];
    }, error => console.error(error));
    this.setChangeRegisterList();
    this.setFormGroup();
  }

  setFormGroup(): void {
    this.userFormGroup = this.fb.group({
      id: new FormControl(0),
      name: ['', Validators.required],
      document: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  generateCard(email: string) {
    // this.http.post<User>(this.baseUrl + 'api/v1/Card?email=' + email, '').subscribe(result => {
    this.http.post<User>(this.baseUrl + 'api/v1/Card',  { email } ).subscribe(result => {
      // this.currentUser = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface User {
  id: number;
  name: string;
  document: string;
  email: string;
  cards: Card[];
}


