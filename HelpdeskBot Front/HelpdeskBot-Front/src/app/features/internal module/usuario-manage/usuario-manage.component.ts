import { Component } from '@angular/core';
import { MatTableModule } from '@angular/material/table';
import { UsuarioInterno } from '../../client module/models/usuarioInterno';
import { MatIcon } from '@angular/material/icon';

@Component({
  selector: 'app-usuario-manage',
  standalone: true,
  imports: [MatTableModule, MatIcon],
  templateUrl: './usuario-manage.component.html',
  styleUrl: './usuario-manage.component.css'
})
export class UsuarioManageComponent {
  displayedColumns: string[] = ['id', 'name', 'tipoUsuario'];
  dataSource: UsuarioInterno[] = [];

  addElement() {

  }

  // Deletar o elemento selecionado
  deleteElement() {

  }
}
