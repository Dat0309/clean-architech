import React, { useEffect } from 'react'
import { Banner, Footer, Header, AboutUsContent } from '../../components'
import srcURL from "../../srcURL.json"
import { setActiveMenuModal } from '../../redux/features/GeneralSlice'
import { useDispatch } from 'react-redux'
import { useTranslation } from 'react-i18next'
import { menu } from '../../config/MenuName'
import "./AboutUs.scss"

const AboutUs = () => {

  const { t } = useTranslation()
  const translate = t
  const dispatch = useDispatch()


  // Highlight about text on MenuModal
  useEffect(() => {
    dispatch(setActiveMenuModal(menu.about))
  }, []) // eslint-disable-line react-hooks/exhaustive-deps

  // Make a scroll the screen when starting
  useEffect(() => {
    const scrollSreen = setTimeout(() => {
      window.scrollTo(0, window.innerHeight - 100)
    }, 1500)

    return () => clearTimeout(scrollSreen)
  }, [])

  return (
    <div className='aboutpage'>
      <Header />
      <Banner title={translate('menu.AboutUs')} bgImage={srcURL.aboutUsBackgroundImage} />
      <div className='aboutpage__content'>
        {/* ======= WHO WE ARE ======= */}
        <div className="aboutpage__content__whoweare container">
          <h2>{translate('aboutus.whoweare.title')}</h2>
          <p>
            <span className='aboutpage__content--bold'>{translate('aboutus.whoweare.boldContent')} </span>
            {translate('aboutus.whoweare.normalContent')}
          </p>
          <AboutUsContent isList={false}
            content={translate('aboutus.whoweare.content')} />
          <p><span className='aboutpage__content--bold'>{translate('aboutus.vision.title')}</span></p>
          <p>{translate('aboutus.vision.content')}</p>
          <p><span className='aboutpage__content--bold'>{translate('aboutus.mission.title')}</span></p>
          <AboutUsContent content={translate('aboutus.mission.content')} />
          <p><span className='aboutpage__content--bold'>{translate('aboutus.corevalues.title')}</span></p>
          <AboutUsContent content={translate('aboutus.corevalues.content')} />
        </div>
        {/*======= WHY TITAN TECHNOLOGY =======*/}
        <div className='aboutpage__content__whytitan container'>
          <h2>{translate('aboutus.whytitan.title')}</h2>
          <p><span className='aboutpage__content--bold'>{translate('aboutus.whytitan.subtitle')}</span></p>
          <AboutUsContent content={translate('aboutus.whytitan.content')} />
        </div>
        {/*======= TITAN TECHNOLOGY’S CULTURE =======*/}
        <div className='aboutpage__content__culture container'>
          <h2>{translate('aboutus.culture.title')}</h2>
          <div className="aboutpage__content__culture__image">
            <span><img src={srcURL.aboutUsImageDes1} alt="about1" /></span>
            <span><img src={srcURL.aboutUsImageDes2} alt="about2" /></span>
          </div>
          <p><span className='aboutpage__content--bold'>{translate('aboutus.culture.subtitle')}</span></p>
          <p>{translate('aboutus.culture.children')}</p>
          <AboutUsContent content={translate('aboutus.culture.content')} />
          <p>{translate('aboutus.culture.lastchild')}</p>
        </div>
        {/*======= CONTACT US =======*/}
        <div className='aboutpage__content__contact container'>
          <h2>{translate('aboutus.contact.title')}</h2>
          <p>
            <span className='aboutpage__content--bold'>{translate('aboutus.contact.subtitle')}</span>
            <AboutUsContent
              isList={false}
              isSpan={true}
              content={translate('aboutus.contact.content')} />
            <span>{translate('aboutus.contact.label')} <a href="mailto:info@titancorpvn.com">{translate('aboutus.contact.email')}</a></span>
          </p>
        </div>
      </div>
      <Footer />
    </div>
  )
}

export default AboutUs