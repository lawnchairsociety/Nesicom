import React from 'react';

const PcbCard = ({ item }) => {
    return (
        <div className="card">
            <div className="card-inner">
                <div className="card-front">
                    <img
                        src={'http://cdn.nesicomdb.com/pcb/' + item.image}
                        alt=""
                    />
                </div>
                <div className="card-back">
                    <ul>
                        <li>
                            <strong>{item.name}</strong>
                        </li>
                        <li>
                            <strong>{item.class}</strong>
                        </li>
                        <li>
                            <strong>{item.manufacturer}</strong>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    );
};

export default PcbCard;
