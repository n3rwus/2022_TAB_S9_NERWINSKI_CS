import * as React from 'react';
import DeleteIcon from '@mui/icons-material/Delete';
import {  Grid, IconButton, Link, Typography } from '@mui/material';
import FolderCopyTwoToneIcon from '@mui/icons-material/FolderCopyTwoTone';

interface iFolderItem {
	name: string;
	id: string;
	token: string;
}

const FolderItem = (props: iFolderItem) => {
	const {
		name,
		id,
		token,
	} = props;

	return (
		<React.Fragment>
			<Grid container spacing={1} columnSpacing={{ xs: 1, sm: 2, md: 3 }} alignItems='center' textAlign={'center'}>
				<Grid item xs={12}>
					<Link href={'/gallery/folder/' + id + '/' + token} underline={'none'}>
						<FolderCopyTwoToneIcon sx={{fontSize: "120px", color: '#c8c6c6', ":hover":{color: 'inherit'}}} />
					</Link>
						<IconButton sx={{":hover": {color: '#ff5252'}}}>
							<DeleteIcon/>
						</IconButton>
				</Grid>
				<Grid item xs={12}>
					<Typography align='center' sx={{ fontSize: 20 }} noWrap>
						{name}
					</Typography>
				</Grid>
			</Grid>
		</React.Fragment>
	);
};

export default FolderItem;