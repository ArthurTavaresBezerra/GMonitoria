import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageMainStudentComponent } from './page-main-student.component';

describe('PageMainStudentComponent', () => {
  let component: PageMainStudentComponent;
  let fixture: ComponentFixture<PageMainStudentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageMainStudentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageMainStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
