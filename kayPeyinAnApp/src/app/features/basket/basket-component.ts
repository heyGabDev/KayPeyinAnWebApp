import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { RouterLink } from '@angular/router';
import { combineLatest } from 'rxjs';
import { CartService } from '../../services/cart/cart-service';

@Component({
  selector: 'app-basket-component',
  standalone: true,
  imports: [
    CommonModule, 
    FormsModule, 
    RouterLink,
    MatCardModule, 
    MatButtonModule, 
    MatIconModule,
    MatDividerModule, 
    MatFormFieldModule, 
    MatInputModule
  ],
  templateUrl: './basket-component.html',
  styleUrl: './basket-component.css'
})
export class BasketComponent {
// Services
  private cart = inject(CartService);

  readonly vm$ = combineLatest({
    items: this.cart.items$,
    total: this.cart.total$,
    count: this.cart.count$,
  });

  inc(id: number) { this.cart.inc(id); }
  dec(id: number) { this.cart.dec(id); }
  setQty(id: number, q: number) { this.cart.setQty(id, q); }
  remove(id: number) { this.cart.remove(id); }
  clear() { this.cart.clear(); }
  checkout() { /* TODO: route/logic paiement */ }
}
