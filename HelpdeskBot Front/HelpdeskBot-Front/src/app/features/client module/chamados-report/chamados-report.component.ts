import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms'; // Importa FormsModule
import { MatCard, MatCardContent, MatCardHeader, MatCardTitle } from '@angular/material/card';
import { MatSelectModule } from '@angular/material/select'; // Importa MatSelectModule
import { MatInputModule } from '@angular/material/input';
import { Chamado } from '../models/chamado.model';
import { ProblemReportService } from '../chamados-report.service';
import {MatIconModule} from '@angular/material/icon';
import {MatDividerModule} from '@angular/material/divider';
import {MatButtonModule} from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { ChamadoSendedModalComponent } from '../../chamado-sended-modal/chamado-sended-modal.component';


@Component({
  selector: 'app-problem-report',
  templateUrl: './chamados-report.component.html',
  styleUrls: ['./chamados-report.component.css'],
  standalone: true,
  imports: [CommonModule,FormsModule, MatSelectModule, MatCardContent, MatCardTitle, MatCardHeader,MatCard, MatInputModule, MatButtonModule, MatDividerModule, MatIconModule] 
})
export class ProblemReportComponent {
  imagePreviews: string[] = [];
  imageFiles: File[] = []; // Para armazenar os arquivos selecionados
  chamadoId: number | null = null;


  chamado: Chamado ={
    id: 0,
    title: '',
    description: '',
    user: '',
    codes: '',
    status: 0,
    createdAt: new Date().toISOString(),
    internalDescription:'',
    IdCliente: 0
  }


  priorities: string[] = ['Baixa', 'Média', 'Alta'];

  constructor(private problemReportService: ProblemReportService, private dialog: MatDialog) {}

  onSubmit() {
    console.log('Detalhes do Chamadogfsdgdhfdfggfd:', this.chamado)
    this.problemReportService.createChamado(this.chamado)
    .subscribe({
      next: (data: any) => {
          console.log('Detalhes do Chamado:', data)
          this.chamadoId = data.id;
          this.onUploadImages()
          this.openModal()
      },
      error(err) {
        console.error('Erro ao buscar chamados:', err)
      },
    })
  }

  openModal(){
    this.dialog.open(ChamadoSendedModalComponent, {
      width: '30%', 
      height: 'auto'
    });
  }

  onUploadImages() {
    console.log('é pra ',this.imageFiles.length , this.chamadoId)
    if (this.chamadoId && this.imageFiles.length > 0) {
      const formData = new FormData();
      this.imageFiles.forEach(file => {
        formData.append('files', file, file.name);
      });
      formData.append('chamadoId', this.chamadoId.toString());

      

      this.problemReportService.uploadImages(this.chamadoId,formData).subscribe({
        next: (response) => {
          console.log('Imagens enviadas com sucesso:', response);
        },
        error: (error) => {
          console.error('Erro ao enviar imagens:', error);
        }
      });
    }
  }

  onReset() {
    this.chamado = {
      id: 0,
      title: '',
      description: '',
      user: '',
      codes: '',
      status: 1,
      createdAt: new Date().toISOString(),
      internalDescription: '',
      IdCliente: 0
    };
  }

  onFileSelected(event: any): void {
    const files = event.target.files;
    if (files) {
      for (let i = 0; i < files.length; i++) {
        this.previewImage(files[i]);
      }
      this.imageFiles = Array.from(files);
    }
  }

  onPaste(event: ClipboardEvent): void {
    const clipboardItems = event.clipboardData?.items;
    if (clipboardItems) {
      for (let i = 0; i < clipboardItems.length; i++) {
        const item = clipboardItems[i];
        if (item.type.startsWith('image')) {
          const file = item.getAsFile();
          if (file) {
            this.previewImage(file);
          }
        }
      }
    }
  }

  previewImage(file: File): void {
    const reader = new FileReader();
    reader.onload = (e: any) => {
      this.imagePreviews.push(e.target.result);
    };
    reader.readAsDataURL(file);
  }

  getSelectedFiles(): File[] {
    // Aqui você deve adaptar a lógica para retornar os arquivos que foram selecionados
    // Exemplo simplificado:
    return this.imagePreviews.map(src => {
      // Lógica para converter o src em File pode ser necessária aqui
      return new File([], ""); // Ajustar para criar o File correto
    });
  }
}
