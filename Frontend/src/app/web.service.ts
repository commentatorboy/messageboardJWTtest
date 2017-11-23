import {Http } from '@angular/http';
import {Injectable} from '@angular/core';
import 'rxjs/add/operator/toPromise';
import { Subject} from  'rxjs/Rx';
import {MatSnackBar} from '@angular/material';
import {AuthService} from './auth.service';

@Injectable()
export class WebService{
    private messagesStore = [];
    
    private messageSubject = new Subject();

    public messages = this.messageSubject.asObservable();

    //from https://material.angular.io/components/snack-bar/examples
    constructor(private http: Http, public snackBar: MatSnackBar, private auth: AuthService){
        
        this.getMessages('');
    }
    BASE_URL = 'http://localhost:49952/api'; 
    MESSAGE_SUBURL = '/messages';


    getMessages(user) {
        user = (user) ? '/' + user : '';
        this.http.get(this.BASE_URL + this.MESSAGE_SUBURL + user).subscribe(response => {
            this.messagesStore = response.json();
            this.messageSubject.next(this.messagesStore);
        }, error => {
            this.handleError("Unable to get messages");
        });
    }

    async postMessage(message){
        //trycatches works only on async functions
        try {
            
            var response = await this.http.post(this.BASE_URL + this.MESSAGE_SUBURL, message).toPromise();
            this.messagesStore.push(response.json());
            this.messageSubject.next(this.messagesStore);
        } catch (error) {
            this.handleError("unable to post message");
            
        }
    }

    private handleError(error)
    {
        
        console.error(error);
        this.snackBar.open(error, 'close', {duration: 2000});
    }

    getUser(){
        console.log(this.auth.tokenHeader);
        var result = this.http.get(this.BASE_URL + '/users/me', this.auth.tokenHeader )
            .map(res => res.json()
        );
        return result;
        
    }
    saveUser(userData){
        return this.http.post(this.BASE_URL + '/users/me', userData, this.auth.tokenHeader ).map(res => res.json());
    }
}