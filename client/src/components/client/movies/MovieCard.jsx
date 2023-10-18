import React from 'react'
import ViewDetails from './ViewDetails'

const MovieCard = ({movies}) => {
  return (
    <div className='flex flex-col space-y-5 md:space-x-5 md:space-y-0 md:flex-row'>
                {movies.map((movie, index) => (
                    <div key={index} className='card border p-3 flex flex-col'>
                        <img src={`./images/movies/${movie.imageUrls[0]}`} alt={`Movie ${index + 1}`} className='w-full h-auto md:w-64 md:h-80 object-cover' />
                        <h3 className='text-xl font-semibold mt-2'>{movie.title}</h3>
                        <p className='text-gray-500 text-m mt-1 mb-2'>
                            Genre: {movie.genre}
                        </p>
                        <ViewDetails movie={movie}/>
                    </div>
                ))}
            </div>
  )
}

export default MovieCard
