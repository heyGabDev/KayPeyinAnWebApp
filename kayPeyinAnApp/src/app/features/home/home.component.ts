import { Component, inject, OnInit, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { RouterLink, Router } from '@angular/router';
import { CurrencyPipe } from '@angular/common';
import { Product } from '../../models/product.model';
import { ProductService } from '../../core/services/product/product.service';
import { CartService } from '../../core/services/cart/cart.service';
import { NotificationService } from '../../core/services/notification/notification.service';
import { CategoryPipe } from '../../shared/pipes/category.pipe';

// Swiper (carrousel)
// Documentation : https://swiperjs.com/swiper-api
import { register } from 'swiper/element/bundle';
// Enregistre les web components Swiper (obligatoire)
register();

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    MatButtonModule, MatCardModule, MatIconModule,
    RouterLink, CurrencyPipe, CategoryPipe,
  ],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class HomeComponent implements OnInit {
  featuredProducts: Product[] = [];

  private productService = inject(ProductService);
  private router = inject(Router);
  private cart = inject(CartService);
  private notification = inject(NotificationService);

  ngOnInit(): void {
    this.loadFeaturedProducts();
  }

  loadFeaturedProducts(): void {
    this.productService.getProducts().subscribe((res) => {
      this.featuredProducts = res
        .sort(() => Math.random() - 0.5)
        .slice(0, 4); // 4 produits aléatoires
    });
  }

  goToProduct(productId: number): void {
    this.router.navigate(['/product', productId]);
  }

  addToCart(productId: number, event: Event): void {
    event.stopPropagation();
    const product = this.featuredProducts.find(p => p.id === productId);
    if (!product) return;
    this.cart.add(product, 1);
    this.notification.success(`${product.product_name} ajouté au panier 🛒`);
  }
}
