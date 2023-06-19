import _fetch from "isomorphic-unfetch";
import { statusCode } from "../config/StatusCode";

class RestRequest {
    constructor() {
        this.baseURL = process.env.REACT_APP_BASE_URL
        this.apiKey = process.env.REACT_APP_API_KEY

        this.config = {
            method: '',
            headers: {
                'Content-Type': 'application/json',
                'apiKey': this.apiKey
            },
        }
    }

    async get(url) {
        return await this.fetchAsync(this.baseURL + url, { ...this.config, method: 'GET' })
    }

    async post(url, body) {
        return await this.fetchAsync(this.baseURL + url, { ...this.config, method: 'POST', body: body })
    }

    async put(url, body) {
        return await this.fetchAsync(this.baseURL + url, { ...this.config, method: 'POST', body: body })
    }

    async delete(url, id) {
        return await this.fetchAsync(this.baseURL + url + id, { method: 'DELETE' })
    }

    async fetchAsync(url, config) {
        let response = await _fetch(url, config)
        return await this.catchStatusResponse(response)
    }

    async catchStatusResponse(response) {
        switch (response.status) {
            case statusCode.Sucess.code:
                return await response.json()
            case statusCode.BadRequest.code:
                console.log(statusCode.BadRequest.msg);
                return await response.json()
            case statusCode.AuthenticationAccess.code:
                let msg = await response.text()
                throw new Error(`${statusCode.AuthenticationAccess.msg}: ${msg}`)
            case statusCode.NotFound.code:            
                throw new Error(`${statusCode.NotFound.msg}: ${response.url}`)
            case statusCode.ServerError.code:
                throw new Error(statusCode.ServerError.msg)
            default:
                return response
        }
    }
}

export default RestRequest