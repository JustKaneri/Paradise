import React,{useState,useEffect} from 'react'
import Loader from './Components/Loader/Loader'
import Navigation from './Components/NavigationPanel/Navigation'
import { BrowserRouter as Router, Routes, Route, Link, RouterProvider, Navigate } from "react-router-dom";
import AppRouter from './Components/Router/AppRouter';
import { AuthContext, AlertContext } from './Context';
import { useMemo } from 'react';
import AlertItem from './Components/AlertManager/AlerItem/AlertItem';

const App = () => {

  const [IsAuth,setIsAuth] = useState(false);
  const [IsUpdate,setIsUpdate] = useState(false);
  const [Alert,setAlert] = useState({
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
        setIsUpdate
      }}>
      <AlertContext.Provider value={{

      }}>
      </AlertContext.Provider>
    <AlertItem
      type = "warning"
    />
     <Router>
        <Navigation/>
        <AppRouter/>
      </Router>
    </AuthContext.Provider>
  )
}

export default App