import { Routes } from '@angular/router';

export const routes: Routes = [
    { 
        path: '', 
        redirectTo: 'products', 
        pathMatch: 'full'
    }, 
    {
        path: 'products',
    title: 'Nos produits',
    loadComponent: () => import('./features/products/products.component').then((c) => c.ProductsComponent
      ),
    },
    {
        path:'product/:id',
        title: 'Détail produit',
        loadComponent: () => import('./features/product/product.component').then(c => c.ProductComponent)
    },
    {
        path:'basket',
        title: 'Mon panier',
        loadComponent: () => import('./features/basket/basket-component').then(c => c.BasketComponent)
    },
    {
        path: '**',
        redirectTo: 'products'
    }
];
