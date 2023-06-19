/* eslint-disable react-hooks/exhaustive-deps */
import React from 'react'
import srcURL from '../../srcURL.json'

import './loadingStyles.scss'

const Loading = (props) => {

    const { loading } = props

    return (
        <div className={`loading__container ${loading ? '' : 'fade'}`}>
            <div className="loading__container__logo">
                <img src={srcURL.logoBlue} alt="logo"/>
            </div>                   
            <div className="loading__container__animation"></div>
        </div>
    )
}

export default Loading