import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';
import { Product } from '../../models/product.model';

import { ProductService } from '../../core/services/product/product.service';
import { NotificationService } from '../../core/services/notification/notification.service';
import { CartService } from '../../core/services/cart/cart.service';
import { CategoryService } from '../../core/services/category/category.service';
import { Category } from '../../models/category.model';

@Component({
  selector: 'app-products',
  standalone: true,
  imports: [
    CommonModule, FormsModule, ReactiveFormsModule,
    MatCardModule, MatFormFieldModule, MatSelectModule,
    MatInputModule, MatIconModule, MatButtonModule,
    MatPaginatorModule,
],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css',
})
export class ProductsComponent implements OnInit {
  // Données
  pagedItems: Product[] = [];

  // Pagination
  totalItems = 0;
  itemsPerPage = 12;
  currentPage = 0;

  // Filtres
  categories: { label: string; value: number }[] = [];
  selectedCategory: number | null = null;
  rawCategories: Category[] = []; // Stockage brut pour mapping  

  // Recherche
  productForm: FormGroup;
  searchText = new FormControl<string>('');

  // Services
  private productService = inject(ProductService);
  private categoryService = inject(CategoryService);
  private router = inject(Router);
  private cart = inject(CartService);
  private notification = inject(NotificationService);

  constructor() {
    this.productForm = new FormGroup({ searchText: this.searchText });
  }

  ngOnInit(): void {
    this.loadCategories();
    this.loadData();
  }

  // Chargement / mapping
  loadData(): void {
      this.updatePagedProducts();
  }

  loadCategories(): void {
    this.categoryService.getCategories().subscribe((res) => {
      this.rawCategories = res; // Stockage brut pour mapping 
      this.categories = res.map((c) => ({ 
        label: c.name, 
        value: c.id,
      }));
    }); 
  }

  // Pagination locale
  updatePagedProducts(): void {
   this.productService.getProductsPaged(this.currentPage + 1, this.itemsPerPage, this.selectedCategory, this.searchText.value ?? '')
   .subscribe((res) => {
      this.pagedItems = res;
    });
  }

  onPageChange(event: PageEvent): void {
    this.itemsPerPage = event.pageSize ?? this.itemsPerPage;
    this.currentPage = event.pageIndex ?? this.currentPage;
    this.updatePagedProducts();
  }

  // Filtres
  onCategoryChange(selected: number | null): void {
    this.selectedCategory = selected;
    this.applyFilters();
  }

  // applyFilters(): void {
  //   const search = (this.searchText.value ?? '').toLowerCase();
  //   console.log('Applying filters with search:', search);
  //   const selected = this.selectedCategory;

  //   this.filteredProducts = this.pagedItems.filter((product) => {
  //     const matchCategory = selected !== null ? product.categoryId === selected : true;
  //     const matchSearch = search ? product.product_Name.toLowerCase().includes(search) : true;
  //     console.log('tape product:', matchSearch,product.product_Name.toLowerCase(), search);
  //     return matchCategory && matchSearch;
  //   });
  //   this.currentPage = 0;
  //   this.updatePagedProducts();
  //   this.totalItems = (this.filteredProducts.length || this.pagedItems.length);
  // }

  applyFilters(): void {
  const search = this.searchText.value ?? '';
  this.currentPage = 0;
  this.productService.getProductsPaged(
    this.currentPage + 1,
    this.itemsPerPage,
    this.selectedCategory,
    search
  ).subscribe((res) => {
    this.pagedItems = res;
  });
}

  resetFilters(): void {
    this.searchText.setValue('');
    this.selectedCategory = null;
    this.currentPage = 0;
    this.totalItems = this.pagedItems.length;
    this.updatePagedProducts();
  }

  goToProduct(productId: number): void {
    this.router.navigate(['/product', productId]);
  }

  addToCart(productId: number, event: Event): void {
    event.stopPropagation();
    const product = this.pagedItems.find(p => p.id === productId);
    if (!product) return;
    this.cart.add(product, 1);
    this.notification.success(`${product.product_Name} ajouté au panier 🛒`);
  }

  getCategoryName(categoryId: number): string {
    const category = this.categoryService.getCategoryName(this.rawCategories, categoryId); 
    return category ? category : 'Inconnu';
  }
}
