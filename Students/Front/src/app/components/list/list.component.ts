import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/studentModel'; 

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css'] 
})
export class ListComponent implements OnInit {

  allStudents: Student[];
  filterList = ''; 

  constructor(private studentService: StudentService) { 
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
  }

  editStudent(student: Student){
    
  }

  deleteStudent(id: number){
    this.studentService.deleteStudent(id).
      subscribe(resp => this.getStudents(), 
        error => console.error('Error:' + error)); 
  }

}
