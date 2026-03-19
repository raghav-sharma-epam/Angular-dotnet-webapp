

    export interface Bookdetail {
        id: number;
        name: string;
        description: string;
        price: number;
        genre: string;
        
        prodId: number;
    }

    export interface ProductNav {
        id: number;
        name: string;
        bookdetail: Bookdetail[];
    }

    export interface RootObject {
        id: number;
        name: string;
        description: string;
        price: number;
        genre: string;
        picture?: any;
        productNav: ProductNav;
        prodId: number;
    }

    export interface BlogImage
    {
        file:File;
        FileName:string;
        title:string;

    }

    export interface BlogImageDto
    {
        title:string;
        fileName:string;
        fileExtension:string;
        dateCreated:Date;
        url:File;

    }



