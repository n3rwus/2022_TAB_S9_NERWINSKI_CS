import { Box, Button, Grid, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react';
import Navbar from '../../components/Navbar';
import FolderCopyTwoToneIcon from '@mui/icons-material/FolderCopyTwoTone';
import MyTextField from '../../components/TextField';
import FolderItem from '../../components/FolderItem';
import SimplyImage from '../../components/SimplyImage';
import { GalleryDataProvider, iFolderData } from '../../data/GalleryDataProvider';

interface iFolder {
	folderId: string;
	parentFolderId: string;
}

const Folder = (props: iFolder) => {

	const [jwtToken, setJwtToken] = useState('');
	
	useEffect(() => {
		const token = localStorage.getItem('jwtToken');
		if (token) {
			getFolder(jwtToken, folderId);
			setJwtToken(localStorage.getItem('jwtToken') ?? '');
		}
	}, []);

	const [folder, setFolder] = React.useState<iFolderData>({
		folderName: 'Folder',
		parentFolderId: 'empty',
		folders: [],
	});
	const [newFolder, setNewFolder] = React.useState('');

	const [images, setImages] = React.useState(['Image1', 'Image2', 'Image3']);

	const {
		folderId,
		parentFolderId,
	} = props;

	const getFolder = (jwtToken: string, folderId: string) => {
		GalleryDataProvider.getFolder(jwtToken, folderId)
		.then((response) => {
			if (typeof response === typeof folder) {
				setFolder(response as iFolderData);
			}
		});
	}

	const onAddFolderClick = () => {
		return GalleryDataProvider.addFolder(jwtToken, newFolder, folderId)
		.then(status => {
			if (status === 200) {
				getFolder(jwtToken, folderId);
			}
			console.log(status);
		});
	}

	const onDeleteFolderClick = (jwtToken: string, id: string) => {
		return GalleryDataProvider.deleteFolder(jwtToken, id)
		.then(status => {
			if (status === 200) {
			}
		});
	}

	const renderFolders = folder.folders.map((nestedFolder) => (
		<Grid item xs={12} sm={6} md={4}>
			<FolderItem
				key={nestedFolder.id}
				name={nestedFolder.folderName}
				id={nestedFolder.id}
				parentFolderId={folder.parentFolderId}
				jwtToken={jwtToken}
				onDelete={onDeleteFolderClick}
			/>
		</Grid>
	));

	const renderImages = images.map((image , index) => (
		<Grid item xs={12} sm={6} md={4}>
			<SimplyImage
				key={index + 1}
				title={image}
				id={(index + 1)}
				folderId={folderId}
			/>
		</Grid>
	));

	return (
		<React.Fragment>
			<Navbar  />
			<Box sx={{ flexGrow: 1, width: '80%', mx: 'auto' }}>
				<Grid container spacing={8} columnSpacing={{ xs: 1, sm: 2, md: 3 }} alignItems='center' textAlign={'center'}>
					<Grid item xs={12}>
						<FolderCopyTwoToneIcon sx={{fontSize: '150px', color: '#1976d2', mt: '50px'}}/>
					</Grid>
					<Grid item xs={12}>
						<Typography component="h1" variant="h5" sx={{color: '#1976d2'}}>
							{folder.folderName}
						</Typography>
					</Grid>
					<Grid item xs={3}>
						<MyTextField
							id={'newFolder'} 
							label={'Add folder'} 
							fullwidth={true}
							value={newFolder}
							onChange={setNewFolder}
						/>
					</Grid>
					<Grid item xs={3}>
						<Button fullWidth onClick={onAddFolderClick} variant="contained" sx={{height: '56px', backgroundColor: '#00b4d8'}}>
							{'Add'}
						</Button>
					</Grid>
					<Grid item xs={3}>
						<Button fullWidth variant="contained" sx={{height: '56px', backgroundColor: '#0aa1dd'}}>
							{'Share'}
						</Button>
					</Grid>
					<Grid item xs={3}>
						<Button fullWidth variant="contained" sx={{height: '56px'}}>
							{'Raport'}
						</Button>
					</Grid>
					<Grid item xs={12}>
						<hr style={{ color: '#5cabe1' }} />
					</Grid>
					{renderFolders}
					{renderImages}
				</Grid>
			</Box>
			<div style={{ margin: '100px' }} />
		</React.Fragment>
	);
};

export default Folder;