import React from 'react'
// import { Modal, Header, Image } from 'semantic-ui-react'
import { Header, Image, Modal, TransitionablePortal } from 'semantic-ui-react'
import srcURL from '../../../srcURL.json'

import './sliderItemDetailStyles.scss'

const SliderDetail = ({ ...props }) => {

    const { item, open, setOpen } = props

    return (
        <TransitionablePortal
            open={open}
        >
            <Modal
                dimmer='blurring'
                onClose={() => setOpen(false)}
                open={open}
                className='slider-detail-modal'
                >
                <Modal.Header className='slider-detail-modal__header'>
                    <button className='slider-detail-modal__header__close-btn' onClick={() => {setOpen(false)}}><img src={srcURL.iconCancel} alt="close" /></button>
                </Modal.Header>
                <Modal.Content image>
                    <Image size='medium' src={item.image} />
                    <Modal.Description className='slider-detail-modal__content'>
                        <Header className='slider-detail-modal__content__header'> 
                            <h2 className='content__header__title'>{item.title}</h2>
                            <h3 className='content__header__sub-title'>{item.subtitle}</h3>
                        </Header>
                        <p className='slider-detail-modal__content__description'>
                            {item.description}
                        </p>
                    </Modal.Description>
                </Modal.Content>
            </Modal>
        </TransitionablePortal>
    )
}

export default SliderDetail