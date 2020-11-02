import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { IUserDetail } from '../models/user-detail.model';
import { IUserTitle } from '../models/user-title.model';
import { IUserType } from '../models/user-type.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './users.component.html',
  styles: []
})

export class UsersComponent implements OnInit {

  constructor(public userService: UserService,
    private router: Router,
    private route: ActivatedRoute) { }

  pageTitle = "User List";
  users: IUserDetail[];
  errorMessage: string;
  userTitleList: IUserTitle[];
  userTypeList: IUserType[];

  ngOnInit(): void {
    this.userService.getUserTitleList().subscribe({
      next: userTitles => {
        this.userTitleList = userTitles
      },
      error: err => this.errorMessage = err
    });

    this.userService.getUserTypeList().subscribe({
      next: userTypes => {
        this.userTypeList = userTypes
      },
      error: err => this.errorMessage = err
    });
    this.userService.getUserList().subscribe({
      next: users => {
        this.users = users;
      },
      error: err => this.errorMessage = err
    });
  }

  onDelete(Id: number) {
    if (confirm('Are you sure to delete this user?')) {
      this.userService.deleteUserDetail(Id)
        .subscribe(res => {
          location.reload();
        },
          error => { console.log(error); })
    }
  }

  createNewUser() {
    this.router.navigateByUrl('/users/0');
  }

}
