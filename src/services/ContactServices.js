import RestRequest from "../rest/RestRequest";

class ContactService extends RestRequest {
    constructor() {
        super()
        this.url = this.url = process.env.REACT_APP_PATH_URL_CONTACT
    }

    async sendContactInfoAsync(body) {
        return await super.post(`${this.url}`, body)
    }
}

export default ContactService