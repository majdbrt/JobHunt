import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-neo-button',
  templateUrl: './neo-button.component.html',
  styleUrls: ['./neo-button.component.css']
})
export class NeoButtonComponent {
  @Input({required:true}) 
  text: string;

  @Input({}) 
  color: string;

  constructor(){
    this.text = "";
    this.color = "white"
  }
}
