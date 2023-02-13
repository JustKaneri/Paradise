import Cookies from 'universal-cookie';

export default class useTokenHook{

    static getTokens(){
        const cookies = new Cookies();

        return {
            "token": localStorage.getItem('token'),
            "refreshToken": cookies.get('refresh')
        };
    }

    static saveTokens(data){
        const cookies = new Cookies();
        cookies.set('refresh', data.refreshToken , { path: '/' });
        localStorage.setItem('token',data.token)
    }

    static resetTokens(){
        localStorage.removeItem('token');
        const cookies = new Cookies();
        cookies.remove('refresh');
    }

    static getAccsesToken(){
        return localStorage.getItem('token');
    }

}