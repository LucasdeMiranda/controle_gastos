//aqui fica aurl base da api onde a comunicação é feita entre front e back
import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5062/api" //porta configurada em backend.http
});

export default api; 