import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GridLinesUserComponent } from './grid-lines-user.component';

describe('GridLinesUserComponent', () => {
  let component: GridLinesUserComponent;
  let fixture: ComponentFixture<GridLinesUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GridLinesUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GridLinesUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
