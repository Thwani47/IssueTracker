import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { Navigate, Route, Routes } from 'react-router-dom';
import './App.css';
import NavBar from './components/NavBar';
import PrivateRoute from './components/PrivateRoute';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import Register from './pages/Register';
import ResetPassword from './pages/ResetPassword';
import ProfilePage from './pages/ProfilePage';
import TeamPage from './pages/TeamPage';
import { setUserData } from './redux/slices/authSlice';
import { doGetUserDetails } from './utils/api';

function App() {
	const auth = useSelector((state) => state.auth);
	const dispatch = useDispatch();

	useEffect(
		() => {
			async function getUserDetails() {
				const { success, response } = await doGetUserDetails(auth.userId, auth.token);

				if (success) {
					if (response.message == 'User found') {
						dispatch(setUserData(response.data.user));
					}
				}
			}

			if (auth.isAuthenticated) {
				getUserDetails();
			}
		},
		[ auth.isAuthenticated, auth.token, dispatch ]
	);
	return (
		<div className="App">
			<NavBar />
			<Routes>
				<Route
					path="/"
					element={
						<PrivateRoute>
							<HomePage />
						</PrivateRoute>
					}
				/>
				<Route
					path="/team/:teamId"
					element={
						<PrivateRoute>
							<TeamPage />
						</PrivateRoute>
					}
				/>
				<Route
					path="/profile"
					element={
						<PrivateRoute>
							<ProfilePage />
						</PrivateRoute>
					}
				/>
				<Route path="/login" element={<LoginPage />} />
				<Route path="/register" element={<Register />} />
				<Route path="/reset-password" element={<ResetPassword />} />
				<Route path="*" element={<Navigate to="/" />} />
			</Routes>
		</div>
	);
}

export default App;
