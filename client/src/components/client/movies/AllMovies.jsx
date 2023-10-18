import React from 'react'
import ViewDetails from './ViewDetails'

const AllMovies = ({movies}) => {
  return (
    <div className="mt-20">
       <h2 className='mb-5 rounded text-3xl md:text-4xl text-center md:text-start text-mainBlueColor'>
        All Ghibli Movies
      </h2>
      <div className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-5'>
                {movies.map((movie, index) => (
                    <div key={index} className='card border p-3 flex flex-col'>
                        <img src={`./images/movies/${movie.imageUrls[0]}`} alt={`Movie ${index + 1}`} className='w-full h-auto md:w-56 md:h-80 object-cover' />
                        <h3 className='text-xl font-semibold mt-2'>{movie.title}</h3>
                        <p className='text-gray-500 text-m mt-1 mb-2'>
                            Genre: {movie.genre}
                        </p>
                        <ViewDetails movie={movie}/>
                    </div>
                ))}
            </div>
    </div>
  )
}

export default AllMovies
