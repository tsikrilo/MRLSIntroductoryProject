import { Injectable } from '@angular/core';
import { IUserDetail } from '../models/user-detail.model';
import { HttpClient } from '@angular/common/http';
import { IUserTitle } from '../models/user-title.model';
import { IUserType } from '../models/user-type.model';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  postUserDetail(userDetail: IUserDetail) {
    userDetail.UserTitleId = +userDetail.UserTitleId;
    userDetail.UserTypeId = +userDetail.UserTypeId;
    return this.http.post(`${environment.baseUrl}/Users`, userDetail);
  }


  putUserDetail(userDetail: IUserDetail) {
    userDetail.UserTitleId = +userDetail.UserTitleId;
    userDetail.UserTypeId = +userDetail.UserTypeId;
    return this.http.put(`${environment.baseUrl}/Users/${userDetail.Id}`, userDetail);
  }

  deleteUserDetail(userId: number) {
    return this.http.delete(`${environment.baseUrl}/Users/${userId}`);
  }

  getUserList(): Observable<IUserDetail[] | undefined> {
    return this.http.get<IUserDetail[]>(`${environment.baseUrl}/Users`);
  }

  getUser(userId: number): Observable<IUserDetail | undefined> {
    return this.http.get<IUserDetail>(`${environment.baseUrl}/Users/${userId}`);
  }

  getUserTitleList(): Observable<IUserTitle[] | undefined> {
    return this.http.get<IUserTitle[]>(`${environment.baseUrl}/UserTitles`);
  }

  getUserTypeList(): Observable<IUserType[] | undefined> {
    return this.http.get<IUserType[]>(`${environment.baseUrl}/UserTypes`);
  }
}
