import axios from 'axios';

class AuthService {
    login(API_URL, user) {
        return axios
            .post(API_URL + 'PostLogin', {
                nombreUsuario: user.nombreUsuario,
                ContrasenaHash: user.contrasenaHash
            })
            .then((response) => {
                if (response.data.token) {
                    localStorage.setItem('jwt', response.data.token);
                }
                return response.data;
            });
    }

    logout() {
        localStorage.removeItem('jwt');
    }

    getToken() {
        return localStorage.getItem('jwt');
    }
}

export default new AuthService();
