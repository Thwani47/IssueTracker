import React, { useRef, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setTeams } from '../redux/slices/teamsSlice';
import { doAddNewTeam, doFetchAllTeams } from '../utils/api';

export default function NewTeamForm({ modalId }) {
	const [ error, setError ] = useState(null);
	const teamNameRef = useRef();
	const teamLeadRef = useRef();
	const dispatch = useDispatch();
	const users = useSelector((state) => state.users.users);

	const handleSubmit = async (e) => {
		e.preventDefault();

		const teamName = teamNameRef.current.value;
		const teamLead = teamLeadRef.current.value;

		const data = {
			teamName,
			teamLead
		};

		const { success, response, err } = await doAddNewTeam(data);

		if (success) {
			setError(null);
			if (response.message === 'Team Added Successfully') {
				teamNameRef.current.value = '';
				const allTeamsResponse = await doFetchAllTeams();

				if (allTeamsResponse.success) {
					dispatch(setTeams(allTeamsResponse.response.data.teams));
					document.getElementById(modalId).checked = false;
				}
			}
		} else {
			setError({ message: err.title ? err.title : err.message });
		}
	};
	return (
		<div className="form-control w-full max-w-xl self-center mt-5 p-4">
			{error === null ? null : <span className="text-red-700">{error.message}</span>}
			<form onSubmit={handleSubmit}>
				<label className="label">
					<span className="label-text">Team Name</span>
				</label>
				<input
					type="text"
					placeholder="Enter team name"
					className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
					autoComplete="on"
					ref={teamNameRef}
				/>
				<label className="label">
					<span className="label-text">Team Lead</span>
				</label>
				<select className="select select-bordered flex" ref={teamLeadRef}>
					{users &&
						users
							.filter((user) => user.userType === 2)
							.map((filteredUser, index) => (
								<option
									key={index}
									value={filteredUser.userId}
								>{`${filteredUser.firstName} ${filteredUser.lastName}`}</option>
							))}
				</select>

				<button type="submit" className="btn btn-info rounded-full w-32 mt-4 self-center">
					Submit
				</button>
			</form>
		</div>
	);
}
