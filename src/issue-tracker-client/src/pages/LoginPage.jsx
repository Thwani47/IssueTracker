import React, { useRef, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useLocation, useNavigate } from 'react-router-dom';
import { login } from '../redux/slices/authSlice';
import { doLogin } from '../utils/api';

export default function LoginPage() {
	const [ error, setError ] = useState(null);
	const usernameRef = useRef();
	const passwordRef = useRef();
	const dispatch = useDispatch();
	const navigate = useNavigate();
	const location = useLocation();

	const handleSubmit = async (e) => {
		e.preventDefault();
		const username = usernameRef.current.value;
		const password = passwordRef.current.value;

		const data = {
			username,
			password
		};

		const { success, response, err } = await doLogin(data);

		if (success) {
			setError(null);
			if (response.message == 'Login Successful') {
				var userId = response.data.UserId;
				var token = response.data.token;
				dispatch(login(userId, token));
				const { from } = location.state || { from: { pathname: '/home' } };
				navigate(from.pathname, { replace: true });
			} else {
				setError({ message: 'Error logging user in. Pleae try again' });
			}
		} else {
			setError({ message: err.title ? err.title : err.message });
		}
	};
	return (
		<div className="flex flex-col">
			<h2 className="text-3xl">Login</h2>
			<p className="text-s mt-2">Please sign in into your account</p>

			<div className="form-control w-full max-w-xl self-center mt-5 p-4">
				{error === null ? null : <span className="text-red-700">{error.message}</span>}
				<form onSubmit={handleSubmit}>
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
						<span className="label-text">Password</span>
					</label>
					<input
						type="password"
						autoComplete="on"
						placeholder="Enter your password"
						className={`input input-bordered w-full max-w-xl ${error == null ? '' : 'input-error'}`}
						ref={passwordRef}
					/>
					<div className="flex justify-between">
						<p className="text-s mt-1">
							<a href="/reset-password" className="link link-hover">
								Forgot your password?
							</a>
						</p>
						<p className="text-s mt-1">
							<a href="/register" className="link link-accent">
								No account yet? Register
							</a>
						</p>
					</div>

					<button type="submit" className="btn btn-info rounded-full w-32 mt-4 self-center">
						Login
					</button>
				</form>
			</div>
		</div>
	);
}
