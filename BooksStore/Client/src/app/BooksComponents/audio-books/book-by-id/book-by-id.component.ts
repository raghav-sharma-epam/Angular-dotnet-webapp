import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Bookdetail } from 'src/app/Interfaces/IBookDetail';
import { BookServiceService } from '../Service/book-service.service';

@Component({
  selector: 'app-book-by-id',
  templateUrl: './book-by-id.component.html',
  styleUrls: ['./book-by-id.component.css']
})
export class BookByIdComponent implements OnInit {

  BookByIdData:Bookdetail;

  constructor(private service:BookServiceService,
    private activateroute:ActivatedRoute) { }

  ngOnInit(): void {
    this.GetBookById();
  }
  
  GetBookById()
  {
    this.service.BookFetchById(+this.activateroute.snapshot.paramMap.get('id')).subscribe((bookbyid)=>
    {
      this.BookByIdData = bookbyid;
      console.log(this.BookByIdData);
    },error=>
    {
      console.log(error);
    });
    
  }

}
