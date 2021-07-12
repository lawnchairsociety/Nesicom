import React from 'react';
import logo from '../../img/nesicom-logo.png';
import Search from './Search';

const Header = () => {
    return (
        <header>
            <a href="/"><img src={logo} alt="NesicomDB" title="NesicomDB" /></a>
            <Search />
        </header>
    );
};

export default Header;
