import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  countStudents$: Observable<any>;

  constructor(private store: Store<{ countStudents: number }>) {

   }

  ngOnInit(): void {
    this.countStudents$ = this.store.select('countStudents');
  }

}
