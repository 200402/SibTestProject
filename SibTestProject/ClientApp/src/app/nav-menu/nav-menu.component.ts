import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public sign_in_or_nothing = "Sign in";
  public sign_up_or_Log_out = "Sign up";
  public sign_in_or_nothing_Link = "Sign in";
  public sign_up_or_Log_out_Link = "Sign up";

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
