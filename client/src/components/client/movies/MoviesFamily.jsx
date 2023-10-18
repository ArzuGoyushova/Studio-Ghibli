import React from 'react';
import MovieCard from './MovieCard';

const MoviesFamily = ({ movies }) => {
    const familyMovies = movies.filter((m) => m.genre.includes("Family")).slice(0,4);
  
  return (
    <div className="mt-20">
       <h2 className='mb-5 rounded text-3xl md:text-4xl text-center md:text-start text-mainBlueColor'>
        Family Movies
      </h2>
      <MovieCard movies={familyMovies}/>
    </div>
  );
};

export default MoviesFamily;
