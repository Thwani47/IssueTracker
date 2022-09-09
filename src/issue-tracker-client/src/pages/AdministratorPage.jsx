import React from 'react';
import { useSelector } from 'react-redux';
import FormModal from '../components/FormModal';
import IssueStatBar from '../components/IssueStatsBar';
import NewIssueForm from '../components/NewIssueForm';
import NewProductForm from '../components/NewProductForm';
import NewTeamForm from '../components/NewTeamForm';
import ProductsTable from '../components/ProductsTable';
import TeamsTable from '../components/TeamsTable';
import { useFetchAllIssues, useFetchAllProducts, useFetchAllTeams, useFetchAllUsers } from '../hooks';

export default function AdministratorPage() {
	const teams = useSelector((state) => state.teams.teams);
	const products = useSelector((state) => state.products.products);
	const issues = useSelector((state) => state.issues.issues);
	const user = useSelector((state) => state.auth.user);

	useFetchAllUsers(user.userType);
	useFetchAllTeams();
	useFetchAllProducts();
	useFetchAllIssues();

	return (
		<div className="flex flex-col">
			<div className="flex flex-row">
				<IssueStatBar issues={issues} />
			</div>
			<div className="flex-flex-row self-start mt-3">
				<label htmlFor="new-issue-modal" className="btn  modal-button btn-error btn-xs">
					New Issue
				</label>
				<FormModal
					id="new-issue-modal"
					form={<NewIssueForm modalId="new-issue-modal" />}
					title="Add new issue"
				/>
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
					<h1 className="text-xl text-accent font-bold self-start underline mt-3">Products</h1>
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
