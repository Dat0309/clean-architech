import React, { useState } from 'react'
import CardFooterContact from './CardFooterContact/CardFooterContact'
import srcURL from '../../srcURL.json'

import './footerStyles.scss'
import { useTranslation } from 'react-i18next'

const Footer = ({ ...props }) => {

    const { t } = useTranslation();
    const translate = t;

    const [showMap, setShowMap] = useState(false)
    const { footerLocationStyle, isBlogsPage } = props

    // Handle when click toggle map button
    const toggleShowMap = () => {
        setShowMap(!showMap)
    }

    // Handle scrolling screen to the top
    const handleScrollToTop = () => {
        window.scrollTo(0, 0)
    }

    return (
        <footer>
            <div className="footer__header">
                <div className="footer__header--container">
                    <div>{translate('footer.title.contact')}</div>
                    <button className='footer__find-btn' onClick={toggleShowMap}>{translate('footer.findUs')}<img className='footer__header__icon' src={srcURL.mark} alt="marker" /></button>
                </div>
            </div>
            <div id="map" className={showMap ? 'show' : ''}>
                <iframe title='map-location' src={srcURL.mapEmbed} width="100%" height="500" style={{ border: 0 }} allowFullScreen="" loading="lazy" referrerPolicy="no-referrer-when-downgrade"></iframe>
            </div>
            <div className="footer__location grid" style={footerLocationStyle}>
                <CardFooterContact title={translate('footer.title.head')} tel={translate('footer.tel.tphcm40LamSon')}>40 Lam Son Street, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam
                </CardFooterContact>
                {isBlogsPage ? (
                    <>
                        <CardFooterContact title={translate('footer.title.northAmerica')} tel={translate('footer.tel.northAmerica')}>300 International Drive, Suite 100 Williamsville, Buffalo, New York 14221, USA.</CardFooterContact>
                        <CardFooterContact title={translate('footer.title.japan')} tel={translate('footer.tel.japan')}>1-8-12 Higashi-Gotanda, Oharasanden building 4F, Shinagawa, Tokyo, Japan.<br />Our Business Alliance: The Japan Group Company</CardFooterContact>
                    </>
                ) : (
                    <>
                        <CardFooterContact title={translate('footer.title.branch')} tel={translate('footer.tel.tphcm50CuuLong')}>50 Cuu Long Street, Ward 2, Tan Binh District, Ho Chi Minh City, Vietnam.</CardFooterContact>
                        <CardFooterContact title={translate('footer.title.branch')} tel={translate('footer.tel.dalat')}>9/1/2 Tran Dai Nghia Street, Ward 8, Da Lat City, Vietnam.</CardFooterContact>
                    </>
                )}
            </div>
            <div className="footer__contact grid">
                <CardFooterContact
                    title={translate('footer.card.titleGene')}
                    email={['info@titancorpvn.com']}
                    skype={['titancorpvn']}
                ></CardFooterContact>
                <CardFooterContact
                    title={translate('footer.card.titleSales')}
                    email={['sales@titancorpvn.com', 'support@titancorpvn.com']}
                ></CardFooterContact>
                <CardFooterContact title={translate('footer.card.titleSupport')} flex="true">
                    <button className='primary'><img className='icon' src={srcURL.phone} alt="phone" /><span>{translate('footer.TalkWithUs')}</span></button>
                    <button className='primary'><img className='icon' src={srcURL.message} alt="chat" /><span>{translate('footer.ChatWithUs')}</span></button>
                </CardFooterContact>
            </div>
            <div className="footer__btn-go-top">
                <button onClick={handleScrollToTop}><img src={srcURL.arrowTop} alt="arrow" /></button>
            </div>
            <div className="footer__policy">
                <div className="footer__policy--container">
                    <div className="footer__policy--container__policy">&copy; {translate('footer.card.policy')}<span>{translate('footer.card.copyright')}</span><a href={srcURL.privacyTitan}><span>{` ${translate('footer.card.terms')}`}</span></a></div>
                    <div className="footer__policy--container__social-icon">
                        <span>{translate('footer.connectUs')}</span>
                        <a target='blank' href={srcURL.facebookTitan}><img src={srcURL.facebook} alt="face" /></a>
                        <a target='blank' href={srcURL.twitterTitan}><img src={srcURL.twitter} alt="face" /></a>
                        <a target='blank' href={srcURL.linkinTitan}><img src={srcURL.linkin} alt="face" /></a>
                        <a target='blank' href={srcURL.youtubeTitan}><img src={srcURL.youtube} alt="face" /></a>
                    </div>
                </div>
            </div>
        </footer>
    )
}

export default Footer