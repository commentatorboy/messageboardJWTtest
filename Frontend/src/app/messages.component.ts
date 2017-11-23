import { Component } from '@angular/core'
import { WebService } from './web.service';
import {ActivatedRoute } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
    selector: 'messages',
    template: `this is hte messgaes component 
    <div *ngFor="let message of webService.messages | async">
        <mat-card class="card">
            <mat-card-title [routerLink]="['/messages', message.owner]" style="cursor: pointer">{{message.owner}}</mat-card-title>
            <mat-card-content>{{message.text}} </mat-card-content>
        </mat-card>
    </div>
    `
})
//pipe takes in data and transforms it as desired output format money time, 
export class MessagesComponent{
    
    constructor(private webService : WebService, private route: ActivatedRoute) 
    {    }
            
    ngOnInit(){
        var name =this.route.snapshot.params.name;
        this.webService.getMessages(name);
        this.webService.getUser().subscribe(            
            // Successful responses call the first callback.
            data => {console.log("it works?")},
            // Errors will call this callback instead:
            (err: HttpErrorResponse) => {
                if (err.error instanceof Error) {
                  // A client-side or network error occurred. Handle it accordingly.
                  console.log('An error occurred:', err.error.message);
                } else {
                  // The backend returned an unsuccessful response code.
                  // The response body may contain clues as to what went wrong,
                  console.log(`Backend returned code ${err.status}, body was: ${err.error}`);
                  console.log(err);
                }
              }
          );
    }

  
}
