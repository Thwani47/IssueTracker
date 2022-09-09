import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { setIssues } from '../redux/slices/issuesSlice';
import { setProducts } from '../redux/slices/productsSlice';
import { setTeams } from '../redux/slices/teamsSlice';
import { setUsers } from '../redux/slices/usersSlice';
import { doFetchAllIssues, doFetchAllProducts, doFetchAllTeams, doFetchAllUsers } from '../utils/api';

export const useFetchAllProducts = () => {
	const dispatch = useDispatch();
	useEffect(
		() => {
			async function getAllProducts() {
				const { success, response } = await doFetchAllProducts();
				if (success) {
					if (response.message === 'Products found') {
						dispatch(setProducts(response.data.products));
					}
				}
			}

			getAllProducts();
		},
		[ dispatch ]
	);
};

export const useFetchAllTeams = () => {
	const dispatch = useDispatch();
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
};

export const useFetchAllUsers = (userType) => {
	const dispatch = useDispatch();
	useEffect(
		() => {
			async function getAllUsers() {
				const { success, response } = await doFetchAllUsers(userType);
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
};

export const useFetchAllIssues = () => {
	const dispatch = useDispatch();
	useEffect(
		() => {
			async function getAllIssues() {
				const { success, response } = await doFetchAllIssues();
				if (success) {
					if (response.message === 'Issues found') {
						dispatch(setIssues(response.data.issues));
					}
				}
			}

			getAllIssues();
		},
		[ dispatch ]
	);
};
