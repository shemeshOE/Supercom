import axios from 'axios';

const getInstance = () => {
  const instance = axios.create({
    baseURL: 'https://localhost:7290',
    timeout: 60000,
    headers: {
      'Content-Type': 'application/json',
      Accept: 'application/json',
    },
  });

  instance.interceptors.response.use(
    (response) => {
      return response;
    },
    (error) => {
      return Promise.reject(error);
    }
  );
  return instance;
};

export default getInstance;
