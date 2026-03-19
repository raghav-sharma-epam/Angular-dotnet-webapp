import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { BrandEnum, productEnum } from '../../TypescriptModels/IRegister';
import { BookServiceService } from '../Service/book-service.service';

@Component({
  selector: 'app-new-book-detail-add',
  templateUrl: './new-book-detail-add.component.html',
  styleUrls: ['./new-book-detail-add.component.css']
})
export class NewBookDetailAddComponent implements OnInit {
BookDetailForm : FormGroup;
response:string; 
productenum:any;
brandenum :any;
constructor(private service:BookServiceService,private toast:ToastrService) { }

  ngOnInit(): void {
    this.CreateBookDetail();
    //this.productenum  = Object.values(productEnum).filter(v=>typeof v==='string');
    this.productenum = productEnum;
    this.brandenum = BrandEnum;
   
    console.log('enum', this.productenum);
  }

  CreateBookDetail()
  {
    this.BookDetailForm = new FormGroup({

      name :new FormControl('',Validators.required),
      description :new FormControl('',Validators.required),
      price :new FormControl('',[Validators.required,
      Validators.pattern("^[0-9]*$")]),
      genre :new FormControl('',Validators.required),
      picture :new FormControl('',Validators.required),
      productId :new FormControl('',Validators.required),
      brandId :new FormControl('',Validators.required)

    });

  }

  OnSubmit()
  {
    console.log('form values',this.BookDetailForm.value);
    this.service.BookDataAdd
    (this.BookDetailForm.value).subscribe((res)=>
    {
      this.response=res;
      if(this.response)
      {
        this.toast.show("Data has been added in the form");
      }
      console.log(res);
      console.log(this.response);
      this.BookDetailForm.reset();
    },(error)=>
    {
      console.log(error);
    });
    //console.log(this.BookDetailForm.value);

  }
}
