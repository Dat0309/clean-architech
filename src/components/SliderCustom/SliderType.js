import { Navigation, Pagination, Autoplay } from "swiper"
import { slidesPerView } from "../../config/SlidesPerView"
import { spaceBetween } from "../../config/SpaceBetween"

export const sliderType = {
    fullBox: {
        text: 'full-box',
        typeID: 1,
        config: {
            pagination: {
                type: "fraction",
            },
            loop: true,
            navigation: true,
            modules: [Navigation, Pagination, Autoplay],
            slidesPerView: {
                normal: slidesPerView.oneSlide
            }
        }
    },
    horizontalBoxBasic: {
        text: 'horizontal-box-basic',
        subClass: 'basic',
        typeID: 2,
        config: {
            slidesPerView: {
                normal: slidesPerView.threeSlides,
                mobileS: slidesPerView.oneSlide,
                mobileL: slidesPerView.oneSlide,
                tablet: slidesPerView.oneSlide
            }, 
            spaceBetween: spaceBetween.normalSpace,
        }
    },
    horizontalBox: {
        text: 'horizontal-box-slide',
        typeID: 3,
        config: {
            navigation: true,
            modules: [Navigation, Autoplay],
            slidesPerView: {
                normal: slidesPerView.threeSlides,
                mobileS: slidesPerView.oneSlide,
                mobileL: slidesPerView.oneSlide,
                tablet: slidesPerView.twoSlides
            }, 
            spaceBetween: spaceBetween.normalSpace,
        }
    },
    horizontalBoxPagination: {
        text: 'horizontal-box-pagination',
        subClass: 'pagination',
        typeID: 6,
        config: {
            pagination: {
                clickable: true,
            },
            modules: [Pagination, Autoplay],
            slidesPerView: {
                normal: slidesPerView.oneSlide,
            }, 
        }
    },
    imageBoxBasic: {
        text: 'image-box-basic',
        subClass: 'basic',
        typeID: 7,
        config: {
            modules: [Autoplay],
            slidesPerView: {
                normal: slidesPerView.fiveSlides,
                mobileS: slidesPerView.oneSlide,
                mobileL: slidesPerView.twoSlides,
                tablet: slidesPerView.threeSlides
            }, 
            spaceBetween: spaceBetween.normalSpace
        }
    },
    imageBox: {
        text: 'image-box',
        typeID: 5,
        config: {
            navigation: true,
            modules: [Navigation, Autoplay],
            slidesPerView: {
                normal: slidesPerView.fourSlides,
                mobileS: slidesPerView.oneSlide,
                mobileL: slidesPerView.twoSlides,
                tablet: slidesPerView.threeSlides
            }, 
            spaceBetween: spaceBetween.smallSpace
        }
    }
}