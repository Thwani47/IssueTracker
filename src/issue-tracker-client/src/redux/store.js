import { configureStore } from '@reduxjs/toolkit';
import themeReducer from './slices/themeSlice';
import authReducer from './slices/authSlice';
import usersReducer from './slices/usersSlice';
import teamsReducer from './slices/teamsSlice';
import productsReducer from './slices/productsSlice';
import issuesProducer from './slices/issuesSlice';

export const store = configureStore({
	reducer: {
		theme: themeReducer,
		auth: authReducer,
		users: usersReducer,
		teams: teamsReducer,
		products: productsReducer,
		issues: issuesProducer
	}
});
