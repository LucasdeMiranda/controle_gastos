import { Link } from "react-router-dom";
// componente da barra de navegação
function Navbar() {
    return (
        <nav>
            <Link to="/">
                Pessoas
            </Link>
            {" | "}
            <Link to="/transacoes">
                Transações
            </Link>
            {" | "}
            <Link to="/totais">
                Totais
            </Link>
        </nav>
    );
}
export default Navbar;