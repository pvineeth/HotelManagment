import { Component, OnInit } from '@angular/core';
import { GetAllRolesDTOPaginationEntityDto, RoleClient } from '../Shared/api-service.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-get-all-rols',
  templateUrl: './get-all-rols.component.html',
  styleUrl: './get-all-rols.component.css',
  providers: [RoleClient]
})
export class GetALlRolsComponent implements OnInit {

  roleData !: GetAllRolesDTOPaginationEntityDto
  constructor(private roleService:RoleClient,private router:Router) {

  }
    ngOnInit(): void {
      this.GetAllRols();
      
    }


  GetAllRols() {
    this.roleService.getAllRoles(0,10).subscribe(x => {
      this.roleData = x;
    })
  }
  DeleteRole(Id: any) {


    this.roleService.deleteRole(Id.toString()).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "Role added successful.",
          icon: 'success',
          iconHtml: ' <img  src="../../assets/Images/trash-bin.gif" alt="Success" width="100" height="100" /> ',
          allowOutsideClick: false,
          confirmButtonColor: '#2db983',
        }).then((result) => {
          if (result.isConfirmed) {
            this.GetAllRols();
          }
          else {
            this.router.navigate(["/role"])
          }
        });
      }
      else {
        Swal.fire({
          title: 'Error!',
          text: "Role Not Delete.",
          icon: 'error',
          allowOutsideClick: false,
        }).then((result) => {
          if (result.isConfirmed) {
            this.router.navigate(["/user"])
          }
          else {
            this.router.navigate(["/role"])
          }
        });
      }
    })
  }



}
