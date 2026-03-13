import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../models/book';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

  books: Book[] = [];

  editId: number | null = null;

  constructor(private bookService: BookService) { }

  ngOnInit(): void {
    this.loadBooks();

    this.bookService.RefreshRequired.subscribe(() => {
      this.loadBooks();
    });
  }

  loadBooks() {
    this.bookService.getBooks().subscribe(data => {
      this.books = data;
    });
  }

  deleteBook(id: number) {
    this.bookService.deleteBook(id).subscribe(() => {
      this.loadBooks();
    });
  }

  startEdit(id: number) {
    this.editId = id;
  }

  updateBook(book: any) {
    this.bookService.updateBook(book.id, book).subscribe(() => {
      this.editId = null;
      this.loadBooks();
    });
  }
}