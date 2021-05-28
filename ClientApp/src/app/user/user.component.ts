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

  changeRegisterList = false;
  currentUser: User;
  users: User[];
  userFormGroup: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
    http.get<User[]>(baseUrl + 'api/v1/User/all').subscribe(result => {
      this.users = result;
      console.log(this.users);
    }, error => console.error('Erro getAllUsers: ' + error));


    this.userFormGroup = this.fb.group({
      name: ['', Validators.required],
      document: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
    console.log(this.userFormGroup);
  }

  ngOnInit() {
  }

  setChangeRegisterList(): void {
    this.changeRegisterList = !this.changeRegisterList;
  }

  setCurrentUser(user: User): void {
    this.currentUser = user;
  }

  onSubmitting() {
    const userToPost: User = this.userFormGroup.value;
    this.http.post<User[]>(this.baseUrl + 'api/v1/User', userToPost).subscribe(result => {
      this.users = result;
    }, error => console.error(error));
    this.setChangeRegisterList();
    this.setFormGroup();
  }

  setFormGroup(): void {
    this.userFormGroup = this.fb.group({
      name: ['', Validators.required],
      document: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  generateCard(email: string) {
    this.http.post<User>(this.baseUrl + 'api/v1/Card',  { email } ).subscribe(result => {
      // this.currentUser = result;
      console.log(result);
    }, error => console.error(error));
  }
}

interface User {
  name: string;
  document: string;
  email: string;
  cards: Card[];
}


