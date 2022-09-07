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
		},
		clearTeamsSuccess: (state) => {
			state.teams = null;
		}
	}
});

export const { teamsFetchSuccess, clearTeamsSuccess } = teamsSlice.actions;

export const setTeams = (teams) => (dispatch) => {
	dispatch(teamsFetchSuccess({ teams }));
};

export const clearTeams = () => (dispatch) => {
	dispatch(clearTeamsSuccess());
};

export default teamsSlice.reducer;
