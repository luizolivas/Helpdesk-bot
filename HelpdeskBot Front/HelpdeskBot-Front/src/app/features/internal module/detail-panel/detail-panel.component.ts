import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatCard, MatCardContent, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { MatSelect, MatSelectModule } from '@angular/material/select'; // Importa MatSelectModule
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { Chamado } from '../../client module/models/chamado.model';
import { DetailPanelService } from '../detail-panel.service';
import { StatusChamado } from '../../Enums/StatusChamado';
import { ImageChamado } from '../../client module/models/ImageChamado';
import { MatDialog } from '@angular/material/dialog';
import { ImageModalComponent } from '../../image-modal/image-modal.component';
import { ImageChamadosService } from '../../image-chamados.service';


@Component({
  selector: 'app-detail-panel',
  templateUrl: './detail-panel.component.html',
  styleUrls: ['./detail-panel.component.css'],
  standalone: true,
  imports: [FormsModule, MatSelectModule, MatCardContent, MatCardTitle, MatCardHeader,MatCard, MatInputModule, MatSelect, CommonModule] 
})
export class DetailPanelComponent implements OnInit {
  chamado: Chamado = {
    id:0,
    title: '',
    description: '',
    user: '',
    codes: '',
    status: StatusChamado.Enviado, 
    createdAt: '',
    internalDescription: '',
    IdCliente: 0
  };
  imagePreviews: ImageChamado[] = [];

  idChamado = 0

  statusOptions = [
    { value: StatusChamado.Aberto, label: 'Aberto', color: 'support-analysis-color' },
    { value: StatusChamado.EmAnaliseSuporte, label: 'Em análise - suporte', color: 'technical-analysis-color' },
    { value: StatusChamado.EmAnaliseTecnico, label: 'Em análise - técnico', color: 'resolved-color' },
    { value: StatusChamado.Resolvido, label: 'Resolvido', color: 'resolved-color' }
  ];

  constructor(private route: ActivatedRoute, private router: Router, private chamadoService: DetailPanelService, private dialog: MatDialog, private imageChamadoService: ImageChamadosService) {}

  ngOnInit(): void {
    const chamadoId = this.route.snapshot.paramMap.get('id') || '';
    this.idChamado = parseInt(chamadoId)
    this.loadProblemDetails(chamadoId);
  }

  loadProblemDetails(id: string ): void {
    this.chamadoService.getChamado(id)
    .subscribe({
      next:(data) => {
        console.log('chamado: ', data)
        this.chamado = data
        this.imagesToList(this.idChamado)
      },
      error(err) {
        console.error('Erro ao buscar chamado: ',err)
      },
    })
  }


  backToList(): void {
    this.router.navigate(['/painel-interno']);
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

  onSubmit() {
    console.log('atualizando: ' , this.chamado)
    this.chamadoService.UpdateChamado(this.idChamado,this.chamado)
    .subscribe({
      next: (data) => {
          this.backToList()
      },
      error(err) {
        console.error('Erro ao buscar chamados:', err)
      },
    })
    
  }

  imagesToList(id: number){
    this.imageChamadoService.getImagesById(id)
      .subscribe({
        next:(data) => {
          this.imagePreviews = data
        },error(err) {
          console.error('Erro ao buscar imagens de chamado: ',err)
        },
      })
}


  openImageDialog(imageUrl: string) {
    this.dialog.open(ImageModalComponent, {
      data: { imageUrl: imageUrl },
      width: '80%', // Ajuste a largura conforme necessário
      height: '80%', // Ajuste a altura conforme necessário
      maxWidth: '90vw', // Para garantir que o diálogo não exceda a largura da janela
      maxHeight: '90vh' // Para garantir que o diálogo não exceda a altura da janela
    });
  }
}
