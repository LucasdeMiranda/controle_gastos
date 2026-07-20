import api from "./api";
import type { Transacao } from "../types/Transacao";

const transacaoService = {
    listar() {
        return api.get<Transacao[]>("/Transacao");
    },

    criar(transacao: Transacao) {
        return api.post("/Transacao", transacao);
    }

};
export default transacaoService;