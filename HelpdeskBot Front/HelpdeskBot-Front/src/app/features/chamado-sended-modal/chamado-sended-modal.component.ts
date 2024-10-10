import { Component } from '@angular/core';
import {
  MatDialog,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
} from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-chamado-sended-modal',
  standalone: true,
  imports: [MatDialogContent,MatDialogActions],
  templateUrl: './chamado-sended-modal.component.html',
  styleUrl: './chamado-sended-modal.component.css'
})
export class ChamadoSendedModalComponent {

  constructor(
    public dialogRef: MatDialogRef<ChamadoSendedModalComponent>,
    private router: Router
  ) {}

  // Redirecionar para a página Meus Chamados
  goToMeusChamados() {
    this.router.navigate(['/meus-chamados']);
    this.dialogRef.close(); // Fecha o modal
  }

  // Redirecionar para a página Início
  goToInicio() {
    this.router.navigate(['/']);
    this.dialogRef.close(); // Fecha o modal
  }
}
