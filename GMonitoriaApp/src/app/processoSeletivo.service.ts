import { ProcessoSeletivoModel } from './model/processoSeletivoModel';
import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
//import 'rxjs/add/operator/catch';


@Injectable()
export class ProcessoSeletivoService{
    static readonly processoSeletivo_URI = 'http://localhost:5000/api/ProcessoSeletivo';
    constructor(public http: Http) { }

    getProcessoSeletivo(){// Retorna todos os Processos Seletivos
        return this.http.get(ProcessoSeletivoService.processoSeletivo_URI)
        .map((result)=>result.json());
    }


    getProcessoSeletovoMat(id){ // Retorna os detalhes de um Processo Seletivo
        return this.http.get('processoSeletivo_URI${id}')
           .map((result) => result.json());
    }
}

