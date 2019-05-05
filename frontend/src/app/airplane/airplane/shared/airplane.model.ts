export class Airplane {
    codigo: string;
    modelo: string;
    passageiros: number;


    constructor(dados: any) {        
        this.codigo = dados.codigo;
        this.modelo = dados.modelo;        
        this.passageiros = dados.passageiros;
    }
}