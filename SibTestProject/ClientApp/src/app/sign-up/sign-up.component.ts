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
  @ViewChild("passwordTest") locpast: ElementRef;
  public http: HttpClient;
  public warning_color: string;
  public warning_text: string;

  public sign_up() { //TODO раскидать это на функции
    if (this.locpas.nativeElement.value == this.locpast.nativeElement.value) {
      var base_url = window.location.origin;
      this.http.get<UserInfo>(base_url + '/api/getByLogin/' + this.loclog.nativeElement.value).subscribe(result => {
        if (result.login == 'nothing') {
          base_url = window.location.origin;
          console.log(base_url + '/api/signUp/' + this.loclog.nativeElement.value + '/' + Md5.hashStr(this.locpas.nativeElement.value));
          this.http.get<UserToken>(base_url + '/api/signUp/' + this.loclog.nativeElement.value + '/' + Md5.hashStr(this.locpas.nativeElement.value)).subscribe(result => {
            document.cookie = 'Token=' + result.token
            window.location.href = 'https://localhost:44455/storage';
          }, error => {
            console.error(error);
          });
        }
        else {
          this.warning_color = "red"
          this.warning_text = "Логин занят";
        }
      }, error => {
        console.error(error);
      });
    }
    else {
      this.warning_color = "red"
      this.warning_text = "Пароли не совпадают";
    }
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
interface UserInfo {
  login: string;
}
