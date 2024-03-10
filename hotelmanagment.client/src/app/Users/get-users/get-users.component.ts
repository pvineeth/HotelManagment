import { Component, OnInit } from '@angular/core';
import { GetAllRolesDTO, GetAllUserDTOPaginationEntityDto, RoleClient, UserClient } from '../../Sheared/api-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-get-users',
  templateUrl: './get-users.component.html',
  styleUrl: './get-users.component.css',
  providers:[UserClient]
})
export class GetUsersComponent implements OnInit {

  users!: GetAllUserDTOPaginationEntityDto;
 
  constructor(private userService:UserClient,) {

  }
  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers() {
    this.userService.getAllUsers(0,10).subscribe(x => {
      this.users = x;
      
    })
  }

  DeleteUser(id: any) {
    this.userService.deleteUser(id).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "User Deleted successful.",
          icon: 'success',
          allowOutsideClick: false,
          confirmButtonColor: '#2db983',
        }).then((result) => {
          if (result.isConfirmed) {
            this.getAllUsers();
          }
          else {
            
          }
        });
      }
    })
  }
  

}
