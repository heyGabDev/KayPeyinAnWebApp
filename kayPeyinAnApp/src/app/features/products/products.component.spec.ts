import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProductsComponent } from './products.component';
import { provideHttpClient } from '@angular/common/http';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { provideRouter } from '@angular/router';
import { Product } from '../../models/product.model';

describe('ProductsComponent', () => {
  let component: ProductsComponent;
  let fixture: ComponentFixture<ProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProductsComponent],
      providers: [
        provideHttpClient(),           // Fournit HttpClient aux services
        provideHttpClientTesting(),    // Intercepte les appels HTTP (pas de vrais appels)
        provideRouter([]),             // Router mocké vide (pas besoin de vraies routes)
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(ProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // ─── Tests ────────────────────────────────────────────

  // Test 1 : le composant se crée sans erreur
  it('should create', () => {
    expect(component).toBeTruthy();
  });

  // Test 2 : les tableaux sont vides au démarrage
  it('should initialize with empty products', () => {
    expect(component.pagedItems).toEqual([]);
  });

  // Test 3 : la pagination est configurée par défaut
  it('should have default pagination values', () => {
    expect(component.currentPage).toBe(0);
    expect(component.itemsPerPage).toBe(12);
    expect(component.totalItems).toBe(0);
  });

  // Test 4 : resetFilters remet tout à zéro
  it('should reset filters correctly', () => {
    component.selectedCategory = 1;
    component.searchText.setValue('baguette');
    component.resetFilters();
    expect(component.selectedCategory).toBeNull();
    expect(component.searchText.value).toBe('');
  });

  // Test 5 : applyFilters avec recherche texte
  it('should filter products by search text', () => {
    component.pagedItems = [
      { id: 1, product_Name: 'Baguette', product_Price: 3.37, product_Stock: 100, imageUrl: '', categoryId: 1, available: true } as Product,
      { id: 2, product_Name: 'Croissant', product_Price: 2.06, product_Stock: 100, imageUrl: '', categoryId: 1, available: true } as Product,
    ];
    component.searchText.setValue('baguette');
    component.applyFilters();
    expect(component.pagedItems.length).toBe(1);
  });
});