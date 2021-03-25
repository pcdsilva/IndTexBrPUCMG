import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Logon from './pages/Logon';
import Profile from './pages/Profile';
import Consultorias from './pages/Consultorias';
import GestaoIndustrial from './pages/GestaoIndustrial';
import NormasExternas from './pages/NormasExternas';
import NormasInternas from './pages/NormasInternas';
import Normas from './pages/Normas';

function Routes() {
    return (
      <BrowserRouter>
        <Switch>
            <Route path = "/"  exact component = {Logon} />
            <Route path = "/profile"  component = {Profile} />
            <Route path = "/normas"  component = {Normas} />
            <Route path = "/normasinternas"  component = {NormasInternas} />
            <Route path = "/normasexternas"  component = {NormasExternas} />
            <Route path = "/consultorias"  component = {Consultorias} />
            <Route path = "/gestaoindustrial"  component = {GestaoIndustrial} />
        </Switch>
      </BrowserRouter>
    );
  }
  
  export default Routes;