import React from 'react';
import {createBrowserRouter} from "react-router-dom";
import { Home, AboutUs, Blogs, NotFound } from '../pages/index';

const Router = createBrowserRouter([
    {
      path: "*",
      element: <NotFound/>,    
    },  
    {
      path: "/",
      element: <Home/>,    
    },
    {
        path: "/About",
        element: <AboutUs/>,    
    },
    {
        path: "/Blogs",
        element: <Blogs/>,    
    },
  ]);

export default Router;