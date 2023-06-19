import React from 'react'
import { Link } from 'react-router-dom'

import './imageBoxSliderStyles.scss'

const ImageBoxSlider = ({ ...props }) => {

    const { sliderItem, subClass } = props

    return (
        <div className={`image-box-slider ${subClass}`}>
            <Link to={sliderItem.url} target="_blank">
                <img src={sliderItem.image} alt="ImageBoxSlider" />
            </Link>
        </div>
    )
}

export default ImageBoxSlider