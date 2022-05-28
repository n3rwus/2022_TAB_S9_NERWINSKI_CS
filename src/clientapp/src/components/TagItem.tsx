import * as React from 'react';
import DeleteIcon from '@mui/icons-material/Delete';
import { Button, Card, CardContent, Typography } from '@mui/material';

interface iTagItem {
	name: string;
}

const TagItem = (props: iTagItem) => {
	const [color, setColor] = React.useState("#000");

    const generateColor = () => '#' + 
	[Math.floor(Math.random() * 256), Math.floor(Math.random() * 256), Math.floor(Math.random() * 256)].map(x => {
		if (x.toString(16).length === 1) 
		return '0' + x.toString(16);
		return x.toString(16);
	 }).join('');

	React.useEffect(() => {
		setColor(generateColor);
	 }, []);

	const {
		name,
	} = props;

	return (
		<React.Fragment>
			<Card elevation={2} sx={{m: '30px'}}>
				<CardContent >
					<Typography align='center' sx={{ fontSize: 20, color: color }} style={{wordWrap: 'break-word'}}>
						{name}
					</Typography>
					<Button variant="contained" fullWidth startIcon={<DeleteIcon />} sx={{ mt: '20px', ':hover': {backgroundColor: '#ff5252'} }}>
						{'Delete'}
					</Button>
				</CardContent>
			</Card>
		</React.Fragment>
	);
};

export default TagItem;