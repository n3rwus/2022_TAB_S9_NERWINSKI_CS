import axios from 'axios';

axios.defaults.withCredentials = true;

export class ProfileDataProvider {

	public static addTag(token: string, tag: string ) {
		let data = 0;
		return axios.post(`http://localhost:4000/api/category/AddTag`, {
			UserToken: token,
			CategoryName: tag,
		}, {
			headers: {
				'Accept' : 'application/json',
				'Content-Type': 'application/json',
				'Access-Control-Allow-Origin': '*',
			}
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
}