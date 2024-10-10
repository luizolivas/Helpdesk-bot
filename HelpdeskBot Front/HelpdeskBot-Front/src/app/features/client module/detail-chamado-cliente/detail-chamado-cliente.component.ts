import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatCard, MatCardContent, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { MatSelect, MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { Chamado } from '../../client module/models/chamado.model';
import { StatusChamado } from '../../Enums/StatusChamado';
import { DetailPanelService } from '../../internal module/detail-panel.service';
import { ImageChamadosService } from '../../image-chamados.service';
import { ImageChamado } from '../models/ImageChamado';
import { ViewChild } from '@angular/core';
import { ImageModalComponent } from '../../image-modal/image-modal.component';
import {
  MatDialog
} from '@angular/material/dialog';
import {ChangeDetectionStrategy, inject} from '@angular/core';




@Component({
  selector: 'app-detail-chamado-cliente',
  standalone: true,
  imports: [FormsModule, MatSelectModule, MatCardContent, MatCardTitle, MatCardHeader, MatCard, MatInputModule, MatSelect, CommonModule, ImageModalComponent], 
  templateUrl: './detail-chamado-cliente.component.html',
  styleUrl: './detail-chamado-cliente.component.css'

})
export class DetailChamadoClienteComponent {

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


  openImageDialog(imageUrl: string) {
    this.dialog.open(ImageModalComponent, {
      data: { imageUrl: imageUrl },
      width: '80%', // Ajuste a largura conforme necessário
      height: '80%', // Ajuste a altura conforme necessário
      maxWidth: '90vw', // Para garantir que o diálogo não exceda a largura da janela
      maxHeight: '90vh' // Para garantir que o diálogo não exceda a altura da janela
    });
  }

  constructor(private route: ActivatedRoute, private router: Router, private chamadoService: DetailPanelService, private imageChamadoService: ImageChamadosService, private dialog: MatDialog) {}

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
        this.imagesToList(id)
      },
      error(err) {
        console.error('Erro ao buscar chamado: ',err)
      },
    })
  }

  imagesToList(id: string){
      this.imageChamadoService.getImagesById(parseInt(id))
        .subscribe({
          next:(data) => {
            console.log(data)
            this.imagePreviews = data
          },error(err) {
            console.error('Erro ao buscar imagens de chamado: ',err)
          },
        })
  }


  backToList(): void {
    this.router.navigate(['/status-problema']);
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


}
