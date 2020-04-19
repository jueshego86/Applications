import { Component, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/models/studentModel';
import { FormControl, FormGroup, FormBuilder, FormArray, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css']
})
export class NewComponent implements OnInit {

  formNewStudent: FormGroup;
  selCareer: FormControl = new FormControl();
  editMode: boolean = false;
  title: string = "New Student";

  constructor(private studentService: StudentService, private formBuilder: FormBuilder,
    private router: Router, private activatedRoute: ActivatedRoute) { 

  }

  ngOnInit(): void {
    this.formNewStudent = this.formBuilder.group({
      txtId: [null],
      txtUserName: [null, [Validators.required]],
      txtFirstName: [null, [Validators.required]],
      txtLastName: [null, [Validators.required]],
      txtAge: [null, [Validators.required]]
    });

    this.activatedRoute.params.subscribe(params => {
      var id = params["id"];
      if(id == undefined){
        return;
      }

      this.editMode = true;
      this.title = "Edit Student"

      this.getStudent(id);
    });
  }

  getStudent(id: any) {
    this.studentService.getStudent(id)
        .subscribe(resp => this.loadData(resp),
        error => console.error(error));
  }

  loadData(data: Student) {
    this.formNewStudent.patchValue({
      txtId: data.id,
      txtUserName: data.userName,
      txtFirstName: data.firstName,
      txtLastName: data.lastName,
      txtAge: data.age
    });

    this.selCareer.setValue(data.career);
  }

  onSubmit(formStudentsValue: any){
    const student = new Student();

    student.id = formStudentsValue.txtId;
    student.userName = formStudentsValue.txtUserName;
    student.firstName = formStudentsValue.txtFirstName;
    student.lastName = formStudentsValue.txtLastName;
    student.age = formStudentsValue.txtAge;
    student.career = this.selCareer.value;

    var resp;

    if(this.editMode == false){
      
      console.log('newcomponent llamar servicio addStudentId:' + student.id);

      this.studentService.addStudent(student)
        .subscribe(resp => this.onSaveSuccess(resp),
        error => console.error(error));

      return;
    }

    console.log('newcomponent llamar servicio editStudent:' + student);

    this.studentService.editStudent(student)
      .subscribe(resp => this.onSaveSuccess(resp),
      error => console.error(error));
  }

  onSaveSuccess(resp: number): void {
    console.log('newcomponent respuesta: ' + resp);
    this.router.navigate(["/list"]);
  }
}
