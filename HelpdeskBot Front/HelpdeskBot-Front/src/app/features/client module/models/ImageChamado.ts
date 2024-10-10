import { Chamado } from "./chamado.model";

export interface ImageChamado {
    id: number;
    nome: string;
    caminho: string;
    tipo: string;
    dataUpload: string; 
    chamadoId: number;
    chamado: Chamado
}
