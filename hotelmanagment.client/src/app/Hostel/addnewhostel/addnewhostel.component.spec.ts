import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddnewhostelComponent } from './addnewhostel.component';

describe('AddnewhostelComponent', () => {
  let component: AddnewhostelComponent;
  let fixture: ComponentFixture<AddnewhostelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddnewhostelComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddnewhostelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
