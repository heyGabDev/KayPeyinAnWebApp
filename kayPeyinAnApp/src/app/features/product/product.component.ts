import {CommonModule, Location as NgLocation } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Product } from '../../models/product.model';
import { ActivatedRoute } from '@angular/router';

import { ProductService } from '../../core/services/product/product.service';
import { CartService } from '../../core/services/cart/cart.service';
import { NotificationService } from '../../core/services/notification/notification.service';
import { CategoryService } from '../../core/services/category/category.service';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    // Material
    MatCardModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
  productId: number | null = null;
  product: Product | null = null;
  category: number | null = null;
  categories: Category[] = [];

  // Quantité
  minQty = 1;
  maxQty = 20;
  quantity = 1;

  // Services
  private route = inject(ActivatedRoute);
  private productService = inject(ProductService);
  private categoryService = inject(CategoryService);
  private ngLocation = inject(NgLocation);
  private cart = inject(CartService)
  private notificationService = inject(NotificationService);

  ngOnInit(): void {
  const idParam = this.route.snapshot.paramMap.get('id'); 
  const id = idParam === null ? NaN : Number(idParam); 

  if (Number.isFinite(id)) {
    this.productId = id;
    this.getProductDetails(id); 
    this.loadCategories();
    }
  }

  getProductDetails(productId: number): void {
    this.productService.getProduct(productId).subscribe({
      next: (data: Product) => (
        this.product = data,
        this.category = data.categoryId,
        this.quantity = 1 ),// reset qty on new product load),
      error: (err) => console.error('Product recovery error: ', err),
    });
  }

  // Navigation
  goBack(): void {
    this.ngLocation.back();
  }

  // Quantité
  increment(): void {
    if (this.quantity < this.maxQty) this.quantity++;
    this.notificationService.success('Un article en plus dans le panier 🛒');
  }

  decrement(): void {
    if (this.quantity > this.minQty) this.quantity--;
    this.notificationService.warning('Un article en moins dans le panier 🛒');
  }

  onQtyChange(val: number): void {
    // Garde la quantité dans les bornes
    if (val == null) return;
    this.quantity = Math.max(this.minQty, Math.min(this.maxQty, Number(val)));
    this.notificationService.success('Quantité mise à jour');
  }

  // Panier
  addToCart(product: Product): void {
    if(this.quantity < 1 || this.quantity > 20) return;
    if (!product) return;

    this.cart.add(product, this.quantity);
    this.notificationService.success(`${product.product_Name} x ${this.quantity} ajouté au panier 🛒`);
  }

    getCategoryName(categoryId: number): string {
    const category = this.categoryService.getCategoryName(this.categories, categoryId); 
    return category ? category : 'Inconnu';
  }

   loadCategories(): void {
    this.categoryService.getCategories().subscribe((res) => {
      this.categories = res; // Pour le select
    }); 
  }
}
