import { createSlice } from '@reduxjs/toolkit';

const initialState = {
	issues: null
};

export const issuesSlice = createSlice({
	name: 'issues',
	initialState,
	reducers: {
		issuesFetchSuccess: (state, action) => {
			state.issues = action.payload.issues;
		},
		clearIssuesSuccess: (state) => {
			state.issues = null;
		}
	}
});

export const { issuesFetchSuccess, clearIssuesSuccess } = issuesSlice.actions;

export const setIssues = (issues) => (dispatch) => {
	dispatch(issuesFetchSuccess({ issues }));
};

export const clearIssues = () => (dispatch) => {
	dispatch(clearIssuesSuccess());
};

export default issuesSlice.reducer;
