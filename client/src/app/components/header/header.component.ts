import { Component, NgModule } from '@angular/core';
import { NeoButtonComponent } from '../neo-button/neo-button.component';



@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  
  
})
export class HeaderComponent {

  menuVisible = false;

  showMenu(){
    if(this.menuVisible){
      this.menuVisible = false
    }
    else{
      this.menuVisible = true
    }
  }

}
