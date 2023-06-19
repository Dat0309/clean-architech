import RestRequest from "../rest/RestRequest";


class SliderService extends RestRequest {
    constructor() {
        super()
        this.url = process.env.REACT_APP_PATH_URL_SLIDER
        this.urlType = process.env.REACT_APP_PATH_URL_SLIDER_TYPE
    }

    async getByTypeAsync(type) {
        return await super.get(`${this.url}type/${type}`)
    }

    async getAllSliderAsync() {
        return await super.get(`${this.urlType}getAllWithSliderTable`)
    }
}

export default SliderService