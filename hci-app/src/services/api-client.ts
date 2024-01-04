import axios, { CanceledError } from "axios";

export default axios.create({
    baseURL: "http://localhost:5127/api/v1",
});

export { CanceledError };