import * as React from 'react';
import { Theme, useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import OutlinedInput from '@mui/material/OutlinedInput';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import Chip from '@mui/material/Chip';

interface iSelectTags {
	tags: string[];
	onTagsChange: React.Dispatch<React.SetStateAction<string[]>>;
}

const ITEM_HEIGHT = 48;
const ITEM_PADDING_TOP = 8;

const MenuProps = {
	PaperProps: {
		style: {
		maxHeight: ITEM_HEIGHT * 4.5 + ITEM_PADDING_TOP,
		width: 250,
		},
	},
};

function getStyles(tag: string, tagName: readonly string[], theme: Theme) {
	return {
		fontWeight: tagName.indexOf(tag) === -1 ? theme.typography.fontWeightRegular : theme.typography.fontWeightMedium,
	};
}

const SelectTags = (props: iSelectTags) => {
	const {
		tags,
		onTagsChange,
	} = props;

	const theme = useTheme();
	const [tagName, setPersonName] = React.useState<string[]>([]);
	const handleChange = (event: SelectChangeEvent<typeof tagName>) => {
		const {
		target: { value },
		} = event;
	
		setPersonName(typeof value === 'string' ? value.split(',') : value);
		onTagsChange(typeof value === 'string' ? value.split(',') : value);
		
	};

	return (
		<div>
		<Box sx={{ minWidth: 100 }}>
			<FormControl fullWidth>
			<InputLabel id="selectTags-label">{'Tags'}</InputLabel>
			<Select
				fullWidth
				labelId="selectTags-label"
				id="selectTags"
				multiple
				value={tagName}
				onChange={handleChange}
				input={<OutlinedInput id="selectTags" label="Tags" />}
				renderValue={selected => (
				<Box sx={{ display: 'flex', flexWrap: 'wrap', gap: 0.5 }}>
					{selected.map(value => (
					<Chip key={value} label={value} />
					))}
				</Box>
				)}
				MenuProps={MenuProps}
			>
				{tags.map(tag => (
				<MenuItem key={tag} value={tag} style={getStyles(tag, tagName, theme)}>
					{tag}
				</MenuItem>
				))}
			</Select>
			</FormControl>
		</Box>
		</div>
	);
};

export default SelectTags;
