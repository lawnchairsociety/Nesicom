import React from 'react';

const RegionsBox = ({ regions }) => {
    return (
        <div className="regionsBox">
            <h1>Regions</h1>
            {regions.map((region) => (
                <a href="#">
                    <img
                        key={region.id}
                        src={'http://cdn.nesicomdb.com/regions/' + region.image}
                        alt={region.name}
                        title={region.name}
                    />
                </a>
            ))}
        </div>
    );
};

export default RegionsBox;
