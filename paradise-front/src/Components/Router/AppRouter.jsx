import React, { useContext } from 'react';
import { BrowserRouter as Router, Routes, Route, Link, RouterProvider, Navigate } from "react-router-dom";
import { privatRoutes, publicRoutes,notAuthRoutes } from '../../Router/Routes.js';
import { AuthContext } from '../../Context';

const AppRouter = () => {

    const {IsAuth} = useContext(AuthContext);

    return (
        <div>
            <Routes>
                    {publicRoutes.map((obj)=>
                        <Route 
                            exact = {obj.exact} 
                            path={obj.path} 
                            element={obj.element}
                            key={obj.path}
                        />
                    )}
                    {IsAuth == false &&
                        notAuthRoutes.map((obj)=>
                            <Route 
                                exact = {obj.exact} 
                                path={obj.path} 
                                element={obj.element}
                                key={obj.path}
                            />)
                    }
                    {IsAuth && 
                      privatRoutes.map((obj)=>
                      <Route 
                            exact = {obj.exact} 
                            path={obj.path} 
                            element={obj.element}
                            key={obj.path}
                       />)
                    }
                    <Route path='*' element={<Navigate to={"/not-found"}/>}/>
            </Routes>
        </div>
    );
}

export default AppRouter;
