import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Md5 } from 'ts-md5';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class Sign_UpComponent {
  @ViewChild("login") loclog: ElementRef;
  @ViewChild("password") locpas: ElementRef;
  public http: HttpClient;

  public sign_up() {
    var base_url = window.location.origin;
    console.log(base_url + '/api/signUp/' + this.loclog.nativeElement.value + '/' + Md5.hashStr(this.locpas.nativeElement.value));
    this.http.get<UserToken>(base_url + '/api/signUp/' + this.loclog.nativeElement.value + '/' + Md5.hashStr(this.locpas.nativeElement.value)).subscribe(result => {
      document.cookie = 'Token=' + result.token
      window.location.href = 'https://localhost:44455/storage';
    }, error => {
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

interface UserToken {
  token: string;
}
