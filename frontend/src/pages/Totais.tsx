import { useEffect, useState } from "react";
import totalService from "../services/totalService";
import type { Totais } from "../types/Totais";
import "../styles/Totais.css";
import { formatarMoeda } from "../utils/formatarMoeda";
function PaginaTotais() {

    const [totais, setTotais] = useState<Totais | null>(null);
    // chama o service que busca os totais no backend
    const carregarTotais = async () => {
        const resposta = await totalService.listar();
        console.log(resposta.data);
        setTotais(resposta.data);
    };

    // executa quando abrir a página
    useEffect(() => {
        carregarTotais();
    }, []);

    return (
        <div className="card">
            <h2>Totais</h2>

            {totais && (

                <div>

                    <div className="totais-gerais">

                        <div className="total-box">

                            <h3 className="receita">
                                Receitas
                            </h3>

                            <p>
                                R$ {formatarMoeda(totais.totalreceita)}
                            </p>

                        </div>

                        <div className="total-box">
                            <h3 className="despesa">
                                Despesas
                            </h3>
                            <p>
                                R$ {formatarMoeda(totais.totaldespesa)}
                            </p>

                        </div>

                        <div className="total-box">
                            <h3 className="saldo">
                                Saldo
                            </h3>
                            <p>
                                R$ {formatarMoeda(totais.saldogeral)}
                            </p>
                        </div>
                    </div>

                    <h3>
                        Totais por pessoa
                    </h3>

                    <ul className="lista">

                        {totais.pessoas.map((pessoa) => (

                            <li key={pessoa.nome}>

                                <strong>
                                    {pessoa.nome}
                                </strong>

                                <br />
                                Receitas:
                                R$ {formatarMoeda(pessoa.receitas)}
                                <br />
                                Despesas:
                                R$ {formatarMoeda(pessoa.despesas)}
                                <br />

                                Saldo:
                                R$ {formatarMoeda(pessoa.saldo)}
                            </li>
                        ))}

                    </ul>

                </div>
            )}
        </div>
    );
}
export default PaginaTotais;