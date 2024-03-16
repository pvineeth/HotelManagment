import { Component, OnInit } from '@angular/core';
import { GetAllHostelDTO, HostelClient } from '../../Shared/api-service.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-getallhostels',
  templateUrl: './getallhostels.component.html',
  styleUrl: './getallhostels.component.css',
  providers: [HostelClient]
})
export class GetallhostelsComponent implements OnInit {

  hostelsList!: GetAllHostelDTO[]
  constructor(private hotelService:HostelClient,private router:Router) {

  }
    ngOnInit(): void {
      this.GetAllHostels();
  }


  GetAllHostels() {
    this.hotelService.getAllHostels(0,10).subscribe(x => {
      this.hostelsList=x.entities??[]
    })
  }

  DeleteHostel(hostelId:any) {
    this.hotelService.deleteHostel(hostelId).subscribe(x => {
      if (x.success) {
        Swal.fire({
          title: 'Success!',
          text: "Hostel deleted successful.",
          icon: 'success',
          confirmButtonColor: '#2db983',
          allowOutsideClick: false,
        }).then((result) => {
          this.GetAllHostels();
        });
      }
      else {

      }
    })
  }

}
