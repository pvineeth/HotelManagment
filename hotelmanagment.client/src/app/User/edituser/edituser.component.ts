import { Component, OnInit } from '@angular/core';
import { AddUserDTO, GetAllRolesDTO, GetAllUserDTO, RoleClient, UserClient } from '../../Sheared/api-service.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-edituser',
  templateUrl: './edituser.component.html',
  styleUrl: './edituser.component.css',
  providers: [UserClient, RoleClient]
})
export class EdituserComponent implements OnInit {

  roleId = "0";
  Username = "";
  EmailId = "";
  Password = "";
  MbNumber = "";
  PKUserId = "";
  userid!: string;
  UserDetials!: GetAllUserDTO;
  RoleNames!: GetAllRolesDTO[];
  constructor(private userService: UserClient, private route: ActivatedRoute, private roleService: RoleClient, private router: Router) {
    
  }
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.userid = params['id']
    })
    this.GetUserById();
  }

  getALlRoleNames() {
    this.roleService.getAllRoleName().subscribe(x => {
      this.RoleNames = x;
    })
  }


  GetUserById() {

    this.userService.getuserById(this.userid).subscribe(x => {
      this.UserDetials = x;
      this.Username = this.UserDetials.userName??"";
      this.EmailId = this.UserDetials.emailID??"";
      this.Password = this.UserDetials.password??"";
      this.MbNumber = this.UserDetials.mobileNUmber ?? "";
      this.roleId = this.UserDetials.fkroleId ?? "";
      this.PKUserId = this.UserDetials.pkUserProfileId ?? "";
      this.getALlRoleNames();
    })
  }

  AddUser() {
    var userDetails = new GetAllUserDTO();
    userDetails.userName = this.Username;
    userDetails.emailID = this.EmailId;
    userDetails.password = this.Password;
    userDetails.mobileNUmber = this.MbNumber;
    userDetails.fkroleId = this.roleId;
    userDetails.pkUserProfileId = this.userid;
    userDetails.createdDate = new Date();
    userDetails.roleName = "";
    this.userService.updateUser(userDetails).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "User updated successful.",
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
      else {
        Swal.fire({
          title: 'error!',
          text: "Error.",
          icon: 'error',
          allowOutsideClick: false,
          confirmButtonColor: '#2db983',
        }).then((result) => {
          if (result.isConfirmed) {
            this.router.navigate(["/"])
          }
          else {
            this.router.navigate(["/"])
          }
        });
      }
    });
  }


}
