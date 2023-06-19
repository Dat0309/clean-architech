import React, { useEffect, useState } from "react"
import { Grid, Form } from "semantic-ui-react"
import ContactService from "../../services/ContactServices"

import "./contactStyles.scss"
import { regex } from "../../config/Regex"
import { getCurrentDate } from "../../config/Function"
import { useTranslation } from 'react-i18next';
import { maxLengthInput } from "../../config/MaxLengthInput"

const names = Object.freeze({
    Name: 'name',
    Email: 'email',
    Phone: 'phone',
    Subject: 'subject',
    Description: 'description',
})

const Contact = () => {

    const { t } = useTranslation();
    const translate = t;

    const contactService = new ContactService();

    const formInitialDetails = {
        name: '',
        email: '',
        phone: '',
        subject: '',
        description: '',
        createdtime: getCurrentDate(),
        isValid: false
    }

    const [formValues, setFormValues] = useState(formInitialDetails);
    const [formError, setFormError] = useState({});
    const [issubmit, setSubmit] = useState(false);
    const [showError, setShowError] = useState(false);


    /**
     * Check if the user entered the correct phone number format or not
     * 
     * @return {Boolean} true when in correct format
     */
    const isVietnamesePhoneNumberValid = (number) => {
        return regex.phoneNumber.test(number);
    }

    /**
     * Handle blocking the user's data pasting into input
     * 
     */
    const handlePaste = (e) => {
        e.preventDefault();
    }

    /**
     *  Check email format and phone number entered by user
     * 
     *  @return {Object} errors
     */
    const validationForm = () => {
        const errors = {};
        const { email, phone, name, description, subject } = formValues;
        // Check if condition about format with email and phone number 
        if (!regex.email.test(email) || !isVietnamesePhoneNumberValid(phone)) {
            errors.invalidEmailOrPhone = translate("contact.errors.EmailOrPhone")
            setShowError(true);
        // Check max length of data field
        } else if (name.length > maxLengthInput.name ||
            description.length > maxLengthInput.description ||
            email.length > maxLengthInput.email ||
            subject.length > maxLengthInput.subject) {
            errors.invalidLength = translate("contact.errors.MaxLength")
            setShowError(true);
        }
        else {
            setShowError(false);
        }
        return errors;
    }

    /**
     * Check the user has entered all the fields completely
     * 
     * @return {Boolean} true when all variables are entered, otherwise
     */
    const validateInputs = () => {
        const { name, email, phone, subject, description } = formValues
        if (!name || !email || !phone || !subject || !description) {
            return false;
        }
        return true
    }

    /**
     * Set state for isValid based on results of validateInputs function
     */
    useEffect(() => {
        setFormValues((prevState) => ({
            ...prevState,
            isValid: validateInputs(),
        }));
    }, [formValues.name, formValues.email, formValues.phone, formValues.description, formValues.subject])


    const handleFormUpdate = (e) => {
        const { name, value } = e.target;
        setFormValues({
            ...formValues,
            [name]: value
        });
    }

    /**
    * Set attribute maxLength = 10 for phone number
    */
    const handleMaxInputPhoneNumber = (e) => {
        if (e.target.value.length > maxLengthInput.phone) {
            const phoneValidated = (e.target.value.slice(0, maxLengthInput.phone));
            setFormValues({
                ...formValues,
                phone: phoneValidated
            });
        }
    }

    // POST user's contact information to API
    useEffect(() => {
        // Handling when user click submit button to post contact info
        if (Object.keys(formError).length === 0 && issubmit) {
            setFormValues({
                ...formValues,
                isValid: false
            });
            setSubmit(false);
            contactService.sendContactInfoAsync(JSON.stringify(
                formValues))
                .then(res => {
                    // Handling when post successfully
                    if (res && res.succeeded) {
                        setFormValues(formInitialDetails);
                        alert(res.message);
                    } // Handling when post failed
                    else if (res) {
                        alert(res.message);
                    } // Handling when response undefined
                    else {
                        console.log('Res undefined');
                    }
                })
                .catch(e => console.log(e));
        }
    }, [issubmit, formError]);

    // Handle when user click submit button
    const handleSubmit = (e) => {
        e.preventDefault();
        setFormError(validationForm());
        setSubmit(true)
    }

    return (
        <Form onSubmit={handleSubmit} className="contact">
            <div className={`contact__display-error-message ${showError && 'show'}`}>
                {(formError.invalidEmailOrPhone) || formError.invalidLength || ""}
            </div>
            <Grid.Row>
                <Grid columns="3" className="contact__form">
                    <Grid.Column width="6" className="contact__form-column">
                        <Form.Input name={names.Name} onPaste={handlePaste} icon='user outline' iconPosition='left' placeholder={translate("contact.input.Username")}
                            value={formValues.name}
                            onChange={handleFormUpdate}
                        ></Form.Input>
                        <Form.Input name={names.Email} onPaste={handlePaste} icon='mail outline' iconPosition='left' placeholder={translate("contact.input.Email")}
                            value={formValues.email}
                            onChange={handleFormUpdate}
                        ></Form.Input>
                        <Form.Input name={names.Phone} onPaste={handlePaste} type="number" icon='phone' iconPosition='left' placeholder={translate("contact.input.Phone")}
                            value={formValues.phone}
                            onChange={(e) => {
                                handleFormUpdate(e);
                                handleMaxInputPhoneNumber(e);
                            }}
                        ></Form.Input>
                    </Grid.Column>
                    <Grid.Column width="6" className="contact__form-column">
                        <Form.Input name={names.Subject} onPaste={handlePaste} icon='book' iconPosition='left' placeholder={translate("contact.input.Subject")}
                            value={formValues.subject}
                            onChange={handleFormUpdate}
                        ></Form.Input>
                        <Form.TextArea name={names.Description} rows="5" className="textarea" placeholder={translate("contact.textarea.Description")}
                            value={formValues.description}
                            onChange={handleFormUpdate}
                        ></Form.TextArea>
                    </Grid.Column>
                    <Grid.Column width="4" className="contact__form-column button-area">
                        <button className={`primary buttonRequest ${formValues.isValid && "active"}`}>{translate("contact.button.Request")}</button>
                    </Grid.Column>
                </Grid>
            </Grid.Row>
        </Form >
    )
}

export default Contact