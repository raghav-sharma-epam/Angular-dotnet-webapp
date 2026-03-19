import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BlogImage, BlogImageDto } from 'src/app/Interfaces/IBookDetail';

@Injectable({
  providedIn: 'root'
})
export class UploadService {

  private Baseurl = "https://localhost:44395/";


  constructor(private http: HttpClient) { }

  UploadImage(file:File,FileName:string,title:string):Observable<BlogImage>
  {
     var formdata = new FormData();
     formdata.append("file",file);
     formdata.append("FileName",FileName);
     formdata.append("title",title);
    return  this.http.post<BlogImage>(this.Baseurl+'api/BlogImage/GetImageUpload',formdata);
  }

  GetImages():Observable<BlogImageDto>
  {
    return this.http.get<BlogImageDto>(this.Baseurl+'api/BlogImage/GetImages');
  }
}
