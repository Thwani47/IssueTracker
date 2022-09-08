import React, { useRef, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setIssues } from '../redux/slices/issuesSlice';
import { doAddNewIssue, doFetchAllIssues } from '../utils/api';

export default function NewIssueForm({ modalId }) {
	const [ error, setError ] = useState(null);
	const issueTitleRef = useRef();
	const issueDescriptionRef = useRef();
	const productIdRef = useRef();
	const issuePriorityRef = useRef();
	const assignedToRef = useRef();
	const dispatch = useDispatch();
	const products = useSelector((state) => state.products.products);

	const handleSubmit = async (e) => {
		e.preventDefault();
		const issueTitle = issueTitleRef.current.value;
		const issueDescription = issueDescriptionRef.current.value;
		const productId = productIdRef.current.value;
		const issuePriority = parseInt(issuePriorityRef.current.value);

		const data = {
			issueTitle,
			issueDescription,
			productId,
			issuePriority
		};

		

		const { success, response, err } = await doAddNewIssue(data);

		if (success) {
			setError(null);
			if (response.message === 'Issue Added Successfully') {
				issueDescription.current.value = '';
				issueTitleRef.current.value = '';

				const allIssuesResponse = await doFetchAllIssues();

				if (allIssuesResponse.success) {
					dispatch(setIssues(allIssuesResponse.response.data.issues));
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
					<span className="label-text">Issue Title</span>
				</label>
				<input
					type="text"
					placeholder="Enter issue title"
					className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
					autoComplete="on"
					ref={issueTitleRef}
				/>
				<label className="label">
					<span className="label-text">Product</span>
				</label>
				<select className="select select-bordered flex" ref={productIdRef}>
					{products &&
						products.map((product, index) => (
							<option key={index} value={product.productId}>
								{product.productName}
							</option>
						))}
				</select>
				<label className="label">
					<span className="label-text">Description</span>
				</label>
				<textarea
					type="text"
					placeholder="Enter issue details"
					className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
					autoComplete="on"
					maxLength={400}
					wrap="hard"
					ref={issueDescriptionRef}
				/>

				<label className="label">
					<span className="label-text">Priority</span>
				</label>
				<select className="select select-bordered flex" ref={issuePriorityRef}>
					<option value={0}>Low</option>
					<option value={1}>Medium</option>
					<option value={2}>High</option>
				</select>

				<button type="submit" className="btn btn-info rounded-full w-32 mt-4 self-center">
					Submit
				</button>
			</form>
		</div>
	);
}
