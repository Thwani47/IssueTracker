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

export const doLogin = async (data) => {
	return await axios
		.post(`${serverUrl}/api/auth/login`, data, {
			headers
		})
		.then((res) => {
			return { success: true, response: res.data };
		})
		.catch((err) => {
			return { success: false, err: err.response.data };
		});
};

export const doSignUp = async (data) => {
	return await axios
		.post(`${serverUrl}/api/auth/register`, data, {
			headers
		})
		.then((res) => {
			return { success: true, response: res.data };
		})
		.catch((err) => {
            console.log(err)
            return { success: false, err: err.response.data };
		});
};

export const doResetPassword = async (data) => {
	return await axios
		.post(`${serverUrl}/api/auth/reset-password`, data, {
			headers
		})
		.then((res) => {
			return { success: true, response: res.data };
		})
		.catch((err) => {
			return { success: false, err };
		});
};
