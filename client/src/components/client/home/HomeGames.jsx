import React from 'react';
import {Link, useNavigate } from 'react-router-dom';

const HomeGames = () => {
  const navigate = useNavigate();

  const goToGames = async () => {
    navigate('/games');
  }
  const games = [
    {
      id: 1,
      name: 'Ghibli Puzzle',
      link: '/games/puzzlegame',
      description: 'Solve puzzles with Ghibli characters and scenes.',
      thumbnail: './images/home/puzzle.gif',
    },
    {
      id: 2,
      name: 'Memory Card Game',
      link: '/games/memorygame',
      description: 'Test your memory skills with Ghibli-themed cards.',
      thumbnail: './images/home/spriteBuddies.gif',
    },
  ];

  return (
    <div className='my-20 container mx-auto'>
      <section id="game-section">
        <div className='game-header'>
          <h1 className="m-4 text-3xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
            <button onClick={goToGames} className="animate-bounce text-red-500 pointer">Play</button> Ghibli games and have fun!
          </h1>
        </div>
        <div className="grid grid-cols-1 md:grid-cols-2 gap-8 ">
          {games.map((game) => (
            <div key={game.id} className="bg-white shadow-lg rounded-lg p-6  flex flex-col items-center">
              <div className="mb-4">
                <img src={game.thumbnail} alt={`${game.name} Thumbnail`} className="game-gif" />
              </div>
              <h2 className="text-xl font-semibold mb-2">{game.name}</h2>
              <p className="text-gray-600 text-center">{game.description}</p>
              <Link to={game.link} className="border border-red-500 rounded-xl w-28 py-1 text-center block my-4 text-red-500 font-semibold hover:bg-red-500 hover:text-white">
                Play Now
              </Link>
            </div>
          ))}
        </div>
      </section>
    </div>
  );
};

export default HomeGames;
