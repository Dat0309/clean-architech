import React, { useEffect } from 'react';
import { RouterProvider } from 'react-router-dom';
import Router from './routes/Router'
import { useDispatch, useSelector } from 'react-redux';
import { getAllSliderAPI } from './redux/features/SliderSlice';
import { getPostAPIByType } from './redux/features/PostSlice';
import { setCurrentWidth } from './redux/features/GeneralSlice';
import { postType } from './config/PostType';
import { Loading } from './components';

import 'semantic-ui-css/semantic.min.css';
import "./App.scss";
import './ResponsiveStyle.scss';

export default function App() {

    const { allSliders } = useSelector(state => state.slider)
    const { news, blogs } = useSelector(state => state.post)

    const loading = allSliders.status.pending || news.status.pending || blogs.status.pending

    const dispatch = useDispatch()

    useEffect(() => {
        dispatch(getAllSliderAPI())
        dispatch(getPostAPIByType(postType.news))
        dispatch(getPostAPIByType(postType.blogs))
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    useEffect(() => {
        const handleResizeWindow = () => {
            dispatch(setCurrentWidth(window.innerWidth))            
        }
        window.addEventListener('resize', handleResizeWindow)
        return () => window.removeEventListener("resize", handleResizeWindow);
    }, []) // eslint-disable-line react-hooks/exhaustive-deps

    return (
        <>
            <Loading loading={loading}/>
            <RouterProvider router={Router}></RouterProvider>
        </>        
    );
}