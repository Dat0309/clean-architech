import { createSlice } from "@reduxjs/toolkit"
import { menu } from "../../config/MenuName"

const initialState = {
    menuActive: menu.home,
    currentWidth: window.innerWidth
}

const GeneralSlice = createSlice({
    name: 'general',
    initialState: initialState,
    reducers: {
        setActiveMenuModal: (state, action) => {
            state.menuActive = action.payload
        },
        setCurrentWidth: (state, action) => {
            state.currentWidth = action.payload
        }
    }
})

const { reducer, actions } = GeneralSlice

export const { setActiveMenuModal, setCurrentWidth } = actions

export default reducer