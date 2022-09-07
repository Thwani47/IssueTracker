import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	teams: null
};

export const teamsSlice = createSlice({
	name: 'teams',
	initialState,
	reducers: {
		teamsFetchSuccess: (state, action) => {
			state.teams = action.payload.teams;
		}
	}
});

export const { teamsFetchSuccess } = teamsSlice.actions;

export const setTeams = (teams) => (dispatch) => {
	dispatch(teamsFetchSuccess({ teams }));
};

export default teamsSlice.reducer;
