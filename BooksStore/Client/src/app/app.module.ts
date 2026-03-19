import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AudioBooksComponent } from './BooksComponents/audio-books/audio-books.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BookTypesComponent } from './BooksComponents/audio-books/book-types/book-types.component';
import { BookByIdComponent } from './BooksComponents/audio-books/book-by-id/book-by-id.component';
import { NewBookDetailAddComponent } from './BooksComponents/audio-books/new-book-detail-add/new-book-detail-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChildComponent } from './BooksComponents/audio-books/child/child.component';
import { RegisterComponent } from './BooksComponents/register/register.component';
import { LoginComponent } from './BooksComponents/login/login.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { UploadImageComponent } from './BooksComponents/Upload-Image/upload-image/upload-image.component';


@NgModule({
  declarations: [
    AppComponent,
    AudioBooksComponent,
    BookTypesComponent,
    BookByIdComponent,
    NewBookDetailAddComponent,
    ChildComponent,
    RegisterComponent,
    LoginComponent,
    UploadImageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    FormsModule,
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
