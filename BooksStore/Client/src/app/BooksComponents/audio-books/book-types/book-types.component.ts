import { Component, AfterViewInit,OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ProductNav } from 'src/app/Interfaces/IBookDetail';
import { ChildComponent } from '../child/child.component';
import { BookServiceService } from '../Service/book-service.service';

@Component({
  selector: 'app-book-types',
  templateUrl: './book-types.component.html',
  styleUrls: ['./book-types.component.css']
})
export class BookTypesComponent implements AfterViewInit {
 Types:ProductNav
@ViewChild (ChildComponent) child :ChildComponent;


 


 BookAddNew:FormGroup;
  constructor(private service :BookServiceService) { }

  ngOnInit(): void {
    this.BookType();
    this.CreateBookDetail();
  }
  

  ngAfterViewInit()
  {
  console.log(this.child);
  }
  CreateBookDetail()
  {
    this.BookAddNew = new FormGroup({

      name :new FormControl('',Validators.required),
    });
    }

    OnSubmit()
    {
      console.log(this.BookAddNew.value);
    }

  BookType()
  {
    this.service.BookTypes().subscribe((res:ProductNav)=>
    {
      this.Types = res;
      return this.Types;

    },(error)=>
    {
      console.log(error);
    });
  

   













  }

  ChildCalled()
  {
    this.child.Add();
  }


  ChildCalledDec()
  {
    this.child.Delete();
  }

}


