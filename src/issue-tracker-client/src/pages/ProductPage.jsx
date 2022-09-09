import React from 'react';
import { useSelector } from 'react-redux';
import { useParams } from 'react-router-dom';
import { useFetchAllProducts, useFetchAllTeams } from '../hooks';

export default function ProductPage() {
	const params = useParams();
	const products = useSelector((state) => state.products.products);
	const teams = useSelector((state) => state.teams.teams);

	useFetchAllProducts();
	useFetchAllTeams();

	return (
		<div className="flex flex-col">
			{products === null ? null : (
				products.filter((product) => product.productId === params.productId).map((product, index) => (
					<div key={index} className="flex flex-col mt-4">
						<div className="flex flex-row">
							<div className="flex flex-col">
								<p className="font-bold mr-2">Product Name</p>
							</div>
							<div className="flex flex-col">
								<p>{product.productName}</p>
							</div>
						</div>
						<div className="flex flex-row">
							<div className="flex flex-col">
								<p className="font-bold mr-2">Team Name</p>
							</div>
							<div className="flex flex-col">
								{teams && teams.length > 0 ? (
									teams
										.filter((team) => team.teamId === product.teamId)
										.map((filteredTeam, index) => (
											<div key={index} className="flex flex-col">
												<a href={`/team/${filteredTeam.teamName}`} className="link link-hover">
													{filteredTeam.teamName}
												</a>
											</div>
										))
								) : null}
							</div>
						</div>
						<div className="border-1 rounded-lg border-red-500 shadow-lg w-80 mt-6 p-2">
							<div className="flex flex-col">
								<div className="flex flex-row">
									<svg
										xmlns="http://www.w3.org/2000/svg"
										className="stroke-red-500 flex-shrink-0 h-6 w-6"
										fill="none"
										viewBox="0 0 24 24"
									>
										<path
											strokeLinecap="round"
											strokeLinejoin="round"
											strokeWidth="2"
											d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"
										/>
									</svg>
									<span className="font-semibold ml-2 text-red-500">Delete Team</span>
								</div>
								<span className="text-error">
									This is a destructive action and will delete all products and issues under this
									team!
								</span>

								<div className="flex flex-col">
									<button className="btn btn-error rounded-full w-24 mt-4 self-center">Delete</button>
								</div>
							</div>
						</div>
					</div>
				))
			)}
		</div>
	);
}
