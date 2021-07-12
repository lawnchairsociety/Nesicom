import React from 'react';
import CardGrid from '../cards/CardGrid';
import Sidebar from './Sidebar';

const Body = ({ isLoading, items, regions, stats }) => {
    return (
        <div className="bodyWrapper">
            <CardGrid isLoading={isLoading} items={items} />
            <Sidebar regions={regions} stats={stats} />
        </div>
    );
};

export default Body;
