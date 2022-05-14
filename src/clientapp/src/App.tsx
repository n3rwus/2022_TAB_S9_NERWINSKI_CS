import React from 'react';
import { Redirect, Route, BrowserRouter as Router, Switch } from 'react-router-dom';
import './App.css';
import AddImage from './pages/AddImage';
import MainPage from './pages/MainPage';

function App() {
  return (
	<React.Fragment>
		<Router>
			<Switch>
				<Route exact path={'/'}>
					<Redirect to="/mainPage" />
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
