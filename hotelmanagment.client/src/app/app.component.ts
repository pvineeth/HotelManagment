import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthServiceService } from './Shared/auth-service.service';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient, private authService: AuthServiceService) {}

  IsVisable !: boolean;
  ngOnInit() {
    this.IsVisable = false;
    //this.VerifingToken();
  }

  VerifingToken() {
    this.IsVisable = this.authService.IsLogedIn();
  }

  public get ishide() {
    return this.authService.IsLogedIn();
  }


  

  
}
