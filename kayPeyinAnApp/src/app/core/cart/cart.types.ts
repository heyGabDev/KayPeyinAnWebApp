// src/app/core/cart/cart.types.ts
import { Product } from '../../modeles/product.modele';

export interface CartItem {
  product: Product;
  qty: number; // 1..999 (0 => suppression via helpers)
}
