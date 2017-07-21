import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'login',
    templateUrl: 'app/Login/login.component.html',
    styleUrls:['app/Login/login.component.css']
      
})
export class LoginComponent implements OnInit {

    constructor() {
        console.log('HomeComponent -> constructor');

    }

    ngOnInit() {
        console.log('HomeComponent -> ngOnInit');

    }
}