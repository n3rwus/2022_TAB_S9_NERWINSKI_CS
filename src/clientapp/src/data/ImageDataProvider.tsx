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

export class AuthenticationDataProvider {

	public static uploadImages(data: iUploadImages) {
	}

	public static getImages(data: User) {
	}
}