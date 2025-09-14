import axios from 'axios';

const http = axios.create({
  baseURL: 'https://localhost:7084/ATM/',
  headers: {
    Accept: 'application/json',
  },
});

export default http;
