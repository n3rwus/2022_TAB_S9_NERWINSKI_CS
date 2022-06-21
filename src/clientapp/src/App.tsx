import React from 'react';
import { Redirect, Route, BrowserRouter as Router, Switch } from 'react-router-dom';
import './App.css';
import AddImage from './pages/AddImage';
import SignUp from './pages/loginSites/SignUp';
import SignIn from './pages/loginSites/SignIn';
import MainPage from './pages/MainPage';
import Profile from './pages/profile/Profile';
import Tags from './pages/profile/Tags';
import Privacy from './pages/profile/Privacy';
import Gallery from './pages/galery/Gallery';
import Folder from './pages/galery/Folder';
import Photo from './pages/galery/Photo';
import EditPhoto from './pages/galery/EditPhoto';

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
					<SignUp />
				</Route>
				<Route exact path={'/mainPage/:token'} render={(props) => (
					<MainPage token={props.match.params.token}/>)}
				/>
				<Route exact path={'/addPicture/:token'} render={(props) => (
					<AddImage token={props.match.params.token}/>)}
				/>
				<Route exact path={'/gallery/:token'} render={(props) => (
					<Gallery token={props.match.params.token}/>)}
				/>
				<Route exact path={'/profile/:token'} render={(props) => (
					<Profile token={props.match.params.token}/>)}
				/>
				<Route exact path={'/profile/tags/:token'} render={(props) => (
					<Tags token={props.match.params.token}/>)}
				/>
				<Route exact path={'/profile/privacy/:token'} render={(props) => (
					<Privacy token={props.match.params.token}/>)}
				/>
				<Route exact path={'/gallery/folder/:id/:token'} render={(props) => (
					<Folder
						token={props.match.params.token}
						parentId={props.match.params.id}
					/>)}
				/>
				<Route exact path={'/gallery/folder/:folderId/image/:id'} render={(props) => (
					<Photo
						id={props.match.params.id}
						folderId={props.match.params.folderId}
					/>)}
				/>
				<Route exact path={'/gallery/folder/:folderId/image/:id/edit'} render={(props) => (
					<EditPhoto
						id={props.match.params.id}
						folderId={props.match.params.folderId}
					/>)}
				/>
			</Switch>
		</Router>
	</React.Fragment>
	);
}
export default App;
