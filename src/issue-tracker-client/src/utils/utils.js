export const getRole = (roleValue) => {
	if (roleValue === 1) {
		return 'Administrator';
	} else if (roleValue === 2) {
		return 'Team Lead';
	}

	return 'Developer';
};
