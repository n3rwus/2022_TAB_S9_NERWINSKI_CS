import { Box, Button, Grid, Typography } from '@mui/material';
import React from 'react';
import Navbar from '../../components/Navbar';
import FolderCopyTwoToneIcon from '@mui/icons-material/FolderCopyTwoTone';
import MyTextField from '../../components/TextField';
import FolderItem from '../../components/FolderItem';
import SimplyImage from '../../components/SimplyImage';

interface iFolder {
	token: string;
	parentId: string;
}

const Folder = (props: iFolder) => {
	const [folders, setFolders] = React.useState(['Folder 1', 'Folder 2', 'Folder 3']);
	const [newFolder, setNewFolder] = React.useState('');

	const [images, setImages] = React.useState(['Image1', 'Image2', 'Image3']);

	const {
		token,
		parentId,
	} = props;

	const renderFolders = folders.map((folder, index) => (
		<Grid item xs={12} sm={6} md={4}>
			<FolderItem 
				name={folder}
				id={(index + 1).toString()}
				token={token}
			/>
		</Grid>
	));

	const renderImages = images.map((image , index) => (
		<Grid item xs={12} sm={6} md={4}>
			<SimplyImage
				title={image}
				id={(index + 1)}
				folderId={parentId}
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
							{'Folder Name'}
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
						<Button fullWidth variant="contained" sx={{height: '56px', backgroundColor: '#00b4d8'}}>
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