import React from "react"

import './bannerStyles.scss'

const Banner = ({...props}) => {

    const {title, bgImage} = props

    /**
     * Render Title Banner With Images Array
     *
     * @return {Object} the JSX.Element to render UI
     */
    const renderTitleImage = () => {
        return (
            title.map((item, index) => (
                <div key={index} className="banner__title-image"><img src={item} alt={index} /></div>
            ))
        )
    }

    return (
        <div className="banner">
            {Array.isArray(title) ? (
                <div className="banner__title banner__bg-title">
                    {renderTitleImage()}
                </div>
            ) : (
                <div className="banner__title">
                    {title}
                </div>
            )}
            
            <div className="banner__bg-image" style={{ backgroundImage: `url(${bgImage})` }}></div>
        </div>
    )
}

export default Banner