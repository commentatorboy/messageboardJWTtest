import { Component} from '@angular/core'
import {WebService} from './web.service';
import {AuthService} from './auth.service';

@Component({
    selector: 'new-message',
    template: `<mat-card class="card">
    <mat-card-content>
        <mat-input-container>
            <textarea  [(ngModel)]="message.text" matInput placeholder="Message"></textarea>
        </mat-input-container>
        <mat-card-actions>
            <button (click)="post()" mat-button color="primary">POST</button>
        </mat-card-actions>

    </mat-card-content>
    
    </mat-card>
    `
})

export class NewMessageComponent{
    
    constructor(private webSerice : WebService, private auth: AuthService) {
        
    }
    message = {
        owner: this.auth.name,
        text: ""
    }    
    post(){
        this.webSerice.postMessage(this.message);
    }
}
