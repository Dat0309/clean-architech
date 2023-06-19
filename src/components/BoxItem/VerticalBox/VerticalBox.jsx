import React from 'react'
import { Link } from 'react-router-dom'
import { Card, Image } from 'semantic-ui-react'
import './verticalBoxStyles.scss'

const VerticalBox = ({ ...props }) => {

    const {
        image,
        header,
        author,
        description,
        postdate,
        link
    } = props

    return (
        <div className='vertical-box'>
            <Card>
                <Link to={link} target='_blank'><Image src={image} /></Link>
                <Card.Content>
                    <Link to={link} target='_blank'><Card.Header>{header}</Card.Header></Link>
                    <Card.Meta>
                        {author && (<span>By {author}</span>)}
                        {postdate && (<span> - {postdate}</span>)}
                    </Card.Meta>
                    <Card.Description>{description}</Card.Description>
                </Card.Content>
            </Card>
        </div>
    )
}

export default VerticalBox;