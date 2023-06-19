import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import PostServices from "../../services/PostServices";
import { getKeyFromValueObj } from "../../config/Function";
import { postType } from "../../config/PostType";

const postServices = new PostServices()

/**
 * Returns response when call API get Post with type.
 *
 * @param {Number} type The type id of post.
 * @return {Object} result The response from API
 */
export const getPostAPIByType = createAsyncThunk(
    'post/getPostAPIByType',
    async (type) => {
        let result = await postServices.getByTypeAsync(type)
        if (!result.succeeded) {
            throw new Error(result.message)
        } 
        return result  
    }
)

/**
 * Returns response when call API get Blogs with query string.
 *
 * @param {Object} formData The object query string have key value match query string from link API.
 * @return {Object} result The response from API
 */
export const getBlogsAPIWithPagination = createAsyncThunk(
    'post/getBlogsAPIWithPagination',
    async (formData) => {
        let result = await postServices.getByTypeWithPaginationAsync(postType.blogs, formData)
        if (!result.succeeded) {
            throw new Error(result.message)
        } 
        return result  
    }
)

const initialState = {
    news: {
        data: [],
        status: {
            pending: false,
            success: false,
            rejected: false
        }
    },
    blogs: {
        data: [],
        status: {
            pending: false,
            success: false,
            rejected: false
        }
    },
    blogsWithPagination: {
        data: [],
        pageSize: 6,
        totalPages: 1,
        status: {
            pending: false,
            success: false,
            rejected: false
        }
    }
}

const PostSlice = createSlice({
    name: 'post',
    initialState: initialState,
    extraReducers: {
        // Get Post By Type When Call API
        [getPostAPIByType.pending]: (state, {meta}) => {
            let key = getKeyFromValueObj(postType, meta.arg)
            state[key].status = {pending: true, success: false, rejected: false}            
        },
        [getPostAPIByType.fulfilled]: (state, {meta, payload}) => {            
            let key = getKeyFromValueObj(postType, meta.arg)
            state[key].data = payload.data
            state[key].status = {...state[key].status, pending: false, success: true}            
        },
        [getPostAPIByType.rejected]: (state, {meta, error}) => {
            let key = getKeyFromValueObj(postType, meta.arg)
            alert(error.message)
            state[key].status = {...state[key].status, pending: false, rejected: true}            
        },

         // Get Blogs With Pagination When Call API
         [getBlogsAPIWithPagination.pending]: (state) => {            
            state.blogsWithPagination.status = {pending: true, success: false, rejected: false}            
        },
        [getBlogsAPIWithPagination.fulfilled]: (state, {payload}) => {                        
            // state.blogsWithPagination.data = payload.data
            state.blogsWithPagination.status = {...state.blogsWithPagination.status, pending: false, success: true}            
            state.blogsWithPagination.data = payload.data
            state.blogsWithPagination.totalPages = payload.totalPages
        },
        [getBlogsAPIWithPagination.rejected]: (state) => {            
            state.blogsWithPagination.status = {...state.blogsWithPagination.status, pending: false, rejected: true}            
        }
    }
})

const { reducer } = PostSlice

export default reducer