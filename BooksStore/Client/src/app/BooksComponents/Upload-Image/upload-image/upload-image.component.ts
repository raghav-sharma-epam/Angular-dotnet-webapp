import { Component } from '@angular/core';
import { UploadService } from '../../Services/upload.service';
import { ToastrService } from 'ngx-toastr';
import { BlogImage, BlogImageDto } from 'src/app/Interfaces/IBookDetail';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-upload-image',
  templateUrl: './upload-image.component.html',
  styleUrls: ['./upload-image.component.css']
})
export class UploadImageComponent {
private file :File;
public FileName:string="";
public title:string="";
public response:BlogImage;
public GetImgs:BlogImageDto;
constructor(private uploadservice:UploadService,private toast:ToastrService) { }

ngOnInit(): void {
  console.log("Data for img first all",this.GetImgs);
this.GetImages();
setTimeout(() => {
  console.log("Data for img all",this.GetImgs);
}, 2000);

}

FileUploadChange(event:Event)
{
  console.log("fileUploadchangecalled");
  const element = event.target as HTMLInputElement;
this.file = element.files?.[0];
console.log(this.file);


}

GetImages()
{
  
  this.uploadservice.GetImages().subscribe(res=>{
    this.GetImgs = res;
  })
  

}

getImageUrl(url: string): string {
  if (!url) return '';
  return encodeURI(url.trim());
}

  DetailSubmit():void
  {
    console.log("submit method called");
    if(this.file!= null)
    { this.uploadservice.UploadImage(this.file,this.FileName,this.title).
      subscribe((response)=>{
        this.response = response;
        this.toast.success("Image uploaded successfully");
        
        if(response == null)
        {
          this.toast.error("Image Upload Failed");
        }
      })
    }
  }
}
