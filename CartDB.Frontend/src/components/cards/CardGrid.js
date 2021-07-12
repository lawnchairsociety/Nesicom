import React from 'react'
import GameCard from './GameCard';
import PcbCard from './PcbCard';
import Spinner from '../ui/Spinner';

const CardGrid = ({ items, isLoading }) => {
    return isLoading ? (
        <Spinner />
    ) : (
        <section className="cards">
            {items.map((item) => (
                <GameCard key={item.id} item={item} />
            ))}
        </section>
    );
}

export default CardGrid
