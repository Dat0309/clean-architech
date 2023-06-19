import React from 'react'

import './fullBoxSliderStyles.scss'

const FullBoxSlider = ({...props}) => {

    const {sliderItem} = props

    return (
        <div className='full-box-item'>
            <img src={sliderItem.image} alt='imageSliderItem' />      
            <div className="full-box-item__content">
                <h2>{sliderItem.title}</h2>
                <p>{sliderItem.description}</p>
            </div>
        </div>
    )
}

export default FullBoxSlider