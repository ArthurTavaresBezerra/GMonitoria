import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageMainProcessoSeletivoComponent } from './page-main-processo-seletivo.component';

describe('PageMainProcessoSeletivoComponent', () => {
  let component: PageMainProcessoSeletivoComponent;
  let fixture: ComponentFixture<PageMainProcessoSeletivoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageMainProcessoSeletivoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageMainProcessoSeletivoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
