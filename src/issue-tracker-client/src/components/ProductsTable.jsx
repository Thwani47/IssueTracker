import React from 'react';

export default function ProductsTable({ products }) {
	return (
		<div className="overflow-x-auto overflow-y-auto w-full">
			<table className="table w-full">
				<thead>
					<tr>
						<th>Product Name</th>
						<th>Team</th>
						<th />
					</tr>
				</thead>
				<tbody>
					{products.map((product, index) => (
						<tr key={index}>
							<td>
								<div className="flex items-center space-x-3">
									<div>
										<div className="font-bold">{product.productName}</div>
									</div>
								</div>
							</td>
							<td>{product.teamName}</td>
							<th>
								<a href={`product/${product.productId}`} className="btn btn-ghost btn-xs">details</a>
							</th>
						</tr>
					))}
				</tbody>
			</table>
		</div>
	);
}
