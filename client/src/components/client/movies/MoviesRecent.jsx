import React from 'react';
import MovieCard from './MovieCard';

const MoviesRecent = ({ movies }) => {
    const recentMovies = movies.slice().reverse().slice(0, 4);

  return (
    <div>
      <h2 className='mb-5 rounded text-3xl md:text-4xl text-center md:text-start text-mainBlueColor'>
        Recently Added Movies
      </h2>
      <MovieCard movies={recentMovies}/>
    </div>
  );
};
export default MoviesRecent;
