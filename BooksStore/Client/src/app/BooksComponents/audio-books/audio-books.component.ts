import { Component, OnInit } from '@angular/core';
import { BookServiceService } from './Service/book-service.service';
import { Bookdetail } from 'src/app/Interfaces/IBookDetail';
import { Observable } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-audio-books',
  templateUrl: './audio-books.component.html',
  styleUrls: ['./audio-books.component.css']
})
export class AudioBooksComponent implements OnInit {
value:boolean;
BookData :Bookdetail;
picture:any = 'https://localhost:44395/BooksStore/Images/s25.jpg';

  constructor(private service:BookServiceService,private toast:ToastrService) { }

  ngOnInit() {
   this.BookDataFetch();
  }

   BookDataFetch():any
   {
     this.service.BookFetch().subscribe((data:Bookdetail)=>
     {
      this.BookData = data;
      console.log(this.BookData);
      return this.BookData;

     });

   }

  onDelete(id){
    this.service.BookDataDelete(id).subscribe((v:boolean)=>{
      this.value=v;
      if(this.value == true)
      {
        this.toast.success("Data has been deleted for ID",id);
      }
      this.BookDataFetch();
      console.log('data deleted or not ',this.value);
    })
  }

}
