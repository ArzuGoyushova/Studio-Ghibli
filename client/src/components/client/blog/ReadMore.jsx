import React from 'react'
import { Link } from 'react-router-dom'

const ReadMore = ({blog}) => {
  return (
    
      <Link to={`/blog/${blog.id}`} className="px-4 py-2 mt-4 rounded-md bg-blue-500 text-white text-center hover:bg-blue-600 transition duration-300 ease-in-out">
                            Read More
     </Link>

  )
}

export default ReadMore
