export class Product {
  constructor(
    public id: number,
    public product_Name: string,
    public product_Price: number,
    public product_Stock: number,
    public imageUrl: string,
    public categoryId: number,
    public product_Description?: string,
    public available?: boolean,
    public createdAt?: Date,
    public updatedAt?: Date,
  ) {}

  isAvailable(): boolean {
    return this.product_Stock > 0;
  }
}
