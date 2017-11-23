import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core'; 
import {RouterModule} from '@angular/router';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {
  MatButtonModule, 
  MatCardModule,
  MatInputModule,
  MatSnackBarModule,
  MatFormFieldModule,
  MatToolbarModule
} from '@angular/material';
import { AppComponent } from './app.component';
import { MessagesComponent } from './messages.component';
import  { WebService } from './web.service';
import {HttpModule} from '@angular/http';
import {NewMessageComponent} from './new-message.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NavComponent} from './nav.component';
import {HomeComponent} from './home.component';
import {RegisterComponent} from './register.component';
import {AuthService} from './auth.service';
import {LoginComponent} from './login.component';
import {UserComponent} from './user.component';

var routes = [
{
    path: '',
    component: HomeComponent
},
{
    path: 'messages',
    component: MessagesComponent
},
{
    path: 'messages/:name',
    component: MessagesComponent
},
{
    path: 'register',
    component: RegisterComponent
},
{
    path: 'login',
    component: LoginComponent
}
,
{
    path: 'user',
    component: UserComponent
}
];


@NgModule({
  declarations: [
    AppComponent,
    MessagesComponent,
    NewMessageComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    UserComponent
  ],
  imports: [
    BrowserModule, 
    BrowserAnimationsModule, 
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatSnackBarModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    RouterModule.forRoot(routes)
    ],
  providers: [ WebService, AuthService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
