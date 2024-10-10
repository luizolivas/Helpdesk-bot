import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatusChamadosComponent } from './status-chamados.component';

describe('StatusChamadosComponent', () => {
  let component: StatusChamadosComponent;
  let fixture: ComponentFixture<StatusChamadosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StatusChamadosComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StatusChamadosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
