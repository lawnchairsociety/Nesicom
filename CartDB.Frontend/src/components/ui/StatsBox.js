import React from 'react';

const StatsBox = ({ stats }) => {
    return (
        <div className="sidebarBox">
            <h1>Stats</h1>
            <strong>Cartridge Count: </strong>
            <span className="statData">{stats.cartridgeCount}</span>
            <br />
            <strong>Game Count: </strong>
            <span className="statData">{stats.gameCount}</span>
            <br />
            <strong>Developer Count: </strong>
            <span className="statData">{stats.developerCount}</span>
            <br />
            <strong>Publisher Count: </strong>
            <span className="statData">{stats.publisherCount}</span>
            <br />
            <strong>Manufacturer Count: </strong>
            <span className="statData">{stats.manufacturerCount}</span>
            <br />
            <strong>Region Count: </strong>
            <span className="statData">{stats.regionCount}</span>
            <br />
            <strong>Cartridge Chip Count: </strong>
            <span className="statData">{stats.cartridgeChipCount}</span>
        </div>
    );
};

export default StatsBox;
