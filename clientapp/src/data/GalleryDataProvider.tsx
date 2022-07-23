import axios from 'axios';

axios.defaults.withCredentials = true;

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

export interface iSimplyFolder {
	id: string;
	folderName: string;
}

export interface iFolderData {
	folderName: string;
	parentFolderId: string;
	folders: iSimplyFolder[];
}

export class GalleryDataProvider {

	public static uploadImages(data: iUploadImages) {
	}

	public static getImages(data: User) {
	}

	public static addFolder(token: string, folder: string, parterId?: string) {
		let data = 0;
		return axios.post(`http://localhost:4000/api/folder/AddFolder`, {
			UserToken: token,
			FolderName: folder,
			ParentFolderId: parterId ?? null,
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

	public static getFolder(token: string, folderId: string ) {
		let data = 0;
		return axios.post(`http://localhost:4000/api/folder/GetFolder`, {
			UserToken: token,
			FolderId: folderId,
		}, {
			headers: {
				'Accept' : 'application/json',
				'Content-Type': 'application/json',
				'Access-Control-Allow-Origin': '*',
			}
		}).then(res => {
			console.log(res);
			console.log(res.data);
			const data = res.data;
			const folder: iFolderData = {
				folderName: data.folderName,
				parentFolderId: data.parentFolderId,
				folders: [],
			}
			data.inverseParentFolder.forEach((item: { folderName: any; id: any; }) => {
				const nestedFolder: iSimplyFolder = {
					folderName: item.folderName,
					id: item.id,
				}
				folder.folders.push(nestedFolder);
			});
			return folder;
		}).catch(er => {
			console.log(er);
			return data;
		});
	}

	public static getMainFolder(token: string ) {
		let status = 0;
		return axios.post(`http://localhost:4000/api/folder/GetMainFolder`, {
			UserToken: token,
		}, {
			headers: {
				'Accept' : 'application/json',
				'Content-Type': 'application/json',
				'Access-Control-Allow-Origin': '*',
			}
		}).then(res => {
			console.log(res);
			console.log(res.data);
			const data = res.data;
			const folders: iSimplyFolder[] = [];
			data.forEach((item: { folderName: any; id: any; }) => {
				const folder: iSimplyFolder = {
					folderName: item.folderName,
					id: item.id,
				}
				folders.push(folder);
			});
			return folders;
		}).catch(er => {
			console.log(er);
			return status;
		});
	}

	public static deleteFolder(token: string, folderId: string ) {
		let status = 0;
		return axios.post(`http://localhost:4000/api/folder/DeleteFolder`, {
			UserToken: token,
			FolderId: folderId,
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