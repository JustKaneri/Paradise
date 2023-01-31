import React from 'react'
import Loader from './Components/Loader/Loader'
import Navigation from './Components/NavigationPanel/Navigation'
import { BrowserRouter as Router, Routes, Route, Link, RouterProvider, Navigate } from "react-router-dom";
import AppRouter from './Components/Router/AppRouter';

const App = () => {
  return (
    <div>
     <Router>
        <Navigation/>
        <AppRouter/>
      </Router>
    </div>
  )
}

export default App