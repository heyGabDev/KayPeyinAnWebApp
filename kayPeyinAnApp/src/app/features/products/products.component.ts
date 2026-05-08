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
  products: Product[] = [];
  filteredProducts: Product[] = [];
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
    this.loadData();
    this.loadCategories();
  }

  // Chargement / mapping
  loadData(): void {
    this.productService.getProducts().subscribe((res) => {
      this.products = res;
      this.totalItems = res.length;
      this.updatePagedProducts();
    });
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
    const start = this.currentPage * this.itemsPerPage;
    const source = this.filteredProducts.length ? this.filteredProducts : this.products;
    this.pagedItems = source.slice(start, start + this.itemsPerPage);
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

  applyFilters(): void {
    const search = (this.searchText.value ?? '').toLowerCase();
    const selected = this.selectedCategory;

    this.filteredProducts = this.products.filter((product) => {
      const matchCategory = selected !== null ? product.categoryId === selected : true;
      const matchSearch = search ? product.product_Name.toLowerCase().includes(search) : true;
      return matchCategory && matchSearch;
    });

    this.currentPage = 0;
    this.updatePagedProducts();
    this.totalItems = (this.filteredProducts.length || this.products.length);
  }

  resetFilters(): void {
    this.searchText.setValue('');
    this.selectedCategory = null;
    this.filteredProducts = [];
    this.currentPage = 0;
    this.totalItems = this.products.length;
    this.updatePagedProducts();
  }

  goToProduct(productId: number): void {
    this.router.navigate(['/product', productId]);
  }

  addToCart(productId: number, event: Event): void {
    event.stopPropagation();
    const product = this.products.find(p => p.id === productId);
    if (!product) return;
    this.cart.add(product, 1);
    this.notification.success(`${product.product_Name} ajouté au panier 🛒`);
  }

  getCategoryName(categoryId: number): string {
    const category = this.categoryService.getCategoryName(this.rawCategories, categoryId); 
    return category ? category : 'Inconnu';
  }
}
