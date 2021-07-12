import React from 'react'

const GameCard = ({ item }) => {
    return (
        <div className="card">
            <div className="card-inner">
                <div className="card-front">
                    <img src={'http://cdn.nesicomdb.com/cartridges/' + item.image} alt="" />
                </div>
                <div className="card-back">
                    <ul>
                        <li>
                            <strong>{item.name}</strong>
                        </li>
                        <li>
                            <strong>{item.catalogEntry}</strong>
                        </li>
                        <li>
                            <strong>{item.developer}</strong>
                        </li>
                        <li>
                            <strong>{item.publisher}</strong>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    )
}

export default GameCard
