import React,{useState,useEffect} from 'react'
import Navigation from './Components/NavigationPanel/Navigation'
import { BrowserRouter as Router} from "react-router-dom";
import AppRouter from './Components/Router/AppRouter';
import { AuthContext, AlertContext } from './Context';
import { useMemo } from 'react';
import AlertManager from './Components/AlertManager/AlertManager';

const App = () => {

  const [IsAuth,setIsAuth] = useState(false);
  const [IsUpdate,setIsUpdate] = useState(false);
  const [Alert,setAlert] = useState({
     id: "",
     content: "",
     type: ""
  })//3 type: error,warning, success

  useMemo(()=>{
    if(localStorage.getItem('token')){
      setIsAuth(true);
    }

  },[]);

  return (
      <AuthContext.Provider value={{
        IsAuth,
        setIsAuth,
        IsUpdate,
        setIsUpdate,
        Alert,
        setAlert
      }}>
    <AlertManager
      value = {Alert}
    />
     <Router>
        <Navigation/>
        <AppRouter/>
      </Router>
    </AuthContext.Provider>
  )
}

export default App