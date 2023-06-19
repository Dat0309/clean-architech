import { configureStore } from '@reduxjs/toolkit';
import { SliderReducer, PostReducer, GeneralReducer } from './features';

const store = configureStore({
  reducer: {
    slider: SliderReducer,
    post: PostReducer,
    general: GeneralReducer
  },
});

export default store;
