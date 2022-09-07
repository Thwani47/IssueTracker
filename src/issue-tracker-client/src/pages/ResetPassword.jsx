import React from 'react';
import ResetPasswordForm from '../components/ResetPasswordForm';

export default function ResetPassword() {
	return (
		<div className="flex flex-col">
			<h2 className="text-3xl">Reset Password</h2>
			<p className="text-s mt-2">Reset your account password</p>
			<ResetPasswordForm />
		</div>
	);
}
