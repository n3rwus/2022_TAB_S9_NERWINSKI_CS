import * as React from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import { AuthenticationDataProvider } from '../../data/AuthenticationDataProvider';

function Copyright(props: any) {
return (
	<Typography variant="body2" color="text.secondary" align="center" {...props}>
	{'Copyright © '}
	<Link color="inherit" href="https://mui.com/">
		{'Tab Project'}
	</Link>{' '}
	{new Date().getFullYear()}
	{'.'}
	</Typography>
);
}

const theme = createTheme();

interface iSignIn {
	status?: string;
}

const SignIn = (props: iSignIn) => {

	const {
		status,
	} = props;

	const [email, setEmail] = React.useState("");
	const [password, setPassword] = React.useState("");
	const [error, setError] = React.useState(false);

	const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
		event.preventDefault();
		return AuthenticationDataProvider.signIn(email, password)
		.then(token => {
			console.log(token);
			if (token) {
				window.location.replace("/mainPage/" + token);
			} else {
				setError(true);
			}
		});
	};

	return (
		<ThemeProvider theme={theme}>
		<Grid container component="main" sx={{ height: '100vh' }}>
			<CssBaseline />
			<Grid
			item
			xs={false}
			sm={4}
			md={7}
			sx={{
				backgroundImage: 'url(https://source.unsplash.com/random)',
				backgroundRepeat: 'no-repeat',
				backgroundColor: (t) =>
				t.palette.mode === 'light' ? t.palette.grey[50] : t.palette.grey[900],
				backgroundSize: 'cover',
				backgroundPosition: 'center',
			}}
			/>
			<Grid item xs={12} sm={8} md={5} component={Paper} elevation={6} square>
			<Box
				sx={{
				my: 8,
				mx: 4,
				display: 'flex',
				flexDirection: 'column',
				alignItems: 'center',
				}}
			>
				<Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
					<LockOutlinedIcon />
				</Avatar>
				<Typography component="h1" variant="h5">
					{'Sign in'}
				</Typography>
				<Box component="form" noValidate onSubmit={handleSubmit} sx={{ mt: 1 }}>
					<TextField
						margin="normal"
						required
						fullWidth
						id="email"
						label="Email Address"
						name="email"
						autoComplete="email"
						autoFocus
						onChange={event => setEmail(event.target.value)}
					/>
					<TextField
						margin="normal"
						required
						fullWidth
						name="password"
						label="Password"
						type="password"
						id="password"
						autoComplete="current-password"
						onChange={event => setPassword(event.target.value)}
					/>
					<Button
						type="submit"
						fullWidth
						variant="contained"
						sx={{ mt: 3, mb: 2 }}
					>
						{'Sign in'}
					</Button>
					<Grid container>
						<Grid item xs>
							<Link href="#" variant="body2">
								{'Forgot password?'}
							</Link>
						</Grid>
						<Grid item>
							<Link href="/signUp" variant="body2">
								{"Don't have an account? Sign Up"}
							</Link>
						</Grid>
					</Grid>
					{status === '200' &&
						<Typography component="h1" variant="h5" sx={{color: '#27db17', mt: '20px'}}>
							{'Account successfully created!'}
						</Typography>
					}
					{error &&
						<Typography component="h1" variant="h5" sx={{color: '#ff5252', mt: '20px'}}>
						{'Error occurs :('}
						<br/>
						{'Try again later.'}
						</Typography>
					}
					<Copyright sx={{ mt: 5 }} />
				</Box>
			</Box>
			</Grid>
		</Grid>
		</ThemeProvider>
	);
}

export default SignIn;