import React from 'react';
import { useSelector } from 'react-redux';
import ResetPasswordForm from '../components/ResetPasswordForm';
import { getRole } from '../utils/utils';

export default function ProfilePage() {
	const user = useSelector((state) => state.auth.user);
	return (
		<div>
			{user === null ? null : (
				<div className="flex flex-col mt-4">
					<div className="flex flex-row">
						<div className="flex flex-col">
							<p className="font-bold mr-2">First Name</p>
						</div>
						<div className="flex flex-col">
							<p>{user.firstName}</p>
						</div>
					</div>
					<div className="flex flex-row">
						<div className="flex flex-col">
							<p className="font-bold mr-2">Last Name</p>
						</div>
						<div className="flex flex-col">
							<p>{user.lastName}</p>
						</div>
					</div>
					<div className="flex flex-row">
						<div className="flex flex-col">
							<p className="font-bold mr-2">Username</p>
						</div>
						<div className="flex flex-col">
							<p className="font-bold text-accent">{user.username}</p>
						</div>
					</div>
					<div className="flex flex-row">
						<div className="flex flex-col">
							<p className="font-bold mr-2">Email Address</p>
						</div>
						<div className="flex flex-col">
							<p>{user.email}</p>
						</div>
					</div>
					<div className="flex flex-row">
						<div className="flex flex-col">
							<p className="font-bold mr-2">Role</p>
						</div>
						<div className="flex flex-col">
							<p className="text-red-400">{getRole(user.userType)}</p>
						</div>
					</div>
					<div className="border-2 rounded-lg border-red-500 shadow-lg w-96 mt-6 p-2">
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
								<span className="font-semibold ml-2 text-red-500">Reset Password</span>
							</div>

							<div className="flex flex-col">
								<ResetPasswordForm username={user.username}/>
							</div>
						</div>
					</div>
				</div>
			)}
		</div>
	);
}
