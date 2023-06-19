import './headerStyles.scss'
import React, { useEffect, useState } from 'react'
import { Link } from 'react-router-dom'
import { Menu } from '../Modal';
import srcUrl from '../../srcURL.json'
import '../../config/MultiLanguage'
import { useTranslation } from 'react-i18next';
import i18next from 'i18next';

const Header = ({ ...props }) => {

    const { t } = useTranslation();
    const translate = t;

    const minScrollY = 50;
    const { hideMultiLang } = props

    const [scrolled, setScrolled] = useState(window.scrollY > minScrollY ? true : false);
    const [openMenu, setOpenMenu] = useState(false);

    // Open or close menu modal
    const toggleMenu = () => {
        setOpenMenu(!openMenu)
    };

    // Handle switch language for project
    const switchLanguages = () => {
        const newLanguage = i18next.language === 'en' ? 'jp' : 'en'
        i18next.changeLanguage(newLanguage)
    }

    // Set state for scrolled when user scroll the screen
    useEffect(() => {
        const onScroll = () => {
            if (window.scrollY > minScrollY) {
                setScrolled(true);
            } else {
                setScrolled(false);
            }
        }

        window.addEventListener("scroll", onScroll);

        return () => window.removeEventListener("scroll", onScroll);
    }, [])

    return (
        <header className={(scrolled && "scrolled") + ' site-header'}>
            <div className="header__logo">
                <img src={srcUrl.logo} alt='logo'></img>
            </div>
            <div className="header__navigation">
                <div className="header__navigation__menu">
                    <div className="menu-item current">
                        <Link className='current-item' to="/">{translate('menu.Home')}</Link>
                    </div>
                    <div onClick={() => switchLanguages()} className="menu-item language" style={{ display: hideMultiLang ? 'none' : 'inherit' }}>
                        <img src={srcUrl.flagHeader} alt='flag' height="20"></img>
                        <span>{translate('header.button.switchLanguages')}</span>
                    </div>
                    <div className="menu-item button">
                        <label htmlFor="btnOpenMenu" className="btn-menu">
                            <img src={srcUrl.menuHeader} alt="" />
                            <button onClick={toggleMenu} id="btnOpenMenu"></button>
                            <Menu active={openMenu}
                                toggleMenu={toggleMenu}
                            />
                        </label>
                    </div>
                </div>
            </div>
        </header>
    )
}

export default Header;
