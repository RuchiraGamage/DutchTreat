var Order = /** @class */ (function () {
    function Order() {
        this.orderDate = new Date();
        this.items = new Array();
    }
    Object.defineProperty(Order.prototype, "subTotal", {
        get: function () {
            var sum = 0;
            for (var i = 0; i < this.items.length; i++) {
                sum = (sum + this.items[i].quantity * this.items[i].unitPrice);
            }
            return sum;
        },
        enumerable: true,
        configurable: true
    });
    ;
    return Order;
}());
export { Order };
var OrderItem = /** @class */ (function () {
    function OrderItem() {
    }
    return OrderItem;
}());
export { OrderItem };
//# sourceMappingURL=order.js.map