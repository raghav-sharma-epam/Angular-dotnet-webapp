import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBookDetailAddComponent } from './new-book-detail-add.component';

describe('NewBookDetailAddComponent', () => {
  let component: NewBookDetailAddComponent;
  let fixture: ComponentFixture<NewBookDetailAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewBookDetailAddComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewBookDetailAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
