import { Component, NgModule } from '@angular/core';
import { NeoButtonComponent } from '../neo-button/neo-button.component';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  
  
})
export class HeaderComponent {

  title: string = "Job Hunt";
  deg: number = 0;
  private _setIntervalHandler: any;

}
