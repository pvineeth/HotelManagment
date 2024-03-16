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
import { AddroleComponent } from './addrole/addrole.component';
import { AdduserComponent } from './User/adduser/adduser.component';
import { EditroleComponent } from './editrole/editrole.component';
import { EdituserComponent } from './User/edituser/edituser.component';
import { GetallhostelsComponent } from './Hostel/getallhostels/getallhostels.component';
import { AddnewhostelComponent } from './Hostel/addnewhostel/addnewhostel.component';
import { UpdatehostelComponent } from './Hostel/updatehostel/updatehostel.component';



@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavMenuComponent,
    GetUsersComponent,
    GetALlRolsComponent,
    DashboardComponent,
    GetalltenantsComponent,
    AddroleComponent,
    AdduserComponent,
    EditroleComponent,
    EdituserComponent,
    GetallhostelsComponent,
    AddnewhostelComponent,
    UpdatehostelComponent
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
      {path:'addrole',component: AddroleComponent},
      {path:'hostels',component: GetallhostelsComponent},
      {path:'addhostel',component: AddnewhostelComponent},
      {path:'edithostel/:id',component: UpdatehostelComponent},
      {path:'adduser',component: AdduserComponent},
      {path:'edituser/:id',component: EdituserComponent},
      {path:'users',component: GetUsersComponent},
      {path:'editrole/:id',component: EditroleComponent},
      {path:'',component: GetUsersComponent},
      {path:'**',component: GetUsersComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
