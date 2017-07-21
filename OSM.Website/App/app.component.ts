import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app',
    template: `
        <div class="container">
            <nav>
                <a routerLink="home" routerLinkActive="active">Home</a>
                <a routerLink="login" routerLinkActive="active">Login</a>
            </nav>
            <router-outlet></router-outlet>
        </div>
    `,
    providers: []
})
export class AppComponent implements OnInit {

    constructor() {
        console.log('AppComponent -> constructor');
    }

    ngOnInit() {
        console.log('AppComponent -> ngOnInit');
    }
}