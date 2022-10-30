import { Component } from '@angular/core';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class Sign_UpComponent {

  //if(false) {
  //  window.location.href = 'URL2';
  //}

  public pass() {
    location.reload();
  }
}
