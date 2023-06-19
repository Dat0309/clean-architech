import React from "react"
import "./aboutUsContentStyles.scss"
import { convertStringToArray } from "../../config/Function"

const AboutUsContent = ({ ...props }) => {

    const { content, isList = true, isSpan = false } = props

    return (
        <>
            {isList ?
                (<ul className="aboutpage__content--list">
                    {content && convertStringToArray(content, "*").map((value, index) => (
                        <li key={index}>{value}</li>
                    ))}
                </ul>) :
                (content && convertStringToArray(content, "*").map((value, index) => {
                    return isSpan ? (<span key={index}>{value}</span>) : (<p key={index}>{value}</p>) 
                }))
            }
        </>
    )
}

export default AboutUsContent