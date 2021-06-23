import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CabViewComponent } from './cab-view.component';

describe('CabViewComponent', () => {
  let component: CabViewComponent;
  let fixture: ComponentFixture<CabViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CabViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CabViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
