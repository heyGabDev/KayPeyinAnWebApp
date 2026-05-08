import { TestBed } from '@angular/core/testing';
import { CartService } from './cart.service';
import { Product } from '../../../models/product.model';
import { provideHttpClientTesting } from '@angular/common/http/testing';
import { provideHttpClient } from '@angular/common/http';

// describe() → groupe tous les tests liés au CartService
describe('CartService', () => {
  let service: CartService;

  // Produit mock — données fictives pour les tests
  // On n'utilise pas la vraie BDD — principe d'isolation
  const mockProduct: Product = new Product(
    1,
    'Baguette Tradition',
    3.37,
    100,
    'assets/images/baguette.png',
    1
  );

  // beforeEach() → s'exécute AVANT chaque test
  // Garantit que chaque test part d'un état propre
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [
        provideHttpClient(),           // HttpClient disponible pour les services
        provideHttpClientTesting()     // Intercepte les vrais appels HTTP — pas de BDD réelle
      ]
    });
    // inject() → récupère l'instance du service depuis le TestBed
    service = TestBed.inject(CartService);
    // Vider le panier avant chaque test — état initial garanti
    service.clear();
  });

  // ─── Tests ────────────────────────────────────────────

  // Test 1 : vérifie que le service s'instancie correctement
  // toBeTruthy() → l'objet existe et n'est pas null/undefined
  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  // Test 2 : ajout d'un produit au panier
  // subscribe() → nécessaire car items$ est un Observable
  // On vérifie la longueur du tableau ET les données du produit
  it('should add a product to the cart', () => {
    service.add(mockProduct, 1);
    service.items$.subscribe(items => {
      expect(items.length).toBe(1);         // 1 produit dans le panier
      expect(items[0].product.id).toBe(1);  // C'est bien notre produit
      expect(items[0].qty).toBe(1);         // La quantité est correcte
    });
  });

  // Test 3 : incrément de quantité
  // On ajoute 1, on incrémente → on attend 2
  it('should increment quantity', () => {
    service.add(mockProduct, 1);
    service.inc(mockProduct.id);
    service.items$.subscribe(items => {
      expect(items[0].qty).toBe(2);
    });
  });

  // Test 4 : décrément de quantité
  // On ajoute 2, on décrémente → on attend 1
  it('should decrement quantity', () => {
    service.add(mockProduct, 2);
    service.dec(mockProduct.id);
    service.items$.subscribe(items => {
      expect(items[0].qty).toBe(1);
    });
  });

  // Test 5 : suppression d'un produit
  // Après remove() → le panier doit être vide
  it('should remove a product from the cart', () => {
    service.add(mockProduct, 1);
    service.remove(mockProduct.id);
    service.items$.subscribe(items => {
      expect(items.length).toBe(0);
    });
  });

  // Test 6 : vider le panier
  // clear() → tous les articles supprimés
  it('should clear the cart', () => {
    service.add(mockProduct, 2);
    service.clear();
    service.items$.subscribe(items => {
      expect(items.length).toBe(0);
    });
  });

  // Test 7 : calcul du total
  // 3.37 * 2 = 6.74 — on vérifie le calcul métier
  it('should calculate total correctly', () => {
    service.add(mockProduct, 2);
    service.total$.subscribe(total => {
      expect(total).toBe(6.74);
    });
  });

  // Test 8 : calcul du nombre d'articles
  // 3 articles → count doit être 3
  it('should calculate count correctly', () => {
    service.add(mockProduct, 3);
    service.count$.subscribe(count => {
      expect(count).toBe(3);
    });
  });
});