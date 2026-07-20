import type { TotalPessoa } from "./TotalPessoa";

//porque retorna o total de todas as pessoas e os totais gerais no backend
export interface Totais{
    pessoas: TotalPessoa[];
    totalreceita: number;
    totaldespesa: number;
    saldogeral: number;
}