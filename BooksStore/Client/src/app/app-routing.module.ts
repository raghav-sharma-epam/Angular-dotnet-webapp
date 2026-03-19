import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AudioBooksComponent } from './BooksComponents/audio-books/audio-books.component';
import { BookByIdComponent } from './BooksComponents/audio-books/book-by-id/book-by-id.component';
import { BookTypesComponent } from './BooksComponents/audio-books/book-types/book-types.component';
import { NewBookDetailAddComponent } from './BooksComponents/audio-books/new-book-detail-add/new-book-detail-add.component';
import { LoginComponent } from './BooksComponents/login/login.component';
import { RegisterComponent } from './BooksComponents/register/register.component';
import { AuthGuard } from './Guards/auth.guard';
import { UploadImageComponent } from './BooksComponents/Upload-Image/upload-image/upload-image.component';

const routes: Routes = [
  {path:'audiobooks', component: AudioBooksComponent, canActivate : [AuthGuard]},
  {path:'BookTypes', component: BookTypesComponent,canActivate : [AuthGuard]},
  {path:'BookById/:id',component:BookByIdComponent},
  {path:'bookDetailAdd',component:NewBookDetailAddComponent},
  {path:'register',component: RegisterComponent},
   {path:'login',component: LoginComponent},
   {path:'upload', component:UploadImageComponent}


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
