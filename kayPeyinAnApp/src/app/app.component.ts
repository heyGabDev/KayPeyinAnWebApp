import { Component, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatBadgeModule } from '@angular/material/badge';
import { AsyncPipe } from '@angular/common';
import { CartService } from './services/cart/cart.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatBadgeModule,
    AsyncPipe,
  ],
  template: `
    <mat-toolbar color="primary">
      <span>kayPeyinAnApp</span>
      <span class="spacer"></span>
      <button mat-button routerLink="/">Accueil</button>
      <button mat-button routerLink="/products">Produits</button>
      <button mat-icon-button routerLink="/basket"
        [matBadge]="(cart.count$ | async) ?? 0"
        [matBadgeHidden]="(cart.count$ | async) === 0"
        matBadgeColor="accent"
        aria-label="Panier">
        <mat-icon>shopping_cart</mat-icon>
      </button>
    </mat-toolbar>
    <router-outlet></router-outlet>
  `,
  styles: [`
    .spacer { flex: 1 1 auto; }
  `]
})
export class AppComponent {
  cart = inject(CartService);
}