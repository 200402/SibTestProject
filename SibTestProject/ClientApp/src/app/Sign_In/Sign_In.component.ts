import { Component } from '@angular/core';

@Component({
  selector: 'app-sign_in',
  templateUrl: './sign_in.component.html',
  styleUrls: ['./sign_in.component.css']
})
export class Sign_InComponent {

  //if(false) {
  //  window.location.href = 'URL2';
  //}

  public pass() {
    location.reload();
  }
}
