import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { SliderItemDetail } from '../../Modal'
import { sliderType } from '../../SliderCustom/SliderType'

import './horizontalSliderStyles.scss'

const HorizontalSlider = ({ ...props }) => {

    const { sliderItem, subClass } = props
    const [openDetailModal, setOpenDetailModal] = useState(false)

    // Handle show detail slider with modal when click slider item
    const handleShowDetailModal = () => {
        if (subClass === sliderType.horizontalBoxPagination.subClass) {
            setOpenDetailModal(!openDetailModal)
        }
    }

    return (
        <div className={`horizontal-slider-item ${subClass}`} >
            <Link
                className='horizontal-slider-item__link'
                to={(subClass === sliderType.horizontalBoxPagination.subClass) ? '#' : sliderItem.url}
                target={(subClass === sliderType.horizontalBoxPagination.subClass) ? '' : '_blank'}
                onClick={handleShowDetailModal}
            >
                <div className='horizontal-slider-item__image'><img src={sliderItem.image} alt="horizontal" /></div>
                <h2 className='horizontal-slider-item__title'>{sliderItem.title}</h2>
                <h3 className='horizontal-slider-item__sub-title'>{sliderItem.subtitle}</h3>
            </Link>
            <p className='horizontal-slider-item__description'>{sliderItem.description}</p>
            {(subClass === sliderType.horizontalBoxPagination.subClass) && <button onClick={handleShowDetailModal} className='horizontal-slider-item__btn-read-more'>Read more {'>>'}</button>}

            <SliderItemDetail item={sliderItem} open={openDetailModal} setOpen={handleShowDetailModal} />
        </div>
    )
}

export default HorizontalSlider