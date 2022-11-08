import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public sign_in_or_log_out = "Войти";
  public sign_up_or_nothing = "Зарегистрироваться";
  public user_name = "SibTestProject";

  isExpanded = false;

  constructor() {
    this.status();
  }
  deletec() {
    this.setCookie('Token', '', 0);
    this.status();
  }

  status() {
    if (this.getCookie("Token") == undefined) {
      this.sign_in_or_log_out = "Войти"
      this.sign_up_or_nothing = "Зарегистрироваться"
      this.user_name = "SibTestProject"
    }
    else {
      this.sign_in_or_log_out = "Сменить аккаунт"
      this.sign_up_or_nothing = ""
      var login = this.getCookie("login")
      if (login != undefined)
        this.user_name = login
    }
  }

  private getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }
  setCookie(cname: string, cvalue: string, exMins: number) {
    var d = new Date();
    d.setTime(d.getTime() + (exMins * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
  } //TODO вынести работу с куки в отдельный класс ВЭСДЭ
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
