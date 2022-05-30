import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import AccountCircle from '@mui/icons-material/AccountCircle';
import MenuItem from '@mui/material/MenuItem';
import Menu from '@mui/material/Menu';
import { Link } from '@mui/material';

interface iNavbar {
	centerText?: string;
	token?: string;
}

export default function Navbar(props: iNavbar) {
	const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);

	const handleMenu = (event: React.MouseEvent<HTMLElement>) => {
		setAnchorEl(event.currentTarget);
	};

	const handleClose = () => {
		setAnchorEl(null);
	};

	const handleClick = (event: any) => {
		handleClose();
		event.preventDefault();
		const { myValue } = event.currentTarget.dataset;
		window.location.replace(myValue + (myValue !== '/' ? token : ""));
	};

	const { 
		centerText,
		token,
	} = props;

	return (
		<Box sx={{ flexGrow: 1 }}>
		<AppBar position="static" sx={{ backgroundColor: '#1976d2' }}>
			<Toolbar>
			<Link href={'/mainPage/' + token} underline={'none'}>
				<Typography variant="h6" component="div" sx={{ flexGrow: 1, color: '#FFF' }}>
				{'Picture Drive App'}
				</Typography>
			</Link>
			<Typography variant="h6" component="div" textAlign={'center'} sx={{ flexGrow: 1 }}>
				{centerText}
			</Typography>
			<div>
				<IconButton
					size="large"
					aria-label="account of current user"
					aria-controls="menu-appbar"
					aria-haspopup="true"
					onClick={handleMenu}
					sx={{
					color: '#FFF',
					}}
				>
					<AccountCircle />
				</IconButton>
				<Menu
					id="menu-appbar"
					anchorEl={anchorEl}
					anchorOrigin={{
					vertical: 'top',
					horizontal: 'right',
					}}
					keepMounted
					transformOrigin={{
					vertical: 'top',
					horizontal: 'right',
					}}
					open={Boolean(anchorEl)}
					onClose={handleClose}
				>
					<MenuItem 
						onClick={handleClick} 
						data-my-value={'/addPicture/'}
					>
						{'Add Picture'}
					</MenuItem>
					<MenuItem 
						onClick={handleClick} 
						data-my-value={'/profile/'}
					>
						{'Profile'}
					</MenuItem>
					<MenuItem 
						onClick={handleClick} 
						data-my-value={'/gallery/'}
					>
						{'Gallery'}
					</MenuItem>
					<MenuItem 
						onClick={handleClick} 
						data-my-value={'/'}
					>
						{'Logout'}
					</MenuItem>
				</Menu>
			</div>
			</Toolbar>
		</AppBar>
		</Box>
	);
}
