import logo from './logo.svg';
import './App.css';
import store from './store';
import {Provider} from 'react-redux';
import Projects from './components/Projects';
import Clients from './components/Clients';
import Login from './components/Login';
import TimeSheets from "./components/TimeSheets"
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom";
import Layout from './components/Layout'
import TimeSheetDaily from './components/TimeSheetDaily'

function App() {
  return (
   
    <Provider store = {store}>

      <Router>
      <Layout>
        <div>
          <Switch>
          
            <Route exact path="/project">
              <Projects />
            </Route>
            <Route exact path="/clients">
            <Clients />
            </Route>
            <Route exact path="/timesheets">
              <TimeSheets />
            </Route>
            <Route exact path="/daily">
            <TimeSheetDaily/>
            </Route>
            
            <Route exact path="/">
              <Login />
            </Route>       
          </Switch>
        </div>
        </Layout>
    </Router>
  
    </Provider>
   
  );
}

export default App;
