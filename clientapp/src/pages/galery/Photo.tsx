import { Box, Button, Card, CardContent, CardHeader, CardMedia, Grid, Typography } from '@mui/material';
import React from 'react';
import Navbar from '../../components/Navbar';
import FolderCopyTwoToneIcon from '@mui/icons-material/FolderCopyTwoTone';
import MyTextField from '../../components/TextField';
import FolderItem from '../../components/FolderItem';
import SimplyImage from '../../components/SimplyImage';
import { NO_IMAGE } from '../../components/Utils';
import TagImage from '../../components/TagImage';

interface iPhoto {
	id: string;
	folderId: string;
}

const onSaveClick = () => {
	var a = document.createElement('a');
	a.href = NO_IMAGE;
	a.download = "output.png";
	document.body.appendChild(a);
	a.click();
	document.body.removeChild(a);
}

const Photo = (props: iPhoto) => {

	const {
		id,
		folderId,
	} = props;

	return (
		<React.Fragment>
			<Navbar/>
			<Box sx={{ flexGrow: 1, width: '90%', mx: 'auto' }}>
				<Grid container spacing={8} columnSpacing={{ xs: 1, sm: 2, md: 3 }} alignItems='center' textAlign={'center'}>
					<Grid item xs={10}>
						<Card sx={{ maxWidth: '100%', mx: 'auto', mt: '50px' }}>
							<CardHeader
								title={'Tytuł zdjęcia'}
								subheader={'Data'}
							/>
							<CardMedia
								component="img"
								height="400"
								image={NO_IMAGE}
								alt="Paella dish"	
							/>
							<CardContent>
								<Typography sx={{mb: '30px'}}>
									{'Description'}
								</Typography>
								<Grid container spacing={1} columnSpacing={{ xs: 1 }} alignItems='center' textAlign={'center'}>
									<Grid item xs={6} sm={4} md={3}>
										<TagImage name='tag1' isEdit={false}/>
									</Grid>
									<Grid item xs={6} sm={4} md={3}>
										<TagImage name='tag2'  isEdit={false}/>
									</Grid>
									<Grid item xs={6} sm={4} md={3}>
										<TagImage name='tag3'  isEdit={false}/>
									</Grid>
									<Grid item xs={6} sm={4} md={3}>
										<TagImage name='tag4'   isEdit={false}/>
									</Grid>
								</Grid>
							</CardContent>
						</Card>
					</Grid>
					<Grid item xs={2}>
						<Button fullWidth onClick={onSaveClick} variant="contained" sx={{height: '56px', mb: '30px'}}>
							{'Save'}
						</Button>
						<Button fullWidth href={'/gallery/folder/' + folderId + '/image/' + id + '/edit'} variant="contained" sx={{height: '56px', mb: '30px'}}>
							{'Edit'}
						</Button>
						<Button fullWidth variant="contained" sx={{height: '56px'}}>
							{'Delete'}
						</Button>
					</Grid>
					<Grid item xs={4}>
						
					</Grid>
					<Grid item xs={4}>

					</Grid>
				</Grid>
			</Box>
		</React.Fragment>
	);
}

export default Photo;