import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	user: null,
	isAuthenticated: sessionStorage.getItem('token') === null ? false : true,
	userId: sessionStorage.getItem('id'),
	authToken: sessionStorage.getItem('token')
};

export const authSlice = createSlice({
	name: 'auth',
	initialState,
	reducers: {
		loginSuccess: (state, action) => {
			state.isAuthenticated = true;
			state.userId = action.payload.id;
			state.authToken = action.payload.token;
		},
		userDataFetchSuccess: (state, action) => {
			state.user = action.payload.user;
		},
		logoutSuccess: (state) => {
			state.isAuthenticated = false;
			state.authToken = null;
			state.user = null;
			state.userId = null;
        },
	}
});

export const { loginSuccess, logoutSuccess, userDataFetchSuccess } = authSlice.actions;

export const login = (id, token) => (dispatch) => {
	sessionStorage.setItem('id', id);
	sessionStorage.setItem('token', token);
	dispatch(loginSuccess({ id, token }));
};

export const setUserData = (user) => (dispatch) => {
	dispatch(userDataFetchSuccess({ user }));
};

export const logout = () => (dispatch) => {
	dispatch(logoutSuccess());
};
export default authSlice.reducer;
