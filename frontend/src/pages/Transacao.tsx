import { useEffect, useState } from "react";
import transacaoService from "../services/transacaoService";
import type { Transacao } from "../types/Transacao";
import "../styles/Transacao.css";
import { formatarMoeda } from "../utils/formatarMoeda";

function Transacoes() {

    const [transacoes, setTransacoes] = useState<Transacao[]>([]);
    const [descricao, setDescricao] = useState("");
    const [valor, setValor] = useState(0);
    const [tipo, setTipo] = useState(0);
    const [pessoaId, setPessoaId] = useState(0);
    //para pegar o erro caso alguem com menos de 18 anos tente cadastrar uma receita
    const [erro, setErro] = useState("");

    const carregarTransacoes = async () => {
        const resposta = await transacaoService.listar();

        setTransacoes(resposta.data);
    };
   //carrega as transações toda vez que entra na página
    useEffect(() => {
        carregarTransacoes();
    }, []);


    const cadastrarTransacao = async () => {

    try {

        await transacaoService.criar({
            id: 0,
            descricao,
            valor,
            tipo,
            pessoaId
        });

        setErro("");
        setDescricao("");
        setValor(0);
        setTipo(0);
        setPessoaId(0);
        carregarTransacoes();

    } catch (error:any) {

        setErro(
            error.response.data
        );

    }

};
    return (

        <div className="card">

            <h2>Transações</h2>

            <h3>Adicionar Transação</h3>

            {
            erro && (
                    <p className="erro">
                        {erro}
                    </p>
                )
            }

            <div className="form">

                <input
                    type="text"
                    placeholder="Descrição"
                    value={descricao}
                    onChange={(e) => setDescricao(e.target.value)}
                />
                <input
                    type="number"
                    placeholder="Valor"
                    value={valor}
                    onChange={(e) => setValor(Number(e.target.value))}
                />
                <select
                    value={tipo}
                    onChange={(e) => setTipo(Number(e.target.value))}
                >
                    <option value={0}>
                        Despesa
                    </option>


                    <option value={1}>
                        Receita
                    </option>

                </select>


                 <label>
                    ID
                </label>
                <input
                    type="number"
                    placeholder="ID"
                    value={pessoaId}
                    onChange={(e) => setPessoaId(Number(e.target.value))}
                />
                <button onClick={cadastrarTransacao}>
                    Cadastrar
                </button>
            </div>
            <h3>Lista de Transações</h3>
            <ul className="lista">
                {
                    transacoes.map((transacao) => (
                        <li key={transacao.id}>
                            <div>

                                <strong>
                                    {transacao.descricao}
                                </strong>
                                <br />
                                Pessoa ID: {transacao.pessoaId}
                            </div>
                            <div>
                                <span
                                    className={
                                        transacao.tipo === 0
                                            ? "valor despesa"
                                            : "valor receita"
                                    }

                                >
                                     {formatarMoeda(transacao.valor)}

                                </span>
                                <br />
                                {
                                    transacao.tipo === 0
                                        ? "Despesa"
                                        : "Receita"
                                }
                            </div>
                        </li>
                    ))
                }
            </ul>
        </div>
    );
}
export default Transacoes;