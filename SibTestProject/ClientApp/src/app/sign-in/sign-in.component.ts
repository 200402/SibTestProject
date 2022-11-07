import { Component, ElementRef, Inject, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Md5 } from 'ts-md5';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class Sign_InComponent {
  @ViewChild("login") loclog: ElementRef;
  @ViewChild("password") locpas: ElementRef;
  public warning = "white";
  public http: HttpClient;
  public username = "";


  public sign_in() {
    var base_url = window.location.origin;
    console.log(base_url + '/api/signIn/' + this.loclog.nativeElement.value + '/' + Md5.hashStr(this.locpas.nativeElement.value));
    this.http.get<UserToken>(base_url + '/api/signIn/' + this.loclog.nativeElement.value + '/' + Md5.hashStr(this.locpas.nativeElement.value)).subscribe(result => {
      document.cookie = 'Token=' + result.token;
      window.location.href = 'https://localhost:44455/storage';
      location.reload();
    }, error => {
      this.warning = "red";
      console.error(error);
    });
  }
  constructor(http: HttpClient) {
    this.http = http;
    if (this.getCookie("Token") != undefined)
      window.location.href = 'https://localhost:44455/storage';
  }

  private getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }
}

class UserToken {
  token: string;
}
