import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/studentModel'; 
import { Observable } from 'rxjs';
import { Store, select } from '@ngrx/store';
import * as action from 'src/app/app.counterActions'

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'] 
})
export class ListComponent implements OnInit {

  allStudents: Student[];
  filterList = ''; 
  message$: Observable<any>;

  constructor(private studentService: StudentService,
    private store: Store<{ message: number }>) { 
  }
 
  ngOnInit(): void {
    this.getStudents();
    
  }

  getStudents(): void {
    console.log('listcomponent llamar servicio getAllStudents')

    this.studentService.getAllStudents()
      .subscribe(resp => this.onGetSuccess(resp),
        error => console.error('Error:' + error));
  }

  onGetSuccess(resp: Student[]): void {
    console.log('onGetSuccess: ' + resp);

    this.allStudents = resp;

    var count = this.allStudents.length as number
    
    this.store.dispatch(action.setCount({count: count}))
    this.message$ = this.store.select('message');
    
  }

  deleteStudent(id: number){
    this.studentService.deleteStudent(id).
      subscribe(resp => this.getStudents(), 
        error => console.error('Error:' + error)); 
  }

}
