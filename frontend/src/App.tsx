import { BrowserRouter, Routes, Route, NavLink } from "react-router-dom";

import Pessoa from "./pages/Pessoa";
import Transacoes from "./pages/Transacao";
import  PaginaTotais from "./pages/Totais";

import "./styles/App.css";

function App() {
    return (
        <BrowserRouter>

            <header className="navbar">

                <h1>Controle de Gastos Residenciais</h1>

                <nav>

                    <NavLink to="/">
                        Pessoas
                    </NavLink>

                    <NavLink to="/transacoes">
                        Transações
                    </NavLink>

                    <NavLink to="/totais">
                        Totais
                    </NavLink>

                </nav>

            </header>

            <main className="container">

                <Routes>

                    <Route path="/" element={<Pessoa />} />

                    <Route
                        path="/transacoes"
                        element={<Transacoes />}
                    />

                    <Route
                        path="/totais"
                        element={<PaginaTotais />}
                    />

                </Routes>

            </main>

        </BrowserRouter>
    );
}

export default App;