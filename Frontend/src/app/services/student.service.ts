import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private apiUrl = 'https://localhost:7059/api/Student';

  constructor(private http: HttpClient) {}

  getAllStudents(pageIndex: number, pageSize: number): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const url = `${this.apiUrl}/GetAllStudents?pageIndex=${pageIndex}&pageSize=${pageSize}`;
    return this.http.get<any>(url, { headers });
  }

  deleteStudent(studentId: number): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const url = `${this.apiUrl}/DeleteStudent/${studentId}`;
    return this.http.delete<any>(url, { headers });
  }

  updateStudent(studentId: number, student: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const url = `${this.apiUrl}/UpdateStudent/${studentId}`;
    console.log('Sending PUT request to URL:', url, 'with data:', student); // Log the request details
    return this.http.put<any>(url, student, { headers });
  }

  addStudent(student: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    const url = `${this.apiUrl}/AddStudent`;
    return this.http.post<any>(url, student, { headers });
  }

  searchStudentsByFilter(params: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);

    let url = `${this.apiUrl}/SearchStudentsByFilter?fullName=${params.fullName}&country=${params.country}&gender=${params.gender}&pageIndex=${params.pageIndex}&pageSize=${params.pageSize}`;

    if (params.minAge !== undefined) {
      url += `&minAge=${params.minAge}`;
    }

    if (params.maxAge !== undefined) {
      url += `&maxAge=${params.maxAge}`;
    }

    console.log('Sending GET request to URL:', url);
    return this.http.get<any>(url, { headers });
  }
}
