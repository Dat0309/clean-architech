import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import SliderService from "../../services/SliderServices";

const sliderServices = new SliderService();

/**
 * Returns response when call API get all slider.
 * 
 * @return {Object} result The response from API
 */
export const getAllSliderAPI = createAsyncThunk(
    'slider/getAllSliderAPI',
    async () => {
        const result = await sliderServices.getAllSliderAsync()    
        if (!result.succeeded) {
            throw new Error(result.message)
        }   
        return result
    }
)

/**
 * Returns response when call API get slider by type.
 * 
 * @param {Number} type The type id of slider.
 * @return {Object} result The response from API
 */
export const getSliderByTypeAPI = createAsyncThunk(
    'slider/getSliderByTypeAPI',
    async (type) => {
        const result = await sliderServices.getByTypeAsync(type)
        if (!result.succeeded) {
            throw new Error(result.message)
        } 
        return result
    }
)

const initialState = {
    allSliders: {
        data: [],
        status: {
            pending: false,
            success: false,
            rejected: false
        }
    },
    slidersType: {
        data: [],
        status: {
            pending: false,
            success: false,
            rejected: false
        } 
    },
}

const SliderSlice = createSlice({
    name: 'slider',
    initialState: initialState,
    extraReducers: {
        // Get Slider By Type When Call API
        [getSliderByTypeAPI.pending]: (state) => {
            state.slidersType.status = {pending: true, success: false, rejected: false}      
        },
        [getSliderByTypeAPI.fulfilled]: (state, {payload}) => {
            state.slidersType = payload.data
            state.slidersType.status = {...state.sliderType.status, pending: false, success: true}    
        },
        [getSliderByTypeAPI.rejected]: (state) => {            
            state.slidersType.status = {...state.sliderType.status, pending: false, rejected: true}    
        },

        // Get All Slider When Call API
        [getAllSliderAPI.pending]: (state) => {           
            state.allSliders.status = {pending: true, success: false, rejected: false}      
        },
        [getAllSliderAPI.fulfilled]: (state, {payload}) => {            
            state.allSliders.data = payload.data
            state.allSliders.status = {...state.allSliders.status, pending: false, success: true}          
        },
        [getAllSliderAPI.rejected]: (state, action) => {            
            alert(action.error.message)
            state.allSliders.status = {...state.allSliders.status, pending: false, rejected: true}          
        },
    }
})

const { reducer, actions } = SliderSlice

export const { getSlideAPIByType } = actions

export default reducer