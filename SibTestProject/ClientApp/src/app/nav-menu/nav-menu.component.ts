import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public sign_in_or_nothing = "Войти";
  public sign_up_or_Log_out = "Зарегистрироваться";

  constructor() {
    if (this.getCookie("Token") != undefined) {
      this.sign_in_or_nothing = "";
      this.sign_up_or_Log_out = "Сменить аккаунт";
    }
    else {
      this.sign_in_or_nothing = "Войти";
      this.sign_up_or_Log_out = "Зарегистрироваться";
    }
  }

  public delete_cookie() {
    document.cookie = 'Token=; Max-Age=0'
    window.location.href = 'https://localhost:44455';
  }

  private getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
