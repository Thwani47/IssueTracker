import config from './config';
import axios from 'axios';

const serverUrl = config.SERVER_URL;

const headers = {
	'Content-Type': 'application/json',
	'Access-Control-Allow-Origin': '*',
	Accept: 'application/json'
};

const getAuthHeaders = (token) => {
	return {
		...headers,
		Authorization: `Bearer ${token}`
	};
};

const doPostRequest = async (url, data) => {
	return await axios
		.post(`${serverUrl}/${url}`, data, { headers })
		.then((res) => {
			return { success: true, response: res.data };
		})
		.catch((err) => {
			return { success: false, err: err.response.data };
		});
};

const doGetRequest = async (url, reqHeaders) => {
	return await axios
		.get(`${serverUrl}/${url}`, {
			...reqHeaders
		})
		.then((res) => {
			return { success: true, response: res.data };
		})
		.catch((err) => {
			return { success: false, err };
		});
};

export const doLogin = async (data) => {
	return await doPostRequest('api/auth/login', data);
};

export const doSignUp = async (data) => {
	return await doPostRequest('api/auth/register', data);
};

export const doResetPassword = async (data) => {
	return await doPostRequest('api/auth/reset-password', data);
};

export const doGetUserDetails = async (userId, token) => {
	const reqHeaders = getAuthHeaders(token);
	return await doGetRequest(`api/users/data/userId/${userId}`, reqHeaders);
};

export const doFetchAllUsers = async (userType) => {
	return await doGetRequest(`api/users/all/${userType}`, headers);
};

export const doAddNewTeam = async (data) => {
	return await doPostRequest('api/team', data);
};

export const doFetchAllTeams = async () => {
	return await doGetRequest('api/team/all', headers);
};

export const doAddNewProduct = async (data) => {
	return await doPostRequest('api/products', data);
};

export const doFetchAllProducts = async () => {
	return await doGetRequest('api/products/all', headers);
};

export const doFetchAllIssues = async () => {
	return await doGetRequest('api/issues/all', headers);
};

export const doAddNewIssue = async (data) => {
	return await doPostRequest('api/issues', data);
};
