import { Box, Grid } from '@mui/material';
import React from 'react';
import Navbar from '../components/Navbar';
import Tile from '../components/Tile';

interface iMainPage {
	token ?: string;
}

const MainPage = (props: iMainPage) => {
	const {
		token,
	} = props;

	return (
		<React.Fragment>
			<Navbar 
				token={token}
			/>
			<Box sx={{ flexGrow: 1, width: '75%', mx: 'auto', mt: '100px' }}>
				<Grid container spacing={10} columnSpacing={{ xs: 1, sm: 2, md: 3 }}>
					<Grid item xs={12} sm={12} md={6}>
						<Tile text={'Add Picture'} linkTo={'/addPicture/' + token} />
					</Grid>
					<Grid item xs={12} sm={12} md={6}>
						<Tile text={'Gallery'} linkTo={'/gallery/' + token} />
					</Grid>
					<Grid item xs={12} sm={12} md={6}>
						<Tile text={'Profile'} linkTo={'/profile/' + token} />
					</Grid>
					<Grid item xs={12} sm={12} md={6}>
						<Tile text={'Logout'} linkTo={'/'} />
					</Grid>
				</Grid>
			</Box>
			<div style={{ margin: '100px' }} />
		</React.Fragment>
	);
};

export default MainPage;
