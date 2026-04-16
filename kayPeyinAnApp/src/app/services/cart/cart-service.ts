import { Injectable } from '@angular/core';
import { Product } from '../../models/product.model';
import { BehaviorSubject, map } from 'rxjs';
import { CartItem } from '../../core/cart/cart.types';
import { addItem, decItem, incItem, removeItem, setItemQty } from '../../core/cart/cart.utils';

const STORAGE_KEY = 'cart_V1';

@Injectable({
  providedIn: 'root'
})
export class CartService {
private readonly itemsSubject = new BehaviorSubject<CartItem[]>(this.load());
readonly items$ = this.itemsSubject.asObservable();

readonly count$ = this.items$.pipe(
  map(items => items.reduce((acc, item) => acc + item.qty, 0))
);

readonly total$ = this.items$.pipe(
  map(items => items.reduce((acc, item) => acc + item.qty * item.product.price, 0))
);

add(product: Product, qty = 1): void {
this.update(addItem(this.itemsSubject.value, product, qty));
}

remove(productId: number): void {
  this.update(removeItem(this.itemsSubject.value, productId)); 
}

clear(): void {
this.update([]);
} 

setQty(productId: number, qty: number): void {
    this.update(setItemQty(this.itemsSubject.value, productId, qty));
  }
  inc(productId: number): void {
    this.update(incItem(this.itemsSubject.value, productId));
  }
  dec(productId: number): void {
    this.update(decItem(this.itemsSubject.value, productId));
  }

  // — Persistance —
  private update(items: CartItem[]): void {
    this.itemsSubject.next(items);
    try { localStorage.setItem(STORAGE_KEY, JSON.stringify(items)); } catch {}
  }
  private load(): CartItem[] {
    try { return JSON.parse(localStorage.getItem(STORAGE_KEY) || '[]'); }
    catch { return []; }
  }

}