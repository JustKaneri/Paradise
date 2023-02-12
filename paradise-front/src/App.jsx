import React,{useState,useEffect} from 'react'
import Loader from './Components/Loader/Loader'
import Navigation from './Components/NavigationPanel/Navigation'
import { BrowserRouter as Router, Routes, Route, Link, RouterProvider, Navigate } from "react-router-dom";
import AppRouter from './Components/Router/AppRouter';
import { AuthContext } from './Context';

const App = () => {

  const [IsAuth,setIsAuth] = useState(false);

  useEffect(()=>{
    if(localStorage.getItem('token')){
      setIsAuth(true);
    }

  },[]);

  return (
      <AuthContext.Provider value={{
        IsAuth,
        setIsAuth
      }}>
     <Router>
        <Navigation/>
        <AppRouter/>
      </Router>
    </AuthContext.Provider>
  )
}

export default App