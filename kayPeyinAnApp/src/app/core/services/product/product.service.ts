import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = 'assets/datas/products_mock.json';
  private http = inject(HttpClient);

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  getProduct(id: number): Observable<Product> {
    // Qd j'aurais mon back
    // return this.http.get<any>(`${this.apiUrl}/${id}`);
    return new Observable<Product>((observer) => {
      this.getProducts().subscribe((products) => {
        const product = products.find((p) => p.id === id);
        if (product) observer.next(product);
        observer.complete();
      });
    });
  }
}
