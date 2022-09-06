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
		}
	}
});

export const { usersFetchSuccess } = usersSlice.actions;

export const setUsers = (users) => (dispatch) => {
	dispatch(usersFetchSuccess({ users }));
};

export default usersSlice.reducer;
