import React from 'react';
import DeveloperAlphaGrid from './DeveloperAlphaGrid';
import PublisherAlphaGrid from './PublisherAlphaGrid';
import GameAlphaGrid from './GameAlphaGrid';
import ManufacturerAlphaGrid from './ManufacturerAlphaGrid';
import PcbAlphaGrid from './PcbAlphaGrid';

const SidebarBox = ({ content }) => {
    return (
        <div className="sidebarBox">
            <h1>Browse</h1>
            <h3>Games</h3>
            <GameAlphaGrid />
            <h3>Developers</h3>
            <DeveloperAlphaGrid />
            <h3>Publishers</h3>
            <PublisherAlphaGrid />
            <h3>Manufacturers</h3>
            <ManufacturerAlphaGrid />
            <h3>PCBs</h3>
            <PcbAlphaGrid />
        </div>
    );
};

export default SidebarBox;
