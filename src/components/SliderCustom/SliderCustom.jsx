import React from 'react'
import { Swiper, SwiperSlide } from "swiper/react"
import { useSelector } from 'react-redux';
import { sliderType } from './SliderType';
import { FullBoxSlider, HorizontalSlider, ImageBoxSlider } from '../SliderItem';

import 'swiper/swiper.min.css';
import 'swiper/modules/pagination/pagination.min.css';
import 'swiper/modules/navigation/navigation.min.css';

import './sliderCustomStyles.scss'
import { screenType } from '../../config/ScreenType';

const SliderCustom = ({ ...props }) => {

  const { type } = props
  const autoplayDelay = 5000
  const { allSliders } = useSelector(state => state.slider)
  const { currentWidth } = useSelector(state => state.general)
  const { data, status } = allSliders

  /**
   * Returns an array of sliders have type id
   *
   * @param {Number} typeID The type id of slider.
   * @return {Array} The array of sliders have type id
   */
  const getSliderByType = (typeID) => {
    return data.filter(x => (x.id === typeID))[0]
  }

  /**
   * Render slider full box type
   *
   * @return {Object} The JSX.Element to display UI
   */
  const renderFullBoxSlider = () => {

    let sliders = getSliderByType(sliderType.fullBox.typeID);

    return (
      sliders.sliders.map((item, index) =>
      (
        <SwiperSlide key={index}><FullBoxSlider sliderItem={item} /></SwiperSlide>
      ))
    )
  }

  /**
   * Render slider horizontal box type
   *
   * @param {Object} horizontalType The horizontal box slider type of slider.
   * @return {Object} The JSX.Element to display UI
   */
  const renderHorizontalBoxSlider = (horizontalType) => {

    let sliders = getSliderByType(horizontalType.typeID);

    return (
      sliders.sliders.map((item, index) =>
      (
        <SwiperSlide key={index}><HorizontalSlider subClass={horizontalType.subClass || ''} sliderItem={item} /></SwiperSlide>
      ))
    )
  }

  /**
   * Render slider image box type
   *
   * @param {Object} imageType The image box slider type of slider.
   * @return {Object} The JSX.Element to display UI
   */
  const renderImageBoxSlider = (imageType) => {

    let sliders = getSliderByType(imageType.typeID)

    return (
      sliders.sliders.map((item, index) =>
      (
        <SwiperSlide key={index}><ImageBoxSlider subClass={imageType.subClass || ''} sliderItem={item} /></SwiperSlide>
      ))
    )
  }

  /**
   * Returns number of slides per view to display UI
   *
   * @return {Number} The number of slides per view to display UI.
   */
  const setSlidesPerView = () => {
    if (currentWidth <= screenType.mobileS) {
      return type.config.slidesPerView.mobileS || type.config.slidesPerView.normal
    }
    else if (currentWidth <= screenType.mobileL) {
      return type.config.slidesPerView.mobileL || type.config.slidesPerView.normal
    }
    else if (currentWidth <= screenType.tablet) {
      return type.config.slidesPerView.tablet || type.config.slidesPerView.normal
    }
    return type.config.slidesPerView.normal
  }

  /**
   * Returns slider with type requirement.
   *
   * @return {Object} The JSX.Element to display UI.
   */
  const renderSliderByType = () => {
    switch (type.text) {
      case sliderType.fullBox.text:
        return renderFullBoxSlider()
      case sliderType.horizontalBoxBasic.text:
        return renderHorizontalBoxSlider(sliderType.horizontalBoxBasic)
      case sliderType.horizontalBox.text:
        return renderHorizontalBoxSlider(sliderType.horizontalBox)
      case sliderType.horizontalBoxPagination.text:
        return renderHorizontalBoxSlider(sliderType.horizontalBoxPagination)
      case sliderType.imageBoxBasic.text:
        return renderImageBoxSlider(sliderType.imageBoxBasic)
      case sliderType.imageBox.text:
        return renderImageBoxSlider(sliderType.imageBox)
      default:
        return ''
    }
  }

  return (
    <Swiper
      pagination={type.config.pagination || ''}
      navigation={type.config.navigation || false}
      modules={type.config.modules || []}
      slidesPerView={setSlidesPerView()}
      loop={type.config.loop || false}
      spaceBetween={type.config.spaceBetween || 0}
      autoplay={{
        delay: autoplayDelay,
        disableOnInteraction: false,
      }}
      className={`slider-custom ${type.text}`}
    >
      {status.success ? renderSliderByType() : (<SwiperSlide></SwiperSlide>)}
    </Swiper>
  )
}

export default SliderCustom