//this is a normal typescript class with properties
//export
var StoreCustomer = /** @class */ (function () {
    function StoreCustomer(FirstName, Lastname, theName) {
        this.FirstName = FirstName;
        this.Lastname = Lastname;
        this.visits = 1; //proprties
        this.name = theName;
    }
    StoreCustomer.prototype.Showname = function (name) {
        alert(name);
        return true;
    };
    StoreCustomer.prototype.ShowOurName = function () {
        alert(this.name);
    };
    StoreCustomer.prototype.ShowFullnName = function () {
        alert(this.FirstName + " " + this.Lastname);
    };
    Object.defineProperty(StoreCustomer.prototype, "name", {
        get: function () {
            return this.ourname;
        },
        set: function (val) {
            this.ourname = val;
        },
        enumerable: true,
        configurable: true
    });
    return StoreCustomer;
}());
var cust = new StoreCustomer("first", "second", "third");
cust.visits = 10;
//# sourceMappingURL=storeCustomer.js.map