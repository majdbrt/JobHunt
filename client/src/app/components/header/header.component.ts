import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  title: string = "Job Hunt";
  deg: number = 0;
  private _setIntervalHandler: any;

  enter(){
    this._setIntervalHandler = setInterval(()=>{
      this.deg += 1;
    },1 )

    
  }

  leave(){
    clearInterval(this._setIntervalHandler);
  }

  ngOnDestroy() {
    clearInterval(this._setIntervalHandler);
 }

  
}
