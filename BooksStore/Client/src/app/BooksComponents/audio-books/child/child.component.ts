import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { BookTypesComponent } from '../book-types/book-types.component';

@Component({
  selector: 'app-child',
  templateUrl: './child.component.html',
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements AfterViewInit {

  //Clone:FormGroup;

  Count:number=0 ;
  public Name:string="Raghav";
 public isVisible:boolean=true;

  constructor() { }
  ngAfterViewInit(): void {
    //console.log(this.child);
  }

  

  ngOnInit(): void {
  }
  
  Add():void
  {
    this.Count++;
  }


  Delete():void
  {
    this.Count--;
  }
  
  Submit():void
  {
    
  }

}
