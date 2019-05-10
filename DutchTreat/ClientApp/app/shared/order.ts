export class Order {
    orderId: number;
    orderDate: Date = new Date();
    orederNumber: string;
    items: Array<OrderItem> = new Array<OrderItem>();

    get subTotal(): number {
        var sum: number = 0;
        for (var i = 0; i < this.items.length; i++) {
            sum = (sum + this.items[i].quantity * this.items[i].unitPrice);
        }
        return sum;
    };
}

export class OrderItem {
    id: number;
    quantity: number;
    unitPrice: number;
    productId: number;
    productCategory: string;
    productSize: string;
    productTitle: string;
    productArtist: string;
    productArtId: string;
}