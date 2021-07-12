import React from 'react';
import StatsBox from './StatsBox';
import RegionsBox from './RegionsBox';
import SidebarBox from './SidebarBox';

const Sidebar = ({ regions, stats }) => {
    return (
        <div className="sidebar">
            <RegionsBox title="Regions" regions={regions} />
            <SidebarBox title="Browse" />
            <StatsBox title="Stats" stats={stats} />
        </div>
    );
};

export default Sidebar;
