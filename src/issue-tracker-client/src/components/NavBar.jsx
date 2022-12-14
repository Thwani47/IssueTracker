import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { logout } from '../redux/slices/authSlice';
import { clearProducts } from '../redux/slices/productsSlice';
import { clearTeams } from '../redux/slices/teamsSlice';
import { clearUsers } from '../redux/slices/usersSlice';

export default function NavBar() {
	const auth = useSelector((state) => state.auth);
	const dispatch = useDispatch();
	const navigate = useNavigate();

	const doLogout = () => {
		dispatch(logout());
		dispatch(clearProducts())
		dispatch(clearUsers())
		dispatch(clearTeams())
		navigate('/', { replace: true });
	};
	return (
		<div className="navbar bg-base-100">
			<div className="flex-1">
				<a className="btn btn-gost normal-case text-xl" href="/">
					Issue Tracker
				</a>
			</div>

			{auth.isAuthenticated ? (
				<div className="flex-none">
					<div className="dropdown dropdown-end mr-2">
						<button className="btn btn-ghost btn-circle">
							<div className="indicator">
								<svg
									xmlns="http://www.w3.org/2000/svg"
									className="h-5 w-5"
									fill="none"
									viewBox="0 0 24 24"
									stroke="currentColor"
								>
									<path
										strokeLinecap="round"
										strokeLinejoin="round"
										strokeWidth="2"
										d="M15 17h5l-1.405-1.405A2.032 2.032 0 0118 14.158V11a6.002 6.002 0 00-4-5.659V5a2 2 0 10-4 0v.341C7.67 6.165 6 8.388 6 11v3.159c0 .538-.214 1.055-.595 1.436L4 17h5m6 0v1a3 3 0 11-6 0v-1m6 0H9"
									/>
								</svg>
								<span className="badge badge-xs badge-primary indicator-item" />
							</div>
						</button>
					</div>
					<div className="dropdown dropdown-end">
						<div tabIndex="0" className="avatar placeholder">
							<div className="btn bg-neutral-focus text-neutral-content rounded-full w-36">
								<span className="text-s">{auth.user ? auth.user.firstName : ''}</span>
							</div>
						</div>

						<ul
							tabIndex="0"
							className="menu menu-compact dropdown-content mt-3 p-2 shadow bg-base-100 rounded-box w-52"
						>
							<li>
								<a href="/profile" className="justify-between">
									Profile
								</a>
							</li>
							<li>
								<a onClick={() => doLogout()}>Logout</a>
							</li>
						</ul>
					</div>
				</div>
			) : (
				<div className="flex float-right">
					<a className="btn btn-info normal-case text-lg" href="/login">
						Login
					</a>
					<a className="btn btn-accent normal-case text-lg ml-2" href="/register">
						Sign Up
					</a>
				</div>
			)}
		</div>
	);
}
