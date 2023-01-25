export class Model {
    categoryName:string;
    products:Array<Product>;

    constructor(){
    }
}

export class Product{
    Id:number;
    Name:string;
    Price:string;
    IsActive:boolean;

    constructor(id:number,name:string,price:string,isActive:boolean){
        this.Id=id;
        this.Name=name;
        this.Price=price;
        this.IsActive=isActive;
    }

}
