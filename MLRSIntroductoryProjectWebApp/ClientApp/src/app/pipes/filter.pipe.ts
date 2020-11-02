import { Pipe, PipeTransform } from '@angular/core';
import { IUserDetail } from '../models/user-detail.model';

@Pipe({ name: 'fullnameFilter' })
export class FilterPipe implements PipeTransform {

  transform(userDetails: IUserDetail[], searchText: string): IUserDetail[] {
    if (!userDetails) {
      return [];
    }
    if (!searchText) {
      return userDetails;
    }
    searchText = searchText ? searchText.toLocaleLowerCase() : null;

    return searchText ? userDetails.filter((userDetail: IUserDetail) =>
      userDetail.Name.toLocaleLowerCase().indexOf(searchText) !== -1 ||
      userDetail.Surname.toLocaleLowerCase().indexOf(searchText) !== -1) : userDetails;
  }
}
