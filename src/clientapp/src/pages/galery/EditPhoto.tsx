import { Box, Button, Card, CardContent, CardHeader, CardMedia, Grid, Typography } from '@mui/material';
import React from 'react';
import Navbar from '../../components/Navbar';
import FolderCopyTwoToneIcon from '@mui/icons-material/FolderCopyTwoTone';
import MyTextField from '../../components/TextField';
import FolderItem from '../../components/FolderItem';
import SimplyImage from '../../components/SimplyImage';
import { NO_IMAGE } from '../../components/Utils';
import TagImage from '../../components/TagImage';
import SelectBasic from '../../components/SelectBasic';
import SelectTags from '../../components/SelectTags';
import BasicDatePicker from '../../components/DatePicker';

interface iEditPhoto {
	id: string;
	folderId: string;
}

const EditPhoto = (props: iEditPhoto) => {
	const [title, setTitle] = React.useState('');
	const [description, setDescription] = React.useState('');
	const [folder, setFolder] = React.useState('');
	const [tags, setTags] = React.useState<string[]>([]);
	const [date, setDate] = React.useState<Date | null>(null);


	return (
		<React.Fragment>
			<Navbar/>
			<Box sx={{ flexGrow: 1, width: '90%', mx: 'auto' }}>
				<Grid container spacing={8} columnSpacing={{ xs: 1, sm: 2, md: 3 }} alignItems='center' textAlign={'center'}>
					<Grid item xs={12}>
						<Card sx={{ maxWidth: '100%', mx: 'auto', mt: '50px' }}>
							<CardContent>
								<Grid container spacing={1} columnSpacing={{ xs: 1 }} alignItems='center' textAlign={'center'}>
									<Grid item xs={12} sm={6} md={6}>
										<MyTextField value={title} label={'Title'} onChange={setTitle} fullwidth/>
									</Grid>
									<Grid item xs={12} sm={6} md={6}>
										<SelectBasic
											folders={['Folder 1', 'Folder 2']}
											onFolderChange={setFolder}
										/>
									</Grid>
									<Grid item xs={12} sm={6} md={6}>
										<MyTextField 
											id={'description'} 
											label={'Description'} 
											fullwidth={true} 
											multiline={true} 
											maxRows={3}
											value={description}
											onChange={setDescription}
										/>
									</Grid>
									<Grid item xs={12} sm={6} md={6}>
										<SelectTags
											tags={['Tag 1', 'Tag 2', 'Tag 3']}
											onTagsChange={setTags}
										/>
									</Grid>
									<Grid item xs={12} sm={12} md={12} textAlign="center">
									<BasicDatePicker
											onDateChange={setDate}
										/>
									</Grid>
								</Grid>
							</CardContent>
						</Card>
					</Grid>
					<Grid item xs={12}>
						<Button fullWidth variant="contained" sx={{height: '56px', mb: '30px'}}>
							{'Save'}
						</Button>
					</Grid>
				</Grid>
			</Box>
		</React.Fragment>
	);
}

export default EditPhoto;