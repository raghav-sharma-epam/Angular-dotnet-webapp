export class Register{
public userName : string;
public password:string;
}

export class Login
{
    public userName :string;
    public password:string;
}

export class User{
    Id:number;
    userName:string;
    passwordsalt:any;
    passwordHash:any
}

export enum productEnum{
    Mobile = '1',
    Tab='2',
    Computer='3'
};


export enum BrandEnum{
    Sony='1',
    Panasonic='2',
    Apple='3',
    Tesla='4'
}