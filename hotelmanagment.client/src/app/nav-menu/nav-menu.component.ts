import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../Sheared/auth-service.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrl: './nav-menu.component.css'
})
export class NavMenuComponent implements OnInit {


  constructor(private authService: AuthServiceService) { }
    ngOnInit(): void {
        
  }

  LogOut() {
    this.authService.RemoveToken();
  }

}
