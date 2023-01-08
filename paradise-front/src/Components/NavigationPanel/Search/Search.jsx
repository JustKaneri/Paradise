import React, { useState } from 'react';
import './search.css'

const Search = () => {

    const [searhValue,setSearhValue] = useState('');

    return (
        <div className='search'>
            <input className='search-input' type='text'></input>
            <button className='search-button'></button>
        </div>
    );
}

export default Search;
