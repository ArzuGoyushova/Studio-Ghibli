import React from 'react'
import { Link } from 'react-router-dom'


const Games = () => {
  return (
    <div className='container mx-auto'>
       <section id='gamesSection' className='mb-30'>
        <div id='gameHeader' className='text-center'>
          <h1 className='m-10 text-3xl md:text-5xl lg:text-6xl dark:text-white'>
            Choose a Game to Play
          </h1>
          <h3 className='mb-10 text-xl md:text-2xl lg:text-3xl text-red-500'>
            You can have some fun time by playing games!
          </h3>
          <div
            id='gameLinks'
            className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-2 gap-8 my-10 mx-10'
          >
              <div className='flex flex-col items-center p-4 border border-gray-300 rounded-lg shadow-md transition duration-300 transform hover:scale-105'>
                <Link to="/games/puzzlegame">
                  <img src="./images/home/puzzle.gif" alt="puzzle game" className='w-64 h-64 rounded-full mb-4' />
                </Link>
                <h4 className='text-xl font-semibold mb-2'>Puzzle Game</h4>
                <p className='text-sm text-gray-600'>Solve puzzles with Ghibli characters and scenes.</p>
              </div>
              <div className='flex flex-col items-center p-4 border border-gray-300 rounded-lg shadow-md transition duration-300 transform hover:scale-105'>
                <Link to="/games/memorygame">
                  <img src="./images/home/spriteBuddies.gif" alt="memory game" className='w-64 h-64 rounded-full mb-4' />
                </Link>
                <h4 className='text-xl font-semibold mb-2'>Memory Card Game</h4>
                <p className='text-sm text-gray-600'>Test your memory skills with Ghibli-themed cards.</p>
              </div>
          </div>
        </div>
      </section>
    </div>
  )
}

export default Games
