import React from 'react';

export default function TeamsTable({ teams }) {
	return (
		<div className="overflow-x-auto w-full">
			<table className="table w-full">
				<thead>
					<tr>
						<th>Team Name</th>
						<th>Team Lead</th>
						<th />
					</tr>
				</thead>
				<tbody>
					{teams.map((team, index) => (
						<tr key={index}>
							<td>
								<div className="flex items-center space-x-3">
									<div>
										<div className="font-bold">{team.teamName}</div>
									</div>
								</div>
							</td>
							<td>{`${team.firstName} ${team.lastName}`}</td>
							<th>
								<a href={`team/${team.teamId}`} className="btn btn-ghost btn-xs">details</a>
							</th>
						</tr>
					))}
				</tbody>
			</table>
		</div>
	);
}
