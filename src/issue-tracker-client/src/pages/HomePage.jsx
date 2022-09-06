import React from 'react';
import { useSelector } from 'react-redux';
import AdministratorPage from './AdministratorPage';
import DeveloperPage from './DeveloperPage';
import TeamLeadPage from './TeamLeadPage';

export default function HomePage() {
    const auth = useSelector((state) => state.auth);
    
    if (auth.user == null){
        return <h1>Loading</h1>
    }
	const userType = auth.user.userType;
	if (userType === 0) {
		return <DeveloperPage />;
	} else if (userType === 1) {
		return <AdministratorPage />;
	} else {
		return <TeamLeadPage />;
	}
}
