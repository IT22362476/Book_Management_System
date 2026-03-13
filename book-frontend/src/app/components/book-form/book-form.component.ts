import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.scss']
})
export class BookFormComponent {

  book: Book = {
    title: '',
    author: '',
    isbn: '',
    publicationDate: ''
  };

  constructor(private bookService: BookService) {}

  addBook() {
    this.bookService.addBook(this.book).subscribe(() => {
      alert("Book added!");
      this.book = { title:'', author:'', isbn:'', publicationDate:'' };
    });
  }
}