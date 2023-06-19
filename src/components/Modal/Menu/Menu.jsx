import React from 'react'
import { Modal } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

import './menuStyles.scss'
import srcUrl from "../../../srcURL.json"
import { menu } from '../../../config/MenuName'

import { useSelector } from 'react-redux';
import { useTranslation } from 'react-i18next'

const Menu = ({ ...props }) => {

    const { t } = useTranslation();
    const translate = t;
    
    const { active, toggleMenu } = props
    const { menuActive } = useSelector(state => state.general);

    return (
        <Modal
            style={{ background: "transparent", width: "100%" }}
            className='menu-modal'
            open={active}
            onClose={() => toggleMenu()}
            onOpen={() => toggleMenu()}
        >
            <Modal.Actions className='menu-modal__actions'>
                <button id='close-btn' onClick={() => toggleMenu()}><span>{translate("modal.button.close")}</span><img src={srcUrl.iconCancel} alt="close" /></button>
            </Modal.Actions>
            <Modal.Content className='menu-modal__content' scrolling>
                <ul className='menu-modal__container'>
                    <Link to='/' className={`menu-modal__menu-item ${menuActive === menu.home ? "active" : ""}`}>{translate("menu.Home")}</Link>
                    <li>
                        <Link to='/About' className={`menu-modal__menu-item ${menuActive === menu.about ? "active" : ""}`}>{translate("menu.AboutUs")}</Link>
                        <ul className='menu-modal__sub-menu'>
                            <li><a href={srcUrl.aboutUsTitanLinkWhoWeAre} target="_blank" rel="noopener noreferrer">{translate("submenu.Who")}</a></li>
                            <li><a href={srcUrl.aboutUsTitanLinkOurClients} target="_blank" rel="noopener noreferrer">{translate("submenu.OurCl")}</a></li>
                            <li><a href={srcUrl.aboutUsTitanLinkNews} target="_blank" rel="noopener noreferrer">{translate("submenu.News")}</a></li>
                        </ul>
                    </li>
                    <Link className={`menu-modal__menu-item ${menuActive === menu.blogs ? "active" : ""}`} to='/Blogs'>{translate("menu.Blogs")}</Link>
                </ul>
            </Modal.Content>
        </Modal >
    )
}

export default Menu