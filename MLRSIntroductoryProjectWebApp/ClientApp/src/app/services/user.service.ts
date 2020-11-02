import { Injectable } from '@angular/core';
import { IUserDetail } from '../models/user-detail.model';
import { HttpClient } from '@angular/common/http';
import { IUserTitle } from '../models/user-title.model';
import { IUserType } from '../models/user-type.model';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  postUserDetail(userDetail: IUserDetail) {
    userDetail.UserTitleId = +userDetail.UserTitleId;
    userDetail.UserTypeId = +userDetail.UserTypeId;
    return this.http.post(`${environment.baseUrl}/Users`, userDetail).pipe(
      catchError(err => {
        console.log('Error creating user', err);
        return throwError(err);
      })
    );
  }


  putUserDetail(userDetail: IUserDetail) {
    userDetail.UserTitleId = +userDetail.UserTitleId;
    userDetail.UserTypeId = +userDetail.UserTypeId;
    return this.http.put(`${environment.baseUrl}/Users/${userDetail.Id}`, userDetail).pipe(
      catchError(err => {
        console.log('Error editing user', err);
        return throwError(err);
      })
    );
  }

  deleteUserDetail(userId: number) {
    return this.http.delete(`${environment.baseUrl}/Users/${userId}`).pipe(
      catchError(err => {
        console.log('Error deleting user', err);
        return throwError(err);
      })
    );
  }

  getUserList(): Observable<IUserDetail[] | undefined> {
    return this.http.get<IUserDetail[]>(`${environment.baseUrl}/Users`).pipe(
      catchError(err => {
        console.log('Error retrieving users list', err);
        return throwError(err);
      })
    );
  }

  getUser(userId: number): Observable<IUserDetail | undefined>{
    return this.http.get<IUserDetail>(`${environment.baseUrl}/Users/${userId}`).pipe(
      catchError(err => {
        console.log('Error retrieving user data', err);
        return throwError(err);
      })
    );
  }

  getUserTitleList(): Observable<IUserTitle[] | undefined>{
    return this.http.get<IUserTitle[]>(`${environment.baseUrl}/UserTitles`).pipe(
      catchError(err => {
        console.log('Error retrieving user title list', err);
        return throwError(err);
      })
    );
  }

  getUserTypeList(): Observable<IUserType[] | undefined >{
    return this.http.get<IUserType[]>(`${environment.baseUrl}/UserTypes`).pipe(
      catchError(err => {
        console.log('Error retrieving user type list', err);
        return throwError(err);
      })
    );
  }
}
