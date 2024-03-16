import { Component, OnInit } from '@angular/core';
import { AddRoleDTO, RoleClient } from '../Shared/api-service.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addrole',
  templateUrl: './addrole.component.html',
  styleUrl: './addrole.component.css',
  providers:[RoleClient]
})
export class AddroleComponent implements OnInit {

  userDetails!: AddRoleDTO;
  roleName = "";
  response!: any;
  constructor(private roleService:RoleClient,private router:Router) {

  }
    ngOnInit(): void {
        
  }

  addRole() {
    this.userDetails = new AddRoleDTO();
    this.userDetails.roleName=this.roleName
    this.roleService.addRole(this.userDetails).subscribe(x => {
      this.response = x;
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "Role added successful.",
          icon: 'success',
          confirmButtonColor: '#2db983',
          allowOutsideClick: false,
        }).then((result)=> {
          if (result.isConfirmed) {
            this.router.navigate(["/role"])
          }
          else {
            this.router.navigate(["/addrole"])
          }
        });
      }
    });
  }

}
