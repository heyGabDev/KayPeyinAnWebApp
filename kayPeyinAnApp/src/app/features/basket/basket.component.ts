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
import { CartService } from '../../services/cart/cart.service';
import { NotificationService } from '../../core/services/notification.service';

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
  templateUrl: './basket.component.html',
  styleUrl: './basket.component.css'
})
export class BasketComponent {
  // Quantité
  minQty = 1;
  maxQty = 20;
  quantity = 1;

// Services
  private cart = inject(CartService);
  private notificationService = inject(NotificationService);

  readonly vm$ = combineLatest({
    items: this.cart.items$,
    total: this.cart.total$,
    count: this.cart.count$,
  });

  increment(id: number) { 
    this.cart.inc(id); 
    this.notificationService.success('Un article en plus dans le panier 🛒');
  }
  
  decrement(id: number) { 
    this.cart.dec(id); 
    this.notificationService.warning('Un article en moins dans le panier 🛒');
  }
  
  setQty(id: number, q: number) { 
    this.cart.setQty(id, q); 
    this.notificationService.success('Quantité mise à jour');
  }
  
  remove(id: number) { 
    this.cart.remove(id); 
    // TO DO: Confirmation à rajouter
    this.notificationService.warning('Produit retiré du panier ');
  }
  
  clear() { 
    this.cart.clear(); 
    this.notificationService.warning('Panier vidé 🛒');
  }
  
  checkout() { /* TODO: route/logic paiement */ }
}
