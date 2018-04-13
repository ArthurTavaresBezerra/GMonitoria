import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageMainCollaboratorComponent } from './page-main-collaborator.component';

describe('PageMainCollaboratorComponent', () => {
  let component: PageMainCollaboratorComponent;
  let fixture: ComponentFixture<PageMainCollaboratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageMainCollaboratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageMainCollaboratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
