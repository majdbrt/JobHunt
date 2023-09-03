import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandingComponent } from './landing.component';
import { HeaderComponent } from 'src/app/components/header/header.component';
import { CallToActionComponent } from 'src/app/components/call-to-action/call-to-action.component';
import { NeoButtonComponent } from 'src/app/components/neo-button/neo-button.component';

describe('LandingComponent', () => {
  let component: LandingComponent;
  let fixture: ComponentFixture<LandingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [
        LandingComponent,
        HeaderComponent,
        CallToActionComponent,
        NeoButtonComponent
      ]
    });
    fixture = TestBed.createComponent(LandingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
