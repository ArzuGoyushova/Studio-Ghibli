import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { toast } from 'react-toastify';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import setAuthToken from '../account/setAuthToken';

const RemoveFromWatchlist = ({ movieId }) => {
  const [userId, setUserId] = useState("");

  useEffect(() => {
    fetchUserData();
  }, []);

  const fetchUserData = async () => {
    try {
      const token = localStorage.getItem('authToken');
      setAuthToken(token);

      const response = await axios.get('https://arzugoyushova-001-site1.htempurl.com/api/account/user-data', {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      const userId = response.data.id;
      console.log(response.data.id);
      setUserId(userId);
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  const handleRemoveFromWatchlist = async () => {

    try {
         
        const response = await axios.delete(
          `https://arzugoyushova-001-site1.htempurl.com/api/UserMovie/remove-movie?movieId=${movieId}&userId=${userId}`,
        );

      toast.success('Removed from watchlist successfully!', {
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      },
      setTimeout(() => {
        window.location.reload();
      }, 2000)
      );
    } catch (error) {
      toast.error('Error removing from watchlist. Please try again.', {
        position: 'top-right',
        autoClose: 2000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    }
  };

  return (
    <div>
    <button
      onClick={handleRemoveFromWatchlist}
      className='py-3 px-5 border border-red-800 text-white bg-red-800 rounded-full hover:bg-red-900'
    >
      Remove
    </button>
    <ToastContainer/>
    </div>
  );
};

export default RemoveFromWatchlist;
