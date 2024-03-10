import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GetAllRolesDTO, RoleClient } from '../Sheared/api-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-editrole',
  templateUrl: './editrole.component.html',
  styleUrl: './editrole.component.css',
  providers:[RoleClient]
})
export class EditroleComponent implements OnInit {

  constructor(private route: ActivatedRoute,private rolrservice:RoleClient,private router :Router) {

  }
  roleName = "";
  userid!: string;
  UserDetails!: GetAllRolesDTO;
  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.userid = params['id']
      console.log(this.userid);
    })
    this.getrole();
  }
  getrole() {
    this.rolrservice.getRoleById(this.userid).subscribe(x => {
      this.UserDetails = x;
    });
  }
  updaterole() {
    this.rolrservice.updateRole(this.UserDetails).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "Role Updated successful.",
          icon: 'success',
         
          allowOutsideClick: false,
          iconColor: '#2db983',
          confirmButtonColor: '#2db983',
         
        }).then((result) => {
          if (result.isConfirmed) {
            this.router.navigate(["/role"])
          }
          else {
            this.router.navigate(["/role"])
          }
        });
      }
      else {

      }
    });
  }
}
