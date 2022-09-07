import React from 'react';
import { useParams } from 'react-router-dom';

export default function TeamPage() {
	const params = useParams();
	return (
		<div>
			<h1>Team {params.teamId}</h1>
		</div>
	);
}
