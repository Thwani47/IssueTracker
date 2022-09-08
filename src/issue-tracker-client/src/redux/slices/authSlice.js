import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	user: sessionStorage.getItem('user') === null ? null : JSON.parse(sessionStorage.getItem('user')),
	isAuthenticated: sessionStorage.getItem('token') === null ? false : true,
	userId: sessionStorage.getItem('id') === null ? null : sessionStorage.getItem('id'),
	authToken: sessionStorage.getItem('token') === null ? null : sessionStorage.getItem('token')
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
		}
	}
});

export const { loginSuccess, logoutSuccess, userDataFetchSuccess } = authSlice.actions;

export const login = (id, token) => (dispatch) => {
	sessionStorage.setItem('id', id);
	sessionStorage.setItem('token', token);
	dispatch(loginSuccess({ id, token }));
};

export const setUserData = (user) => (dispatch) => {
	sessionStorage.setItem('user', JSON.stringify(user));
	dispatch(userDataFetchSuccess({ user }));
};

export const logout = () => (dispatch) => {
	sessionStorage.removeItem('id');
	sessionStorage.removeItem('token');
	sessionStorage.removeItem('user');
	dispatch(logoutSuccess());
};
export default authSlice.reducer;
