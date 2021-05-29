import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UserComponent } from './user/user.component';
import { CardComponent } from './card/card.component';
import { ListUserComponent } from './list-user/list-user.component';
import { GenerateCardComponent } from './generate-card/generate-card.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UserComponent,
    CardComponent,
    ListUserComponent,
    GenerateCardComponent
  ],
    imports: [
        BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            {path: '', component: HomeComponent, pathMatch: 'full'},
            {path: 'registerUser', component: UserComponent},
            {path: 'generate-card/:email', component: GenerateCardComponent},
            {path: 'generate-card', component: GenerateCardComponent},
        ]),
        ReactiveFormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
