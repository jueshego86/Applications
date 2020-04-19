import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/studentModel';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  allStudents: Student[];

  constructor(private studentService: StudentService) { 
  }
 
  ngOnInit(): void {
    this.getStudents();
  }
  onGetSuccess(resp: Student[]): void {
    console.log('onGetSuccess: ' + resp);

    this.allStudents = resp;
  }

  getStudents(): void {
    console.log('listcomponent llamar servicio getAllStudents')

    this.studentService.getAllStudents()
      .subscribe(resp => this.onGetSuccess(resp),
        error => console.error('Error:' + error));
  }

  editStudent(student: Student){
    
  }

  deleteStudent(id: number){
    this.studentService.deleteStudent(id).
      subscribe(resp => this.getStudents(), 
        error => console.error('Error:' + error)); 
  }

}
