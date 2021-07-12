import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Header from './components/ui/Header';
import Body from './components/ui/Body';
import './App.css';
// Removable test data
import { isLoading, items, regions, stats } from './TestData.js';

function App() {
    return (
        <div className="container">
            <Header />
            <Body
                isLoading={isLoading}
                items={items}
                regions={regions}
                stats={stats}
            />
        </div>
    );
}

export default App;
