
//this is a normal typescript class with properties
//export
    class StoreCustomer {

    public constructor(private FirstName: string, private Lastname: string, theName: string) {//for the "firstname" and "lastname" it create the fields(property) and initializa at the same time
        this.name = theName;
    }

    public visits: number = 1;//proprties

    private ourname: string;//accessors much like properties

    public Showname(name: string): boolean {//these are functions of ts
        alert(name);
        return true;
    }

    public ShowOurName() {//these are functions of ts
        alert(this.name);
    }

    public ShowFullnName() {//these are functions of ts
        alert(this.FirstName + " " + this.Lastname);
    }

    set name(val) {
        this.ourname = val;
    }

    get name() {
        return this.ourname;
    }
}

let cust = new StoreCustomer("first","second","third");
cust.visits = 10;