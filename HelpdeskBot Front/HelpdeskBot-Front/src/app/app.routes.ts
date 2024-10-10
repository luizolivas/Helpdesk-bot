import { Routes } from '@angular/router';
import { ProblemReportComponent } from './features/client module/chamados-report/chamados-report.component';
import { StatusChamadosComponent } from './features/client module/status-chamados/status-chamados.component';
import { ChatWindowComponent } from './features/client module/chat-window/chat-window.component';
import { MainPanelComponent } from './features/internal module/main-panel/main-panel.component';
import { DetailPanelComponent } from './features/internal module/detail-panel/detail-panel.component';
import { DetailChamadoClienteComponent } from './features/client module/detail-chamado-cliente/detail-chamado-cliente.component';
import { HomeComponent } from './features/client module/home/home.component';
import { UsuarioManageComponent } from './features/internal module/usuario-manage/usuario-manage.component';


export const routes: Routes = [
    {path: '', component: HomeComponent},
    {path: 'chat', component: ChatWindowComponent},
    {path: 'relatar-problema', component: ProblemReportComponent},
    {path: 'status-problema', component: StatusChamadosComponent},
    {path: 'painel-interno', component: MainPanelComponent},
    {path: 'detalhes/:id', component: DetailPanelComponent},
    {path: 'detalhes-chamado-cliente/:id', component: DetailChamadoClienteComponent},
    {path: 'usuarios', component: UsuarioManageComponent}
];
