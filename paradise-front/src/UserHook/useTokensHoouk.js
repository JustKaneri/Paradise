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
        const date = new Date()
        date.setMonth(date.getMonth() + 3);

        const cookies = new Cookies();
        cookies.set('refresh', data.refreshToken , { path: '/',secure: false , expires:date });
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