import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';

import InputU  from  './components/Input';
import Account from './components/Account';
import InfoEvent from './components/InfoEvent';
import Registration from './components/Registration';
import ProfileUser from './components/ProfileUser';
import NewEnvent from './components/NewEvent';

export default class App extends Component {
  displayName = App.name

  render() {
    return (
        <Layout style={{ backgroundImage:"url(./Images/image.jpg)"}}>
            <Route exact path='/' component={Home} />
            <Route path='/account' component={Account} />
            <Route path='/infoevent/:ID' component={InfoEvent} />
            <Route path='/input' component={InputU} />
            <Route path='/registration' component={Registration} />
            <Route exact path='/profile' component={ProfileUser} />
            <Route path='/newEvent' component={NewEnvent} />
      </Layout>
    );
  }
}
