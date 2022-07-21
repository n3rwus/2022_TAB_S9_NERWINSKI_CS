import { Box, Button, Grid, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react';
import Navbar from '../../components/Navbar';
import AccountCircleRoundedIcon from '@mui/icons-material/AccountCircleRounded';
import MyTextField from '../../components/TextField';
import TagItem from '../../components/TagItem';
import { iTags, ProfileDataProvider } from '../../data/ProfileDataProvider';
import { regexEmpty } from '../../components/Utils';

const Tags = () => {
	const [jwtToken, setJwtToken] = useState('');

	const [tags, changeTags] = React.useState<iTags[]>([]);
	const [newTag, setNewTag] = React.useState('');
	
	const [emptyNewTag, seEmptyNewTag] = React.useState(true);

	// ComponentDidMount

	useEffect(() => {
		const token = localStorage.getItem('jwtToken');
		if (token) {
			getTags(token);
			setJwtToken(localStorage.getItem('jwtToken') ?? '');
		}
		// eslint-disable-next-line react-hooks/exhaustive-deps
	}, []);

	// validation
	useEffect(() => {
		seEmptyNewTag(!regexEmpty.test(newTag));
	}, [newTag]);


	// Methods
	const getTags = (jwtToken: string) => {
		ProfileDataProvider.getTag(jwtToken)
		.then((response) => {
			if (typeof response === typeof tags) {
				changeTags(response as iTags[]);
			}
		});
	}

	const onAddTagClick = () => {
		return ProfileDataProvider.addTag(jwtToken, newTag)
		.then(status => {
			if (status === 200) {
				getTags(jwtToken);
			}
			console.log(status);
		});
	}

	const onDeleteTagClick = (jwtToken: string, id: string) => {
		return ProfileDataProvider.deleteTag(jwtToken, id)
		.then(status => {
			if (status === 200) {
				getTags(jwtToken);
			}
		});
	}

	// Prerender
	const renderTags = tags.map(tag => (
		<TagItem
			jwtToken={jwtToken}
			name={tag.name}
			id={tag.id}
			onDelete={onDeleteTagClick}
		/>
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
						<Button fullWidth disabled={emptyNewTag} onClick={onAddTagClick} variant="contained" sx={{height: '56px'}}>
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