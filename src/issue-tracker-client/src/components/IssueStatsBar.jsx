import React from 'react';

export default function IssueStatBar({ issues }) {
	return (
		<div className="stats shadow self-center w-full cursor-auto">
			<div className="stat place-items-center">
				<div className="stat-title">Open Issues</div>
				<div className="stat-value text-red-500">
					{issues === null ? 0 : issues.filter((issue) => issue.issueStatus === 0).length}
				</div>
			</div>

			<div className="stat place-items-center">
				<div className="stat-title">In-Progress</div>
				<div className="stat-value text-blue-500">
					{issues === null ? 0 : issues.filter((issue) => issue.issueStatus === 1).length}
				</div>
				<div className="stat-desc text-secondary" />
			</div>

			<div className="stat place-items-center">
				<div className="stat-title">Closed Issues</div>
				<div className="stat-value text-green-500">
					{issues === null ? 0 : issues.filter((issue) => issue.issueStatus === 2).length}
				</div>
			</div>
		</div>
	);
}
