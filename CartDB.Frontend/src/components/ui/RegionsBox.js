import React from 'react';

const RegionsBox = ({ regions }) => {
    return (
        <div className="regionsBox">
            <h1>Regions</h1>
            {regions.map((region, index) => (
                <a href="#">
                    <img
                        key={region.id}
                        src={'http://cdn.nesicomdb.com/regions/' + region.image}
                        alt={region.name}
                        title={region.name}
                    />
                    {index === regions.length / 2 - 1 ? <br /> : ''}
                </a>
            ))}
        </div>
    );
};

export default RegionsBox;
