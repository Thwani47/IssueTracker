import { configureStore } from '@reduxjs/toolkit';
import themeReducer from './slices/themeSlice';
import authReducer from './slices/authSlice';
import usersReducer from './slices/usersSlice'

export const store = configureStore({
	reducer: {
		theme: themeReducer,
		auth: authReducer,
		users : usersReducer
	}
});
