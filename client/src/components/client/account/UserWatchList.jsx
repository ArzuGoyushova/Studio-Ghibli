import React, { useState, useEffect } from 'react';
import axios from 'axios';
import MovieCard from '../movies/MovieCard';
import UserSideBar from './UserSideBar';
import RemoveFromWatchlist from '../movies/RemoveFromWatchlist';

const UserWatchList = () => {
  const [userWatchlist, setUserWatchlist] = useState([]);
  const [allMovies, setAllMovies] = useState([]);

  useEffect(() => {
    fetchUserData();
    fetchMovies();
  }, []);

  const fetchUserData = async () => {
    try {
      const token = localStorage.getItem('authToken');
      const response = await axios.get('https://arzugoyushova-001-site1.htempurl.com/api/account/user-data', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      console.log(response.data);
      setUserWatchlist(response.data.movieIds || []);
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  const fetchMovies = async () => {
    try {
      const response = await axios.get('https://arzugoyushova-001-site1.htempurl.com/api/Movie');
      const filteredMovies = response.data.filter(movie => !movie.isDeleted);
      setAllMovies(filteredMovies);
    } catch (error) {
      console.error('Error fetching movies:', error);
    }
  };

  const userWatchlistMovies = allMovies.filter(movie => userWatchlist.includes(movie.id));

  return (
    <div className='flex'>
        <UserSideBar/>
        <div>
        <h2 className='mb-5 rounded text-2xl md:text-3xl lg:text-4xl text-mainBlueColor'>
        Your watchlist
      </h2>
      <MovieCard movies={userWatchlistMovies} 
      />
      <div className='flex justify-around'>
        {userWatchlistMovies.map(movie=>(
            <RemoveFromWatchlist movieId={movie.id}/>
        ))}
      </div>
      </div>
    </div>
  );
};

export default UserWatchList;
