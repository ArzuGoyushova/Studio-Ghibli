import React from 'react'
import { Link } from 'react-router-dom'
const ViewDetails = ({movie}) => {
  return (
    
      <Link to={`/movies/${movie.id}`} className='mt-auto px-5 py-2 text-center rounded-full bg-mainBlueColor text-white rounded hover:bg-blue-700'>
                            View Details
     </Link>

  )
}

export default ViewDetails
