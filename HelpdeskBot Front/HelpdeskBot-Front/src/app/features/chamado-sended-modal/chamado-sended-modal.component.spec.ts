import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChamadoSendedModalComponent } from './chamado-sended-modal.component';

describe('ChamadoSendedModalComponent', () => {
  let component: ChamadoSendedModalComponent;
  let fixture: ComponentFixture<ChamadoSendedModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChamadoSendedModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChamadoSendedModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
