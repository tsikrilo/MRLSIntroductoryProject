import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IUserTitle } from '../models/user-title.model';
import { IUserType } from '../models/user-type.model';
import { IUserDetail } from '../models/user-detail.model';

@Component({
  selector: 'app-user-detail-form',
  templateUrl: './user-detail.component.html',
  styles: [
  ]
})
export class UserDetailsComponent implements OnInit {
  form: NgForm;
  userId: number;
  userModel: IUserDetail | undefined;
  users: IUserDetail[];
  userTitleList: IUserTitle[];
  userTypeList: IUserType[];
  pageTitle = 'User Details';

  loading: boolean = false;
  errorMessage;

  constructor(public userDetailService: UserService,
    private router: Router,
    private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.userId = +this.route.snapshot.paramMap.get('id');
    if (this.userId == 0) { this.resetForm(); }
    this.userDetailService.getUser(this.userId).subscribe({
      next: users => {
        this.userModel = users;
      },
      error: err => this.errorMessage = err
    });

    this.userDetailService.getUserTitleList().subscribe({
      next: userTitles => {
        this.userTitleList = userTitles
      },
      error: err => this.errorMessage = err
    });

    this.userDetailService.getUserTypeList().subscribe({
      next: userTypes => {
        this.userTypeList = userTypes
      },
      error: err => this.errorMessage = err
    });

    this.userDetailService.getUserList().subscribe({
      next: users => {
        this.users = users;
      },
      error: err => this.errorMessage = err
    });
  }

  onSubmit(form: NgForm) {
    if (this.userModel.Id == 0) {
      this.registerUser(form);
    } else {
      this.updateUserDetails(form);
    }
    form.form.reset();
  }

  resetForm() {
    this.userModel = {
      Id: 0,
      Name: '',
      Surname: '',
      Birthdate: new Date,
      UserTitleId: 0,
      UserTypeId: 0,
      EmailAddress: '',
      IsActive: true
    }
  }

  registerUser(form: NgForm) {
    this.userDetailService.postUserDetail(this.userModel).subscribe(
      res => {
        this.router.navigate(['/users']);
      },
      err => { console.log(err); }
    )
  }

  updateUserDetails(form: NgForm) {
    this.userDetailService.putUserDetail(this.userModel).subscribe(
      res => {
        this.router.navigateByUrl('/users');
      },
      err => {
        console.log(err);
      }
    )
  }
}
