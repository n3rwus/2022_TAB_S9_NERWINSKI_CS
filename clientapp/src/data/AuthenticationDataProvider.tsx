import axios from 'axios';
export class AuthenticationDataProvider {

	public static signUp(email: string, password: string, firstName: string) {
		let data = 0;
		return axios.post(`http://localhost:4000/api/User/register`, {
			email: email,
			password: password,
			//firstName: firstName,
		}).then(res => {
			console.log(res);
			console.log(res.data);
			data = res.status;
			return data;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}

	public static signIn(email: string, password: string) {
		let data = '';
		return axios.post(`http://localhost:4000/api/User/login`, {
				email: email,
				password: password
			}, {
				headers: {
				'Accept' : 'application/json',
				'Content-Type': 'application/json',
				'Access-Control-Allow-Origin': '*',
			}
		}).then(res => {
			console.log(res.data);
			data = res.data.token;
			return data;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}

	public static sendConfirmationCode(email: string) {
		let data = 0;
		return axios.post(`http://localhost:5000/authorization/sendConfirmationCode`, {
			email: email,
		}).then(res => {
			console.log(res);
			console.log(res.data);
			data = res.status;
			return data;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}

	public static verifyAccount(email: string, confirmationCode: string) {
		let data = 0;
		return axios.post(`http://localhost:5000/authorization/confirmEmail`, {
			email: email,
			confirmationCode: confirmationCode,
		}).then(res => {
			console.log(res);
			console.log(res.data);
			data = res.status;
			return data;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}

	public static resetPassword(email: string) {
		let data = 0;
		return axios.post(`http://localhost:5000/authorization/resetPassword`, {
			email: email,
		}).then(res => {
			console.log(res);
			console.log(res.data);
			data = res.status;
			return data;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}

	public static getUserData(userToken: string) {
		let data = '';
		return axios.get(`http://localhost:5000/authorization/profile`, {
			headers: {
				'Authorization': 'Bearer ' + userToken,
			}
		}).then(res => {
			console.log(res.data);
			data = res.data.email;
			return data;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}
}