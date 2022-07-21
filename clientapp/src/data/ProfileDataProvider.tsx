import axios from 'axios';

axios.defaults.withCredentials = true;

export interface iTags {
	name: string;
	id: string;
}

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

	public static getTag(token: string ) {
		let status = 0;
		return axios.post(`http://localhost:4000/api/category/GetTags`, {
			UserToken: token,
		}, {
			headers: {
				'Accept' : 'application/json',
				'Content-Type': 'application/json',
				'Access-Control-Allow-Origin': '*',
			}
		}).then(res => {
			console.log(res);
			const data = res.data;
			const tags: iTags[] = [];
			data.forEach((item: { categoryName: any; id: any; }) => {
				const tag: iTags = {
					name: item.categoryName,
					id: item.id
				}
				tags.push(tag);
			});
			return tags;
		}).catch(er => {
			console.log(er);
			return status;
		});
	}

	public static deleteTag(token: string, id: string ) {
		let status = 0;
		return axios.post(`http://localhost:4000/api/category/DeleteTag`, {
			Id: id,
			UserToken: token,
		}, {
			headers: {
				'Accept' : 'application/json',
				'Content-Type': 'application/json',
				'Access-Control-Allow-Origin': '*',
			}
		}).then(res => {
			console.log(res);
			status = res.status;
			return status;
		}).catch(error => {
			console.log(error);
			status = error.status;
			return status;
		});
	}
}