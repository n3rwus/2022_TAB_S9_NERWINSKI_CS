import { Box, Grid } from '@mui/material';
import React from 'react';
import BasicDatePicker from '../components/DatePicker';
import Navbar from '../components/Navbar';
import SaveButton from '../components/SaveButton';
import SelectBasic from '../components/SelectBasic';
import SelectTags from '../components/SelectTags';
import MyTextField from '../components/TextField';
import UploadImageButton from '../components/UploadImageButton';
import UploadImageCard from '../components/UploadImageCard';

interface iAddImage {
	token ?: string;
}

const AddImage = (props: iAddImage) => {
	const [images, setImages] = React.useState<FileList>();
	const [title, setTitle] = React.useState('');
	const [description, setDescription] = React.useState('');
	const [folder, setFolder] = React.useState('');
	const [tags, setTags] = React.useState<string[]>([]);
	const [date, setDate] = React.useState<Date | null>(null);

	const {
		token,
	} = props;

	return (
		<React.Fragment>
			<Navbar 
				centerText={'Upload images'}
				token={token}
			 />
			<Box sx={{ flexGrow: 1, width: '90%', mx: 'auto', mt: '100px' }}>
				<Grid container spacing={3} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
				<Grid item xs={12} sm={6} md={6}>
					<MyTextField 
						id={'title'} 
						label={'Title'} 
						fullwidth={true}
						value={title}
						onChange={setTitle}
					/>
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
				<Grid item xs={12} sm={12} md={4} textAlign="center">
					<BasicDatePicker
						onDateChange={setDate}
					/>
				</Grid>
				<Grid item xs={12} sm={12} md={4} textAlign="center">
					<UploadImageButton multiple={true} handleImages={setImages} />
				</Grid>
				<Grid item xs={12} sm={12} md={4} textAlign="center">
					<SaveButton disabled={images === undefined || title === '' || folder === ''} />
				</Grid>
				</Grid>
			</Box>
			<hr style={{ margin: '30px' }} />
			<Box sx={{ flexGrow: 1, width: '90%', mx: 'auto', mt: '100px' }}>
				<Grid container spacing={3} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
					{images && Array.from(images).map((image, index) => <UploadImageCard key={index} image={image} index={index} />)}
				</Grid>
			</Box>
		</React.Fragment>
	);
};

export default AddImage;
