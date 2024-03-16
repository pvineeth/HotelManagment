import { Component, OnInit } from '@angular/core';
import { GetAllHostelDTO, HostelClient } from '../../Shared/api-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-updatehostel',
  templateUrl: './updatehostel.component.html',
  styleUrl: './updatehostel.component.css',
  providers: [HostelClient]
})
export class UpdatehostelComponent implements OnInit {

  hostelId!: string;
  HostelName!: string;
  constructor(private hostelService: HostelClient, private router: Router, private route: ActivatedRoute) {

  }
  ngOnInit() {
    this.route.params.subscribe((params) => {
      this.hostelId = params['id']
    })
    this.GetBuHostelId();
  }

  GetBuHostelId() {
    this.hostelService.getHostelById(this.hostelId).subscribe(x => {
      this.HostelName = x.hostelName??"";
    })
  }

  UpdateHostel() {
    var hostelDetails = new GetAllHostelDTO();
    hostelDetails.pkHostelId = this.hostelId;
    hostelDetails.hostelName = this.HostelName;
    this.hostelService.updateHostel(hostelDetails).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "Hostel Updated successful.",
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
