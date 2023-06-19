import React from 'react'
import srcURL from '../../../srcURL.json'

import './cardFooterContactStyles.scss'

const CardFooterContact = (props) => {

    const { title, tel, email, skype, flex, children } = props

    return (
        <div className='card-footer-contact'>
            <h3>{title}</h3>
            {children && <p className={flex && 'flex'}>{children}</p>}
            {tel && (<p className='card-footer-contact__tel'>Tel: <a href={'tel:' + tel}>{tel}</a></p>)}
            {email && email.map((item, index) => (
                <p key={index} className='card-footer-contact__mail-skype'><img className='card-footer-contact__icon' src={srcURL.mail} alt="email" /><a href={'mailto:' + item}>{item}</a></p>
            ))}
            {skype && skype.map((item, index) => (
                <p key={index} className='card-footer-contact__mail-skype'><img className='card-footer-contact__icon' src={srcURL.skype} alt="email" /><a href={'mailto:' + item}>{item}</a></p>
            ))}
        </div>
    )
}

export default CardFooterContact