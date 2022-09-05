import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	theme: 'dark'
};

export const themeSlice = createSlice({
	name: 'theme',
	initialState,
	reducers: {
		switchTheme: (state) => {
			state.theme = state.theme === 'dark' ? 'light' : 'dark';
		}
	}
});

export const { switchTheme } = themeSlice.actions;
export default themeSlice.reducer;
