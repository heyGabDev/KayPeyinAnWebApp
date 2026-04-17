import { CartItem } from './cart.types';
import { Product } from '../../models/product.model';

const MAX_QTY = 20;
const MIN_QTY = 1;

export function clampQty(q: number): number {
  const n = Number.isFinite(q) ? Math.trunc(q) : 0;
  return Math.max(0, Math.min(MAX_QTY, n)); // 0 autorisé -> supprime la ligne
}

export function addItem(items: CartItem[], product: Product, qty = 1): CartItem[] {
  const q = clampQty(qty) || MIN_QTY;
  const i = items.findIndex(it => it.product.id === product.id);
  if (i >= 0) {
    const next = [...items];
    next[i] = { ...next[i], qty: Math.min(MAX_QTY, next[i].qty + q) };
    return next;
  }
  return [{ product, qty: q }, ...items];
}

export function setItemQty(items: CartItem[], productId: number, qty: number): CartItem[] {
  const q = clampQty(qty);
  const next = items.map(it => it.product.id === productId ? { ...it, qty: q } : it);
  return next.filter(it => it.qty > 0);
}

export function incItem(items: CartItem[], productId: number): CartItem[] {
  return items.map(it =>
    it.product.id === productId ? { ...it, qty: Math.min(MAX_QTY, it.qty + 1) } : it
  );
}

export function decItem(items: CartItem[], productId: number): CartItem[] {
  const next = items.map(it =>
    it.product.id === productId ? { ...it, qty: Math.max(0, it.qty - 1) } : it
  );
  return next.filter(it => it.qty > 0);
}

export function removeItem(items: CartItem[], productId: number): CartItem[] {
  return items.filter(it => it.product.id !== productId);
}

export function computeCount(items: CartItem[]): number {
  return items.reduce((acc, it) => acc + it.qty, 0);
}

export function computeTotal(items: CartItem[]): number {
  return items.reduce((acc, it) => acc + it.product.price * it.qty, 0);
}
