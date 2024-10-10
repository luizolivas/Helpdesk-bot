import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailChamadoClienteComponent } from './detail-chamado-cliente.component';

describe('DetailChamadoClienteComponent', () => {
  let component: DetailChamadoClienteComponent;
  let fixture: ComponentFixture<DetailChamadoClienteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DetailChamadoClienteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetailChamadoClienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
