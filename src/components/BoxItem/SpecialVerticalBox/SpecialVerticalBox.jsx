import React from 'react'
import { Link } from 'react-router-dom'

import './specialVerticalBoxStyles.scss'

const SpecialVerticalBox = ({ ...props }) => {

    const { icon, link, title, children } = props

    return (
        <div className='special-vertical-box'>
            <Link className='special-vertical-box__link' to={link} target='_blank'>
                <img className='special-vertical-box__icon' src={icon} alt="icon" />
                <h2 className='special-vertical-box__title'>{title}</h2>
            </Link>
            <div className="special-vertical-box__content">
                {children}
            </div>
        </div>
    )
}

export default SpecialVerticalBox