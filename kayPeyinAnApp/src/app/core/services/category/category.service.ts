import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable, shareReplay } from 'rxjs';
import { Category } from '../../../models/category.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private apiUrl = 'https://localhost:7037/api/categories';
  private http = inject(HttpClient);
   
  // Avec cache
  private categories$ = this.http.get<Category[]>(this.apiUrl).pipe(
    shareReplay(1) // ← met en cache le résultat — un seul appel HTTP
  );

  getCategories(): Observable<Category[]> {
    return this.categories$;
  }

  getCategory(id: number): Observable<Category> {
    return this.http.get<Category>(`${this.apiUrl}/${id}`);
  }

  getCategoryName(categories: Category[], categoryId: number): string {
    return categories.find(c => c.id === categoryId)?.name ?? 'Inconnu';
  }

}
