import React from 'react'

import './boxContentStyle.scss'

const BoxContent = ({ ...props }) => {

    const { title, subtitle, children, bgImage, className } = props

    return (
        <div className={`box-content ${className || ""} ${bgImage ? 'with-bg-image' : ""}`} style={{ backgroundImage: `url(${bgImage})` }}>
            <div className='box-content__wrapper'>
                <div className='box-content__title-venture'>
                    <h1 className='box-content__title-venture__title'><span>{title}</span></h1>
                    <div className='box-content__title-venture__subtitle'><span>{subtitle}</span></div>
                </div>
                <div className='box-content__content'>
                    {children}
                </div>
            </div>
        </div>
    )
}

export default BoxContent;