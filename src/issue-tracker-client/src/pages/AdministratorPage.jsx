import React, { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { setUsers } from '../redux/slices/usersSlice';
import { doFetchAllUsers } from '../utils/api';

export default function AdministratorPage() {
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
					<h1 className="text-xl">Teams</h1>
					<label htmlFor="new-team-modal" className="btn modal-button btn-accent btn-xs">
						Add New Team
					</label>

					<input type="checkbox" id="new-team-modal" className="modal-toggle" />
					<div className="modal">
						<div className="modal-box relative">
							<label htmlFor="new-team-modal" className="btn btn-sm btn-circle absolute right-2 top-2">
								✕
							</label>
							<h3 className="text-lg font-bold">Create new team</h3>
							<button className="btn btn-info btn-xs">Create Team</button>
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
