import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import FormModal from '../components/FormModal';
import NewProductForm from '../components/NewProductForm';
import NewTeamForm from '../components/NewTeamForm';
import ProductsTable from '../components/ProductsTable';
import TeamsTable from '../components/TeamsTable';
import { setProducts } from '../redux/slices/productsSlice';
import { setTeams } from '../redux/slices/teamsSlice';
import { setUsers } from '../redux/slices/usersSlice';
import { doFetchAllProducts, doFetchAllTeams, doFetchAllUsers } from '../utils/api';

export default function AdministratorPage() {
	const teams = useSelector((state) => state.teams.teams);
	const products = useSelector((state) => state.products.products);
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

					<FormModal
						id="new-team-modal"
						form={<NewTeamForm modalId="new-team-modal" />}
						title="Create new team"
					/>
				</div>
				<div className="flex flex-col">
					<h1 className="text-xl">Products</h1>
					{products && products.length > 0 ? <ProductsTable products={products} /> : null}
					<label htmlFor="new-product-modal" className="btn modal-label btn-accent btn-xs mt-2 w-36">
						Add New Product
					</label>
					<FormModal
						id="new-product-modal"
						form={<NewProductForm modalId="new-product-modal" />}
						title="Create new product"
					/>
				</div>
			</div>
		</div>
	);
}
