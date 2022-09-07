import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	users: null
};

export const usersSlice = createSlice({
	name: 'users',
	initialState,
	reducers: {
		usersFetchSuccess: (state, action) => {
			state.users = action.payload.users;
		},
		clearUsersSuccess: (state) => {
			state.users = null;
		}
	}
});

export const { usersFetchSuccess, clearUsersSuccess } = usersSlice.actions;

export const setUsers = (users) => (dispatch) => {
	dispatch(usersFetchSuccess({ users }));
};

export const clearUsers = () => (dispatch) => {
	dispatch(clearUsersSuccess());
};

export default usersSlice.reducer;
