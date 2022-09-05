import React, { useRef, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { doSignUp } from '../utils/api';

export default function Register() {
	const [ error, setError ] = useState(null);
	const firstNameRef = useRef();
	const lastNameRef = useRef();
	const usernameRef = useRef();
	const emailRef = useRef();
	const passwordRef = useRef();
	const confirmPasswordRef = useRef();
	const navigate = useNavigate();

	const handleSubmit = async (e) => {
		e.preventDefault();

		const firstName = firstNameRef.current.value;
		const lastName = lastNameRef.current.value;
		const username = usernameRef.current.value;
		const email = emailRef.current.value;
		const password = passwordRef.current.value;
		const confirmPassword = confirmPasswordRef.current.value;

		const data = {
			firstName,
			lastName,
			username,
			email,
			password,
			confirmPassword
		};

		const { success, response, err } = await doSignUp(data);

		if (success) {
			setError(null);
			if (response.message === 'User Added Successfully') {
				navigate('/login', { replace: true });
			}else{
                setError({message: 'Error registering user. Please try again'})
            }
		} else {
			setError({ message: err.title ? err.title : err.message });
		}
	};
	return (
		<div className="flex flex-col">
			<h2 className="text-3xl">Register</h2>
			<p className="text-s mt-2">Create account</p>

			<div className="form-control w-full max-w-xl self-center mt-5 p-4">
				{error === null ? null : <span className="text-red-700">{error.message}</span>}
				<form onSubmit={handleSubmit}>
					<label className="label">
						<span className="label-text">First Name</span>
					</label>
					<input
						type="text"
						placeholder="Enter your first name"
						className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
						autoComplete="on"
						ref={firstNameRef}
					/>
					<label className="label">
						<span className="label-text">Last Name</span>
					</label>
					<input
						type="text"
						placeholder="Enter your last name"
						className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
						autoComplete="on"
						ref={lastNameRef}
					/>

					<label className="label">
						<span className="label-text">Username</span>
					</label>
					<input
						type="text"
						placeholder="Enter your username"
						className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
						autoComplete="on"
						ref={usernameRef}
					/>

					<label className="label">
						<span className="label-text">Email Address</span>
					</label>
					<input
						type="email"
						placeholder="Enter your email address"
						className={`input input-bordered w-full max-w-s  ${error == null ? '' : 'input-error'}`}
						autoComplete="on"
						ref={emailRef}
					/>
					<label className="label">
						<span className="label-text">Password</span>
					</label>
					<input
						type="password"
						autoComplete="on"
						placeholder="Enter your password"
						className={`input input-bordered w-full max-w-xl ${error == null ? '' : 'input-error'}`}
						ref={passwordRef}
					/>
					<label className="label">
						<span className="label-text">Confirm Password</span>
					</label>
					<input
						type="password"
						autoComplete="on"
						placeholder="Enter your password"
						className={`input input-bordered w-full max-w-xl ${error == null ? '' : 'input-error'}`}
						ref={confirmPasswordRef}
					/>
					<div className="flex justify-between">
						<p className="text-s mt-1">
							<a href="/register" className="link text-info">
								Already registered? Sign in instead
							</a>
						</p>
					</div>

					<button type="submit" className="btn btn-accent rounded-full w-32 mt-4 self-center">
						Register
					</button>
				</form>
			</div>
		</div>
	);
}
