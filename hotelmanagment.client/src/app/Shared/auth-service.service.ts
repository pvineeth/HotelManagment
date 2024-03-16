import { Injectable } from '@angular/core';
import { jwtDecode } from "jwt-decode";
@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  tokenName = "my_Token_JWT"
  constructor() { }

  set_Auth_Token(token: string) {
    localStorage.setItem(this.tokenName, token)
  }
  get_Auth_Token():string {
    return localStorage.getItem(this.tokenName) ??"";
  }
  RemoveToken():boolean {
    localStorage.removeItem(this.tokenName)
    if (localStorage.getItem(this.tokenName) === null) {
      return true; 
    } else {
      return false; 
    }
  }
  IsLogedIn(): boolean {
    var token = this.get_Auth_Token();
    if (token === "") {
      return false;
    } else {
      return true;
    }
  }

  isAuthenticated(): boolean {
    return this.isTokenExpired(this.get_Auth_Token()) === false;
  }
  isTokenExpired(token: string): boolean {
    try {
      const date = this.getTokenExpirationDate(token);
      if (date === undefined || date === null) return true;
      return !(date.valueOf() > new Date().valueOf());
    }
    catch {
      return true;
    }
  }
  getTokenExpirationDate(token: string): Date | null {
    try {
      const decoded: any = jwtDecode(token);
      if (decoded.exp === undefined || decoded.exp === null) return null;
      const date = new Date(0);
      date.setUTCSeconds(decoded.exp);
      return date;
    }
    catch {
      return null;
    }
  }
}

