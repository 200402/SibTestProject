import { Component } from '@angular/core';

@Component({
  selector: 'app-storage',
  templateUrl: './storage.component.html'
})
export class StorageComponent {

  private getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }
} 
