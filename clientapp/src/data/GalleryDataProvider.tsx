import axios from 'axios';

interface User {
	token: string;
}

interface iUploadImages extends User {
	title: string;
	description: string;
	folder: string;
	tags: string[];
	date: Date;
	images: FileList;
}

export class GalleryDataProvider {

	public static uploadImages(data: iUploadImages) {
	}

	public static getImages(data: User) {
	}

	public static addFolder(token: string, folder: string ) {
		let data = 0;
		return axios.post(`http://localhost:4000/api/category/AddFolder`, {
			UserToken: token,
			FolderName: folder,
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

	public static getFolders(token: string, folder: string ) {
		let data = 0;
		return axios.post(`http://localhost:4000/api/category/AddFolder`, {
			UserToken: token,
			FolderName: folder,
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