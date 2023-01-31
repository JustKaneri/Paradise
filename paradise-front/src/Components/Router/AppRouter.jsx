import React from 'react';
import { BrowserRouter as Router, Routes, Route, Link, RouterProvider, Navigate } from "react-router-dom";
import { privatRoutes, publicRoutes } from '../../Router/Routes.js';

const AppRouter = () => {
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
                    <Route path='*' element={<Navigate to={"/main"}/>}/>
            </Routes>
        </div>
    );
}

export default AppRouter;
