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
				<Route exact path={'/signIn/:status'} render={(props) => (
					<SignIn status={props.match.params.status}/>)}
				/>
				<Route exact path={'/signIn'}>
					<SignIn />
				</Route>
				<Route exact path={'/signUp'}>
					<SingUp />
				</Route>
				<Route exact path={'/mainPage/:token'} render={(props) => (
					<MainPage token={props.match.params.token}/>)}
				/>
				<Route exact path={'/mainPage'}>
					<MainPage />
				</Route>
				<Route exact path={'/addPicture/:token'} render={(props) => (
					<AddImage token={props.match.params.token}/>)}
				/>
				<Route exact path={'/addPicture'}>
					<AddImage />
				</Route>
			</Switch>
		</Router>
	</React.Fragment>
	);
}

export default App;
