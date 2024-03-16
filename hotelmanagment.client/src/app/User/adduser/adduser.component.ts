import { Component, OnInit } from '@angular/core';
import { AddUserDTO, GetAllRolesDTO, RoleClient, UserClient } from '../../Shared/api-service.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adduser',
  templateUrl: './adduser.component.html',
  styleUrl: './adduser.component.css',
  providers: [RoleClient, UserClient]
})
export class AdduserComponent implements OnInit {
  RoleNames!: GetAllRolesDTO[];
  userDetails!: AddUserDTO;
  roleId = "0";
  Username = "";
  EmailId = "";
  Password = "";
  MbNumber = "";
  constructor(private roleService: RoleClient,private userService:UserClient,private router:Router) {

  }
  ngOnInit(): void {
    this.getALlRoleNames();
    console.log(this.roleId);
  }
  getALlRoleNames() {
    this.roleService.getAllRoleName().subscribe(x => {
      this.RoleNames = x;
    })
  }

  AddUser() {
    var userDetails = new AddUserDTO();
    userDetails.userName = this.Username;
    userDetails.emailID = this.EmailId;
    userDetails.password = this.Password;
    userDetails.mobileNUmber = this.MbNumber;
    userDetails.fkRoleId = this.roleId;
    this.userService.addUser(userDetails).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "User added successful.",
          icon: 'success',
          allowOutsideClick: false,
          confirmButtonColor: '#2db983',
        }).then((result) => {
          if (result.isConfirmed) {
            this.router.navigate(["/users"])
          }
          else {
            this.router.navigate(["/users"])
          }
        });
      }
    });
  }

}
