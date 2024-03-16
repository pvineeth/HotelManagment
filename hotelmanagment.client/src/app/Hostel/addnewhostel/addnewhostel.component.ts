import { Component, Host, OnInit } from '@angular/core';
import { AddNewHostelDTO, HostelClient } from '../../Shared/api-service.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addnewhostel',
  templateUrl: './addnewhostel.component.html',
  styleUrl: './addnewhostel.component.css',
  providers: [HostelClient]
})
export class AddnewhostelComponent implements OnInit {

  newHostel!: string;
  constructor(private hostelService: HostelClient, private router: Router) {

  }
  ngOnInit() { }

  addHostel() {
    var Newhosteldetails = new AddNewHostelDTO();
    Newhosteldetails.hostelName = this.newHostel;
    this.hostelService.addNewHostel(Newhosteldetails).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "Hostel added successful.",
          icon: 'success',
          confirmButtonColor: '#2db983',
          allowOutsideClick: false,
        }).then((result) => {
          this.router.navigate(["/hostels"])
        });
      }
      else {
        Swal.fire("Error", x.errorMessage?.toString(), "error");
      }
    })
  }
}
