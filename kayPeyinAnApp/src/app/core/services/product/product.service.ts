import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../../models/product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiUrl = 'https://localhost:7037/api/products';
  // private apiUrl = 'assets/datas/products_mock.json';
  private http = inject(HttpClient);

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl);
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.apiUrl}/${id}`);
  }

  getProductsPaged(page: number, pageSize:number, category?: number | null, search?: string): Observable<Product[]> {
    let url = `${this.apiUrl}/paged?page=${page}&pageSize=${pageSize}`;
    if (category !== undefined && category !== null) {
      url += `&category=${category}`;
    }
    if (search) {
      url += `&search=${encodeURIComponent(search)}`;
    }
    return this.http.get<Product[]>(url);
  }
}