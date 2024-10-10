import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { Router } from '@angular/router';
import { Chamado } from '../models/chamado.model';
import { MainPanelService } from '../../internal module/main-panel.service';
import { CommonModule } from '@angular/common';
import { StatusChamado } from '../../Enums/StatusChamado';

@Component({
  selector: 'app-status-reports',
  standalone: true,
  imports: [MatCardModule, MatButtonModule,MatFormFieldModule,ReactiveFormsModule,FormsModule, CommonModule],
  templateUrl: './status-chamados.component.html',
  styleUrl: './status-chamados.component.css'
})
export class StatusChamadosComponent  implements OnInit{

  dataSource: Chamado[] = [];
  constructor(private router: Router, private mainPanelService: MainPanelService) {}

  statusOptions = [
    { value: StatusChamado.Aberto, label: 'Aberto', color: 'support-analysis-color' },
    { value: StatusChamado.EmAnaliseSuporte, label: 'Em análise - suporte', color: 'technical-analysis-color' },
    { value: StatusChamado.EmAnaliseTecnico, label: 'Em análise - técnico', color: 'resolved-color' },
    { value: StatusChamado.Resolvido, label: 'Resolvido', color: 'resolved-color' }
  ];

  ngOnInit(): void {
    this.mainPanelService.getChamadosById()
      .subscribe({
        next: (data) =>{
          this.dataSource = data;
        },
        error(err){
          console.error(err)
        }
      })

  }

  getStatusText(status: number): string {
    switch (status) {
      case 0:
        return 'Enviando';
      case 1:
        return 'Enviado';
      case 2:
        return 'Em Analise Suporte';
      case 3:
        return 'Em Analise Tecnico';
      case 4:
        return 'Resolvido';
      default:
        return 'Desconhecido';
    }
  }

  getStatusClass(status: number): string {
    switch (status) {
      case 2:
        return 'sent';
      case 3:
        return 'under-review-support';
      case 4:
        return 'under-review-tech';
      case 5:
        return 'resolved';
      default:
        return '';
    }
  }
  
  redirectToStatusDetail(id: number) {
    this.router.navigate(['/detalhes-chamado-cliente/', id]);   
  }

}
