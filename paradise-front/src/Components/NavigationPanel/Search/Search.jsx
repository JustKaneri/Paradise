import React, { useState } from 'react';
import './search.css'
import { useNavigate } from 'react-router-dom';

const Search = () => {

    const router = useNavigate();

    const [searhValue,setSearhValue] = useState('');

    return (
        <div className='search'>
            <input 
                onChange={(event) => setSearhValue(event.target.value)}
                className='search-input' 
                type='text'></input>
            <button 
                onClick={()=>  router(`/video/searh/${searhValue}`,{ replace: true })}
                className='search-button'>    
            </button>
        </div>
    );
}

export default Search;
