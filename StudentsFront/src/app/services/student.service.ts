import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Student } from '../models/studentModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }
  
  private baseUrl = 'http://localhost:60385/api/student';

  getAllStudents(): Observable<Student[]> {
    var resp = this.http.get<Student[]>(this.baseUrl);

    console.log(resp);

    return resp;
  }

  getStudent(id: number): Observable<Student> {
    return this.http.get<Student>(this.baseUrl + '/' + id);
  }

  addStudent(student: Student): Observable<number> {
    student.id = 0;
    return this.http.post<number>(this.baseUrl, student);
  }

  editStudent(student: Student): Observable<number> {
    return this.http.put<number>(this.baseUrl + '/' + student.id, student);
  }

  deleteStudent(id: number): Observable<number> {
    return this.http.delete<number>(this.baseUrl + '/' + id);
  }
}
