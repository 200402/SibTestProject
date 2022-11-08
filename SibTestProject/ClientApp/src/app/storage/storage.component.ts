import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-storage',
  templateUrl: './storage.component.html',
  styleUrls: ['./storage.component.css']
})
export class StorageComponent {
  public stroka: string | undefined;
  public http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
    this.stroka = this.getCookie("Token");
    document.addEventListener('contextmenu', event => {
      event.preventDefault();
      console.log(123);
    }); 
  }



  private getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }

  get_request(URL_string: string) {
    var base_url = window.location.origin;
    this.http.get(base_url + '/' + URL_string).subscribe(result => {
      return result;
    }, error => {
      console.error(error);
    });
  }
} 

