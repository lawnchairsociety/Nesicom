import React from 'react';

const Search = () => {
    return (
        <section className="search">
            <form>
                <input
                    type="text"
                    className="form-control"
                    placeholder="Search"
                    autoFocus
                />
            </form>
        </section>
    );
};

export default Search;
