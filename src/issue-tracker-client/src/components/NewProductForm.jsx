import React, { useRef, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setProducts } from '../redux/slices/productsSlice';
import { doAddNewProduct, doFetchAllProducts } from '../utils/api';

export default function NewProductForm({ modalId }) {
	const [ error, setError ] = useState(null);
	const productNameRef = useRef();
	const teamIdRef = useRef();
	const dispatch = useDispatch();
	const teams = useSelector((state) => state.teams.teams);

	const handleSubmit = async (e) => {
		e.preventDefault();

		const productName = productNameRef.current.value;
		const teamId = teamIdRef.current.value;

		const data = {
			productName,
			teamId
        };
        
		const { success, response, err } = await doAddNewProduct(data);

		if (success) {
			setError(null);
			if (response.message === 'Product Added Successfully') {
				productNameRef.current.value = '';
				const allProductsResponse = await doFetchAllProducts();

				if (allProductsResponse.success) {
					dispatch(setProducts(allProductsResponse.response.data.products));
					document.getElementById(modalId).checked = false;
				}
			}
		} else {
			setError({ message: err.title ? err.title : err.message });
		}
	};
	return (
		<div className="form-control w-full max-w-xl self-center mt-5 p-4">
			{error === null ? null : <span className="text-red-700">{error.message}</span>}
			<form onSubmit={handleSubmit}>
				<label className="label">
					<span className="label-text">Product Name</span>
				</label>
				<input
					type="text"
					placeholder="Enter product name"
					className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
					autoComplete="on"
					ref={productNameRef}
				/>
				<label className="label">
					<span className="label-text">Team</span>
				</label>
				<select className="select select-bordered flex" ref={teamIdRef}>
					{teams &&
						teams
							.map((team, index) => (
								<option
									key={index}
									value={team.teamId}
								>{`${team.teamName}`}</option>
							))}
				</select>

				<button type="submit" className="btn btn-info rounded-full w-32 mt-4 self-center">
					Submit
				</button>
			</form>
		</div>
	);
}
