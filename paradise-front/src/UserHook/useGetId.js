import useTokenHook from "./useTokensHoouk";

const getId = () => {

    try {
        return JSON.parse(window.atob(useTokenHook.getAccsesToken().split('.')[1])).id;
      } catch (e) {
        return null;
    }
}

export default getId;