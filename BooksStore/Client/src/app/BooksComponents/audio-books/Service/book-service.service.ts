import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Bookdetail } from 'src/app/Interfaces/IBookDetail';

@Injectable()
export class ConfigService {
  constructor(private http: HttpClient) { }
}

@Injectable({
  providedIn: 'root'
})
export class BookServiceService {

  private   Baseurl ="https://localhost:44395/";


  constructor(private http:HttpClient ) { } 

  BookFetchById(id :number)
  {
    return this.http.get<Bookdetail>(this.Baseurl+'api/Product/GetBookById?id='
     + id);
  }

  BookFetch()
  {
   return this.http.get(this.Baseurl+'api/Product/GetBookDetail');
  }

  BookTypes()
  {
    return this.http.get(this.Baseurl+'api/Product');
  }
   requestOptions: Object = {
    /* other options here */
    responseType: 'text'
  }

  BookDataAdd(value:string)
  {
    return this.http.post<string>
    (this.Baseurl+'api/Product/BookDetailAdd',value,
     this.requestOptions);
  }

  BookDataDelete(id:number)
  {
    return this.http.delete<boolean>(this.Baseurl+'api/Product/BookDetailDelete?id='+id);
  }
}
