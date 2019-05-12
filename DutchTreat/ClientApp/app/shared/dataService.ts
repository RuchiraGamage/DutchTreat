
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { map, count, retry } from "rxjs/operators";
import { Observable } from 'rxjs';
import { Product } from './product';
import { Order, OrderItem } from './order';


@Injectable()
export class DataService {

    constructor(private http: HttpClient) {
    }

    private token: string = "";
    private tokenExpiration: Date;


    public order: Order = new Order();

    public products: Product[] = []

    loadProducts(): Observable<boolean> {
        return this.http.get("/api/products")
            .pipe(
                map((data: any[]) => {
                    this.products = data;
                    return true;
                })
            );
    }

    public get loginRequired(): boolean { //'get' is for read only
        return this.token.length == 0 || this.tokenExpiration < new Date();
    }

    login(creds): Observable<boolean> {
        return this.http.post("/account/createtoken", creds)
            .pipe(
                map((data: any) => {
                    this.token = data.token;
                    this.tokenExpiration = data.expiration;
                    return true;
                })
            );
    }

    public addToOrder(newProduct: Product) {

        let item: OrderItem = this.order.items.find(o => o.productId == newProduct.id);

        if (item) {
            item.quantity++;
        }
        else {
            item = new OrderItem();
            item.productId = newProduct.id;
            item.productArtist = newProduct.artist;
            item.productArtId = newProduct.artId;
            item.productCategory = newProduct.category;
            item.productSize = newProduct.size;
            item.productTitle = newProduct.title;
            item.unitPrice = newProduct.price;
            item.quantity = 1;

            this.order.items.push(item);
        }

    }

    public checkout(): Observable<boolean> {

        if (!this.order.orederNumber) {
            this.order.orederNumber = this.order.orderDate.getFullYear().toString() + this.order.orderDate.getTime().toString();
        };

        return this.http.post("/api/orders", this.order
            , { headers: new HttpHeaders().set("Authorization", "Bearer "+this.token)}
          )
            .pipe(
                map(response => {
                    this.order = new Order();
                    return true;
                })
            );
    }
}