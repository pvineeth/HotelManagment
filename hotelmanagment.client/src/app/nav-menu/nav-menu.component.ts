import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from '../Sheared/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrl: './nav-menu.component.css'
})
export class NavMenuComponent implements OnInit {


  constructor(private authService: AuthServiceService,private router:Router) { }
    ngOnInit(): void {
        
  }

  LogOut() {
    this.authService.RemoveToken();
    this.router.navigate(['/login']);
  }

}
