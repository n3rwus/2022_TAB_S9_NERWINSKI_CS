import CircularProgress from '@mui/material/CircularProgress';
import Box from '@mui/material/Box';

export default function Loader() {
  return (
    <Box sx={{ display: 'flex' }}>
      <CircularProgress  size={200} sx={{mt: '300px', mx: 'auto', color: '#1976d2'}}/>
    </Box>
  );
}