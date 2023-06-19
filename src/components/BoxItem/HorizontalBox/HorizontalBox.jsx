import React from 'react'
import { Grid, Image, Container } from 'semantic-ui-react'

import './horizontalBoxStyles.scss'

const HorizontalBox = ({ ...props }) => {

    const {
        withLeftItem,
        withRightItem,
        image,
        bgColor,
        children,
        btn,
        fontSize,
    } = props

    const maxFontSize = 25

    return (
        <Grid className={`horizontal-box ${bgColor && 'bg'}`}>
            <Grid.Row>
                <Grid.Column width={withLeftItem}>
                    <Image className='horizontal-box__image' src={image} />
                </Grid.Column>
                <Grid.Column width={withRightItem}>
                    <Container
                        className='horizontal-box__content'>
                        <div>
                            <p className={(fontSize > maxFontSize) && 'gray-color'} style={{ fontSize: `${fontSize}px` }}>{children}</p>
                            {btn && (<button className='primary'>{btn}</button>)}
                        </div>
                    </Container>
                </Grid.Column>
            </Grid.Row>
        </Grid>
    )
}

export default HorizontalBox