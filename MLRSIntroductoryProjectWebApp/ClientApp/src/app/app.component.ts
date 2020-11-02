import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <a class="navbar-brand" href="#">LRS Introductory project</a>
      <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li style="padding-left:5%;padding-top:4%"><a [routerLink]="['/home']">Home</a></li>
          <li style="padding-left:5%;padding-top:4%"><a [routerLink]="['/users']">Users</a></li>
          <li style="padding-left:5%;padding-top:4%"><a [routerLink]="['/map']">Map</a></li>
        </ul>
      </div>
    </nav>
    <div class='container'>
      <router-outlet></router-outlet>
    </div>
  `,
  styleUrls: ['./app.component.css'
  ]
})
export class AppComponent {
  title = '';

}
