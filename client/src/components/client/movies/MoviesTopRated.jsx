import React from 'react';
import MovieCard from './MovieCard';

const MoviesTopRated = ({ movies }) => {
    const topRatedMovies = movies
  .filter((m) => m.imdbRating)
  .sort((a, b) => b.imdbRating - a.imdbRating) 
  .slice(0, 4); 


  return (
    <div className="mt-20">
       <h2 className='mb-5 rounded text-3xl md:text-4xl text-center md:text-start text-mainBlueColor'>
        Top Rated Movies
      </h2>
     <MovieCard movies={topRatedMovies}/>
    </div>
  );
};

export default MoviesTopRated;
