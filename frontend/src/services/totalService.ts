import api from "./api";
import type { Totais } from "../types/Totais";

const totalService = {
    listar() {
        //resposta no formato Totais
        return api.get<Totais>("/Totais");
    }

};

export default totalService;