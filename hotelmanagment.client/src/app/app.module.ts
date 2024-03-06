import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import {  RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { GetUsersComponent } from './Users/get-users/get-users.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { GetALlRolsComponent } from './get-all-rols/get-all-rols.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { GetalltenantsComponent } from './Tenants/getalltenants/getalltenants.component';
import { GetallroomsComponent } from './Rooms/getallrooms/getallrooms.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavMenuComponent,
    GetUsersComponent,
    GetALlRolsComponent,
    DashboardComponent,
    GetalltenantsComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      {path:'login',component: LoginComponent},
      {path:'role',component: GetALlRolsComponent},
      {path:'home',component: DashboardComponent},
      {path:'tenants',component: GetalltenantsComponent},
      {path:'rooms',component: GetallroomsComponent},
      {path:'',component: GetUsersComponent},
      {path:'**',component: GetUsersComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
