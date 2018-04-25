import { ProcessoSeletivoService } from './../processoSeletivo.service';
import { ProcessoSeletivoModel } from './../model/processoSeletivoModel';
import { Component, OnInit } from '@angular/core';






@Component({
  selector: 'app-page-main-processo-seletivo',
  templateUrl: './page-main-processo-seletivo.component.html',
  styleUrls: ['./page-main-processo-seletivo.component.scss']
})
export class PageMainProcessoSeletivoComponent implements OnInit {

  processosSeletivos : ProcessoSeletivoModel[]=[];
  carregando: boolean = true;

  constructor(public processoSeletivoService: ProcessoSeletivoService ){
    this.carregando = true;
    processoSeletivoService.getProcessoSeletivo().subscribe((processosSeletivos)=>{
      this.processosSeletivos = processosSeletivos;
      this.carregando = false;
    })

  }

      ngOnInit () { 
      }
    

}
