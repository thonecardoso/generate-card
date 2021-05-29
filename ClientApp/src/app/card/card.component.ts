import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrls: ['./card.component.css']
})
export class CardComponent implements OnInit {



  constructor() { }

  ngOnInit() {
  }

}


export interface Card {
  id: number;
  number: string;
  validate: Date;
  securityCode: number;
  createdDate: Date;
}
