import { Box, Button, Grid, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react';
import Navbar from '../../components/Navbar';
import PhotoLibraryRoundedIcon from '@mui/icons-material/PhotoLibraryRounded';
import MyTextField from '../../components/TextField';
import FolderItem from '../../components/FolderItem';
import { GalleryDataProvider, iFolder } from '../../data/GalleryDataProvider';

const Gallery = () => {
	const [jwtToken, setJwtToken] = useState('');
	
	useEffect(() => {
		const token = localStorage.getItem('jwtToken');
		if (token) {
			getFolders(token);
			setJwtToken(localStorage.getItem('jwtToken') ?? '');
		}
	}, []);

	const [folders, setFolders] = React.useState<iFolder[]>([]);
	const [newFolder, setNewFolder] = React.useState('');

	const getFolders = (jwtToken: string) => {
		GalleryDataProvider.getMainFolder(jwtToken)
		.then((response) => {
			if (typeof response === typeof folders) {
				setFolders(response as iFolder[]);
			}
		});
	}

	const onAddFolderClick = () => {
		return GalleryDataProvider.addFolder(jwtToken, newFolder, undefined)
		.then(status => {
			if (status === 200) {
				getFolders(jwtToken);
			}
			console.log(status);
		});
	}

	const onDeleteFolderClick = (jwtToken: string, id: string) => {
		return GalleryDataProvider.deleteFolder(jwtToken, id)
		.then(status => {
			if (status === 200) {
				getFolders(jwtToken);
			}
		});
	}

	const renderFolders = folders.map((folder, index) => (
		<Grid item xs={12} sm={6} md={4}>
			<FolderItem
				key={folder.id}
				name={folder.folderName}
				id={folder.id}
				jwtToken={jwtToken}
				onDelete={onDeleteFolderClick}
			/>
		</Grid>
	));

	return (
		<React.Fragment>
			<Navbar />
			<Box sx={{ flexGrow: 1, width: '80%', mx: 'auto' }}>
				<Grid container spacing={8} columnSpacing={{ xs: 1, sm: 2, md: 3 }} alignItems='center' textAlign={'center'}>
					<Grid item xs={12}>
						<PhotoLibraryRoundedIcon sx={{fontSize: '150px', color: '#1976d2', mt: '50px'}}/>
					</Grid>
					<Grid item xs={12}>
						<Typography component="h1" variant="h5" sx={{color: '#1976d2'}}>
							{'User\'s gallery'}
						</Typography>
					</Grid>
					<Grid item xs={9}>
						<MyTextField 
							id={'newFolder'} 
							label={'Add folder'} 
							fullwidth={true}
							value={newFolder}
							onChange={setNewFolder}
						/>
					</Grid>
					<Grid item xs={3}>
						<Button fullWidth onClick={onAddFolderClick} variant="contained" sx={{height: '56px'}}>
							{'Add'}
						</Button>
					</Grid>
					<Grid item xs={12}>
						<hr style={{ color: '#5cabe1' }} />
					</Grid>
					{renderFolders}
				</Grid>
			</Box>
			<div style={{ margin: '100px' }} />
		</React.Fragment>
	);
};

export default Gallery;