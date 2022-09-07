import React, { useRef, useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { logout } from '../redux/slices/authSlice';
import { doResetPassword } from '../utils/api';

export default function ResetPasswordForm({ username }) {
	const [ error, setError ] = useState(null);
	const usernameRef = useRef();
	const passwordRef = useRef();
	const confirmPasswordRef = useRef();
	const dispatch = useDispatch();
	const navigate = useNavigate();

	const handleSubmit = async (e) => {
		e.preventDefault();

		const username = usernameRef.current.value;
		const password = passwordRef.current.value;
		const confirmPassword = confirmPasswordRef.current.value;

		const data = {
			username,
			password,
			confirmPassword
		};

		const { success, response, err } = await doResetPassword(data);

		if (success) {
			setError(null);
			if (response.message == 'Password reset successfully') {
				dispatch(logout());
				passwordRef.current.value = '';
				confirmPasswordRef.current.value = '';
				navigate('/login', { replace: true });
			} else {
				setError({ message: 'Error resetting user password. Pleae try again' });
			}
		} else {
			let message = err.response ? error.response.data.message : err.message;
			if (message === null) {
				message = err.message;
			}

			if (message == null) {
				message = err.title;
			}
			setError({ message });
		}
	};

	return (
		<div className="flex flex-col">
			<div className="form-control w-full max-w-xl self-center mt-1 p-4">
				{error === null ? null : <span className="text-red-700">{error.message ? error.message : ''}</span>}
				<form onSubmit={handleSubmit}>
					<label className="label">
						<span className="label-text ">Username</span>
					</label>
					<input
						type="text"
						disabled={username && username.length !== 0}
						value={username}
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
					<label className="label">
						<span className="label-text">Confirm Password</span>
					</label>
					<input
						type="password"
						autoComplete="on"
						placeholder="Confirm password"
						className={`input input-bordered w-full max-w-xl ${error == null ? '' : 'input-error'}`}
						ref={confirmPasswordRef}
					/>
					<button type="submit" className="btn btn-error rounded-full w-64 mt-4 self-center">
						Reset Password
					</button>
				</form>
			</div>
		</div>
	);
}
