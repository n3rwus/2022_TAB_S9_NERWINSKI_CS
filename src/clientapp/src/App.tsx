import React from 'react';
import { Redirect, Route, BrowserRouter as Router, Switch } from 'react-router-dom';
import './App.css';
import AddImage from './pages/AddImage';
import SingUp from './pages/loginSites/SingUp';
import SignIn from './pages/loginSites/SingIn';
import MainPage from './pages/MainPage';

function App() {
  return (
	<React.Fragment>
		<Router>
			<Switch>
				<Route exact path={'/'}>
					<Redirect to="/signIn" />
				</Route>
				<Route exact path={'/signIn'}>
					<SignIn />
				</Route>
				<Route exact path={'/signUp'}>
					<SingUp />
				</Route>
				<Route exact path={'/mainPage'}>
					<MainPage />
				</Route>
				<Route exact path={'/addPicture'}>
					<AddImage />
				</Route>
			</Switch>
		</Router>
	</React.Fragment>
	);
}

export default App;
