import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetallhostelsComponent } from './getallhostels.component';

describe('GetallhostelsComponent', () => {
  let component: GetallhostelsComponent;
  let fixture: ComponentFixture<GetallhostelsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [GetallhostelsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(GetallhostelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
