export class Model {
    categoryName:string;
    products:Array<Product>;

    constructor(){
        this.categoryName="Telefon";
        this.products=[
            new Product(1,"samsung s5",2000,true),
            new Product(2,"samsung s6",3000,true),
            new Product(3,"samsung s7",4000,false),
            new Product(4,"samsung s8",5000,true),
            new Product(5,"samsung s9",6000,false)
          ];
    }
}

export class Product{
    id:number;
    name:string;
    price:number;
    isActive:boolean;

    constructor(id:number,name:string,price:number,isActive:boolean){
        this.id=id;
        this.name=name;
        this.price=price;
        this.isActive=isActive;
    }

}
