import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, Inject, ViewChild } from '@angular/core';


@Component({
  selector: 'app-storage',
  templateUrl: './storage.component.html',
  styleUrls: ['./storage.component.css']
})
export class StorageComponent {
  public MyObjects: MyObject[] = [];
  public stroka: string | undefined;
  public http: HttpClient;
  public mouseCoordinate: position = new position;
  @ViewChild("MyContextMenu", { static: true }) MyCM: ElementRef;
  @ViewChild("MyContextMenuFile", { static: true }) MyCMFile: ElementRef;
  @ViewChild("InteractiveTBody", { static: true }) InterTbody: ElementRef;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    document.addEventListener("contextmenu", event => event.preventDefault());
    document.addEventListener('mousemove', this.mousePosition);
    document.addEventListener('click', event => {
      this.MyCM.nativeElement.classList.remove("active");
    });

    this.http = http;
    this.stroka = this.getCookie("Token");
    var base_url = window.location.origin;
    setTimeout(() => {
    this.http.get<MyObject[]>(baseUrl + "api/getFiles").subscribe(result => {
      this.MyObjects = result;
      console.log(result);
      console.log(this.MyObjects);
    }, error => {
      console.error(error);
    });
    }, 1);
  }

  myFunction(qwer: string, Type: string) {
    setTimeout(() => {
      console.log(Type);
      if (Type == "folder") {
        this.MyCM.nativeElement.style.top = this.mouseCoordinate.y + 2 + "px";
        this.MyCM.nativeElement.style.left = this.mouseCoordinate.x + 2 + "px";
        this.MyCM.nativeElement.classList.add("active");
        return
      }
      this.MyCMFile.nativeElement.style.top = this.mouseCoordinate.y + 2 + "px";
      this.MyCMFile.nativeElement.style.left = this.mouseCoordinate.x + 2 + "px";
      this.MyCMFile.nativeElement.classList.add("active");
      return
    },1);
  }

  private getCookie(name: string) {
    let matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  }

  mousePosition = (e: MouseEvent): void => {
    this.mouseCoordinate.x = e.clientX;
    this.mouseCoordinate.y = e.clientY;
  }
}

class position {
  x: number;
  y: number;
}

interface MyObject {
  Id: string;
  Name: string;
  ParentId: string;
  Type: string;
  CreationDate: string;
  NestingLevel: string;
  Size: string;
}

