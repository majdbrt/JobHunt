import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { CallToActionComponent } from './components/call-to-action/call-to-action.component';
import { NeoButtonComponent } from './components/neo-button/neo-button.component';
import { SignupComponent } from './pages/signup/signup.component';
import { LandingComponent } from './pages/landing/landing.component';
import { LoginComponent } from './pages/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    CallToActionComponent,
    NeoButtonComponent,
    SignupComponent,
    LandingComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule

  ],
  exports: [
    HeaderComponent,
    CallToActionComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
