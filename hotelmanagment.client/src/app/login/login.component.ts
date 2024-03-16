import { Component, OnInit } from '@angular/core';
import { AuthenticationClient, LoginDTO } from '../Shared/api-service.service';
import Swal from 'sweetalert2';
import { AuthServiceService } from '../Shared/auth-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  providers: [AuthenticationClient]
})
export class LoginComponent implements OnInit {
  UserName!: string;
  Password!: string;
  LoginDetails !:LoginDTO;

  constructor(private router:Router,private LoginService: AuthenticationClient,private authServices: AuthServiceService) {

  }
  ngOnInit(): void {
    if (this.authServices.isAuthenticated()) {
      this.router.navigate(['/name']);
      return
    }

   this.LoginDetails = new LoginDTO;
  }

  loginfunction() {
    this.LoginDetails.userMail = this.UserName;
    this.LoginDetails.password = this.Password;
    this.LoginService.login(this.LoginDetails).subscribe(x => {
      if (x.success && x.token != null) {
        this.authServices.set_Auth_Token(x.token);
        //Swal.fire({
        //  title: 'Success!',
        //  text: "Your action was successful.",
        //  icon: 'success',
        //  allowOutsideClick: false,
        //}).then();
        this.router.navigate(["/User"])
      }
      else {
        Swal.fire("Error", x.errorMessage?.toString(), "error");
      }
    }, (error) => {
      if (error.status === 400) {
        Swal.fire("Error", "Bad Request. Please check your credentials and try again.", "error");
      }
      else {
        Swal.fire("Error", "An error occurred. Please try again later.", "error");
      }
    });
  }



}
