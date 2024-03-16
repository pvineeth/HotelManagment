import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatehostelComponent } from './updatehostel.component';

describe('UpdatehostelComponent', () => {
  let component: UpdatehostelComponent;
  let fixture: ComponentFixture<UpdatehostelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdatehostelComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdatehostelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
