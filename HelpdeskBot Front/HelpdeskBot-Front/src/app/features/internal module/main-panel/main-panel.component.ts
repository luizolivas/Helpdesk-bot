import { Component, OnInit } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { Router } from '@angular/router';
import { MainPanelService } from '../main-panel.service';
import { Chamado } from '../../client module/models/chamado.model';

@Component({
  selector: 'app-main-panel',
  standalone: true,
  imports: [MatTableModule],
  templateUrl: './main-panel.component.html',
  styleUrl: './main-panel.component.css'
})
export class MainPanelComponent implements OnInit {
  displayedColumns: string[] = ['id', 'title', 'createdAt', 'status', 'detalhes'];
  dataSource: Chamado[] = [];

  constructor(private router: Router, private mainPanelService: MainPanelService) {}
  

  ngOnInit(): void {
    this.mainPanelService.getAllChamados()
      .subscribe({
        next: (data) =>{
          this.dataSource = data;
        },
        error(err){
          console.error(err)
        }
      })

  }

  redirectToDetails(id: number) {
    this.router.navigate(['/detalhes', id]);
  }

  formatDate(dateString: string): string {
    const date = new Date(dateString);
    const day = date.getDate().toString().padStart(2, '0');
    const month = (date.getMonth() + 1).toString().padStart(2, '0'); // Lembre-se que o mês começa em 0
    const year = date.getFullYear();
    return `${day}/${month}/${year}`;
  }

  getStatusText(status: number): string {
    switch (status) {
      case 1:
        return 'Aberto';
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
}
