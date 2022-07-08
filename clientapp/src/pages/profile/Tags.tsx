import { Box, Button, Grid, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react';
import Navbar from '../../components/Navbar';
import AccountCircleRoundedIcon from '@mui/icons-material/AccountCircleRounded';
import MyTextField from '../../components/TextField';
import TagItem from '../../components/TagItem';
import { ProfileDataProvider } from '../../data/ProfileDataProvider';

const Tags = () => {
	const [jwtToken, setJwtToken] = useState('');
	const [tags, changeTags] = React.useState<string[]>(['Tag 1', 'Tag 2', 'Tag 3', 'Tag 4']);
	const [newTag, setNewTag] = React.useState('');
	
	
	useEffect(() => {
		setJwtToken(localStorage.getItem('jwtToken') ?? '');
	}, []);

	const onAddTagClick = () => {
		return ProfileDataProvider.addTag(jwtToken, newTag)
		.then(status => {
			console.log(status);
		});
	}

	const renderTags = tags.map(tag => (
		<TagItem name={tag}/>
	));

	return (
		<React.Fragment>
			<Navbar  />
			<Box sx={{ flexGrow: 1, width: '80%', mx: 'auto' }}>
				<Grid container spacing={8} columnSpacing={{ xs: 1, sm: 2, md: 3 }} alignItems='center' textAlign={'center'}>
					<Grid item xs={12}>
						<AccountCircleRoundedIcon sx={{fontSize: '150px', color: '#1976d2', mt: '50px'}}/>
					</Grid>
					<Grid item xs={12}>
						<Typography component="h1" variant="h5" sx={{color: '#1976d2'}}>
							{'User\'s tags'}
						</Typography>
					</Grid>
					<Grid item xs={9}>
						<MyTextField 
							id={'newTag'} 
							label={'Add tag'} 
							fullwidth={true}
							value={newTag}
							onChange={setNewTag}
						/>
					</Grid>
					<Grid item xs={3}>
						<Button fullWidth onClick={onAddTagClick} variant="contained" sx={{height: '56px'}}>
							{'Add'}
						</Button>
					</Grid>
					<Grid item xs={12}>
						<hr style={{ color: '#5cabe1' }} />
					</Grid>
					{renderTags}
				</Grid>
			</Box>
		</React.Fragment>
	);
};

export default Tags;