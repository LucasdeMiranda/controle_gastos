import { useEffect, useState } from "react";
import pessoaService from "../services/pessoaService";
import type { Pessoa } from "../types/Pessoa";
import "../styles/Pessoa.css";
import { FaTrash } from "react-icons/fa";// incone da lixeira


function Pessoas() {
    const [pessoas, setPessoas] = useState<Pessoa[]>([]);
    const [nome, setNome] = useState("");
    const [idade, setIdade] = useState<number | undefined>(undefined)
    const [erro, setErro] = useState("");

     //chama o service que por sua vez faz uma requisição a api do backend
    const carregarPessoas = async () => {
        const resposta = await pessoaService.listar();
        setPessoas(resposta.data);
    };

    useEffect(() => {
        carregarPessoas();
    }, []);

    const cadastrarPessoa = async () => {
        try{
        await pessoaService.criar({
            id: 0,
            nome,
            idade: idade ??0 // se nao for informado idade ele coloca a idade como 0
        });
        //nome começa como uma string vazia e idade 0 na tela
        setNome("");
        setIdade(0);
        //carrega as pessoas que já estão no banco
        await carregarPessoas();
    } catch (error:any) {

        setErro(
            error.response.data
        );

    }
};
    const excluirPessoa = async (id: number) => {
        await pessoaService.deletar(id);
        await carregarPessoas();
    };
     return (
<div className="card">

    <h2>Pessoas</h2>

    <div className="form">

        <input
            type="text"
            placeholder="Nome"
            value={nome}
            onChange={(e)=>setNome(e.target.value)}
        />
        <input
            type="number"
            placeholder="Idade"
            value={idade ?? ""}
            onChange={(e)=>setIdade(Number(e.target.value))}
        />
        <button onClick={cadastrarPessoa}>
            Cadastrar
        </button>
        {
            erro && (
                    <p className="erro">
                        {erro}
                    </p>
                )
            }

    </div>

    <h3>Pessoas cadastradas</h3>

    <ul className="lista">

        {pessoas.map((pessoa)=>(

            <li key={pessoa.id}>

                <div>
                    <strong>{pessoa.nome}</strong>
                    <br/>
                    Idade: {pessoa.idade}
                    <br/>
                    ID: {pessoa.id}
                </div>
                 <button 
                    className="delete" onClick={() => excluirPessoa(pessoa.id)}>
                    <FaTrash />
                </button>

            </li>

        ))}

    </ul>
</div>
);
}
export default Pessoas;