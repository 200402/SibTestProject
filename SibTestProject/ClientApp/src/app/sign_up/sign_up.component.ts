import { Component } from '@angular/core';

@Component({
  selector: 'app-sign_up',
  templateUrl: './sign_up.component.html',
  styleUrls: ['./sign_up.component.css']
})
export class Sign_UpComponent {

  //if(false) {
  //  window.location.href = 'URL2';
  //}

  public pass() {
    location.reload();
  }
}
