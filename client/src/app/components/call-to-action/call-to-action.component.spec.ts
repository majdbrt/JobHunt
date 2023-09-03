import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CallToActionComponent } from './call-to-action.component';
import { NeoButtonComponent } from '../neo-button/neo-button.component';

describe('CallToActionComponent', () => {
  let component: CallToActionComponent;
  let fixture: ComponentFixture<CallToActionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [
        CallToActionComponent,
        NeoButtonComponent
      ]
    });
    fixture = TestBed.createComponent(CallToActionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
