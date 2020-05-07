import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { PreferredCoin } from './components/PreferredCoin'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={PreferredCoin} />
        <Route path='/preferred-coin' component={PreferredCoin} />
      </Layout>
    );
  }
}
