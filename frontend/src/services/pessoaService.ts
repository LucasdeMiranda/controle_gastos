import api from "./api";
import type { Pessoa } from "../types/Pessoa";

// chama a apide pessoas.
const pessoaService = {

    criar(pessoa: Pessoa) {
        return api.post("/Pessoas", pessoa);
    },

    deletar(id: number) {
        return api.delete(`/Pessoas/${id}`);
    },

    listar() {
        return api.get<Pessoa[]>("/Pessoas");
    }

};
//permite exportar para usar em outro lugar
export default pessoaService;