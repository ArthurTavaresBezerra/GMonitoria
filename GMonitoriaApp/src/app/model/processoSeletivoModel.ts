export class ProcessoSeletivoModel {
  public processoSeletivoId: string;
  
    constructor(
    public periodo: string,
    public datahora: any,
     public isIniciado: boolean,
     public isConcluido: boolean,
     public processoSeletivoCurso: any
    ) {  }
  }