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
  users: User[];
  userFormGroup: FormGroup;

  constructor(private fb: FormBuilder, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {



    this.userFormGroup = this.fb.group({
      name: ['', Validators.required],
      document: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
    console.log(this.userFormGroup);
  }

  ngOnInit() {
  }

  onSubmitting() {
    const userToPost: User = this.userFormGroup.value;
    this.http.post<User[]>(this.baseUrl + 'api/v1/User', userToPost).subscribe(result => {
      this.users = result;
    }, error => console.error(error));
    this.setFormGroup();
  }

  setFormGroup(): void {
    this.userFormGroup = this.fb.group({
      name: ['', Validators.required],
      document: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }


}

export interface User {
  name: string;
  document: string;
  email: string;
  cards: Card[];
}


