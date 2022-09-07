import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import NewTeamForm from '../components/NewTeamForm';
import TeamsTable from '../components/TeamsTable';
import { setTeams } from '../redux/slices/teamsSlice';
import { setUsers } from '../redux/slices/usersSlice';
import { doFetchAllTeams, doFetchAllUsers } from '../utils/api';

export default function AdministratorPage() {
	const teams = useSelector((state) => state.teams.teams);
	const dispatch = useDispatch();
	useEffect(
		() => {
			async function getAllUsers() {
				const { success, response } = await doFetchAllUsers();
				if (success) {
					if (response.message === 'Users found') {
						dispatch(setUsers(response.data.users));
					}
				}
			}

			getAllUsers();
		},
		[ dispatch ]
	);

	useEffect(
		() => {
			async function getAllTeams() {
				const { success, response } = await doFetchAllTeams();
				if (success) {
					if (response.message === 'Teams found') {
						dispatch(setTeams(response.data.teams));
					}
				}
			}

			getAllTeams();
		},
		[ dispatch ]
	);
	return (
		<div className="flex flex-col">
			<div className="flex flex-row">
				<div className="stats shadow self-center w-full cursor-auto">
					<div className="stat place-items-center">
						<div className="stat-title">Total Issues</div>
						<div className="stat-value">30</div>
					</div>

					<div className="stat place-items-center">
						<div className="stat-title">In-Progress</div>
						<div className="stat-value text-blue-500">8</div>
						<div className="stat-desc text-secondary" />
					</div>

					<div className="stat place-items-center">
						<div className="stat-title">New Issues</div>
						<div className="stat-value text-red-500">22</div>
					</div>
				</div>
			</div>
			<div className="flex-flex-row self-start mt-3">
				<button className="btn btn-error btn-xs">New Issue</button>
			</div>
			<div className="flex flex-row mt-3 justify-between">
				<div className="flex flex-col">
					<h1 className="text-xl text-accent font-bold self-start underline mt-3">Teams</h1>
					{teams && teams.length > 0 ? <TeamsTable teams={teams} /> : null}

					<label htmlFor="new-team-modal" className="btn modal-button btn-accent btn-xs w-32 mt-2">
						Add New Team
					</label>

					<input type="checkbox" id="new-team-modal" className="modal-toggle" />
					<div className="modal">
						<div className="modal-box relative">
							<label htmlFor="new-team-modal" className="btn btn-sm btn-circle absolute right-2 top-2">
								✕
							</label>
							<h3 className="text-lg font-bold">Create new team</h3>
							<NewTeamForm modalId="new-team-modal" />
						</div>
					</div>
				</div>
				<div className="flex flex-col">
					<h1 className="text-xl">Products</h1>
					<button className="btn btn-accent btn-xs">Add New Product</button>
				</div>
			</div>
		</div>
	);
}
