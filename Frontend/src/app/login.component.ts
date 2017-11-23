import { Component } from '@angular/core'
import { AuthService} from './auth.service';
@Component({
    selector: 'login',
    template: `
    <mat-card>
        <mat-input-container>
            <input matInput  [(ngModel)]="loginData.email" placeholder="email" type="email"> 
        </mat-input-container>
        <mat-input-container>
            <input matInput [(ngModel)]="loginData.password" placeholder="password" type="password"> 
        </mat-input-container>
    <button mat-raised-button color="primary" (click)="login()">Login</button>
    </mat-card>
    
    `
})

export class LoginComponent{
    constructor(private auth: AuthService) {
        
    }
    loginData ={
        email: "",
        password: ""
    }

    login(loginData)
    {
        this.auth.login(this.loginData);        
    }
  
} 
 