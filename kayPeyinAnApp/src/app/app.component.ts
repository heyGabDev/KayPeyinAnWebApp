import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TopbarComponent } from './shared/topbar/topbar-component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet, 
    TopbarComponent
  ],
   template: `
    <app-topbar-component />
    <router-outlet></router-outlet>
  `,
})
export class AppComponent {}
