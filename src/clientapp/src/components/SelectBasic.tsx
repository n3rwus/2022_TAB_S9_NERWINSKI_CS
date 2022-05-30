import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';

interface iSelectBasic {
	folders: string[];
	onFolderChange: React.Dispatch<React.SetStateAction<string>>;
}

const SelectBasic = (props: iSelectBasic) => {
	
	const {
		folders,
		onFolderChange,
	} = props;

	const [folder, setFolder] = React.useState('');

	const handleChange = (event: SelectChangeEvent) => {
		setFolder(event.target.value);
		onFolderChange(event.target.value);
	};

	const menuItems = folders.map(folder => (
		<MenuItem value={folder}>{folder}</MenuItem>
	));

	return (
		<Box sx={{ minWidth: 100 }}>
		<FormControl fullWidth>
			<InputLabel id="select-basic-label">{'Folder'}</InputLabel>
			<Select labelId="select-basic-label" id="select-basic" value={folder} label="Folder" onChange={handleChange}>
				{menuItems}
			</Select>
		</FormControl>
		</Box>
	);
};

export default SelectBasic;
