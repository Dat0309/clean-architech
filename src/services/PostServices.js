import { convertObjectToQueryString } from "../config/Function";
import RestRequest from "../rest/RestRequest";

class PostServices extends RestRequest {
    constructor() {
        super()
        this.url = process.env.REACT_APP_PATH_URL_POST
    }

    /**
     * Returns response from call API with type of post.
     *
     * @param {Number} type The type want to send request.
     * @return {Promise} response from API.
     */
    async getByTypeAsync(type) {
        return await super.get(`${this.url}type/${type}`)
    }

    /**
     * Returns response from call API with type and pagination
     *
     * @param {Number} type The type want to send request.
     * @param {Object} formData The object contains query as key and value.
     * @return {Promise} response from API.
     */
    async getByTypeWithPaginationAsync(type, formData) {
        let queryString = convertObjectToQueryString(formData)
        return await super.get(`${this.url}typeWithPagination/${type}${queryString}`)
    }
}

export default PostServices