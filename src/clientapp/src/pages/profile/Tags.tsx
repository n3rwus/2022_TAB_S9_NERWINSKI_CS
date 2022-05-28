import { Box, Button, Grid, Typography } from '@mui/material';
import React from 'react';
import Navbar from '../../components/Navbar';
import AccountCircleRoundedIcon from '@mui/icons-material/AccountCircleRounded';
import MyTextField from '../../components/TextField';

interface iTags {
	token ?: string;
}

const Tags = (props: iTags) => {
	const [tags, changeTags] = React.useState<string[]>([]);
	const [newTag, setNewTag] = React.useState('');

	const {
		token,
	} = props;

	return (
		<React.Fragment>
			<Navbar
				token={token}
			/>
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
							label={'Add Tag'} 
							fullwidth={true}
							value={newTag}
							onChange={setNewTag}
						/>
					</Grid>
					<Grid item xs={3}>
						<Button fullWidth variant="contained" sx={{height: '56px'}}>
							{'Add'}
						</Button>
					</Grid>
					<Grid item xs={12}>
						<hr style={{ color: '#5cabe1' }} />
					</Grid>
				</Grid>
			</Box>
		</React.Fragment>
	);
};

export default Tags;