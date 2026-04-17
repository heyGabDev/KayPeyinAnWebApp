import { Pipe, PipeTransform } from '@angular/core';
import { ProductCategory } from '../../models/product.model';

@Pipe({
  name: 'category',
  standalone: true,
})
export class CategoryPipe implements PipeTransform {
  transform(value: ProductCategory): string {
    switch (value) {
      case ProductCategory.Boulangerie: return 'Boulangerie';
      case ProductCategory.Patisserie:  return 'Pâtisserie';
      case ProductCategory.Snacking:    return 'Snacking';
      case ProductCategory.Boisson:     return 'Boisson';
      default:                          return 'Catégorie inconnue';
    }
  }
}