import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { toast } from 'react-toastify';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import setAuthToken from '../account/setAuthToken';

const AddToWatchlist = ({ movieId }) => {
  const [userData, setUserData] = useState(null);

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

      setUserData(response.data);
    } catch (error) {
      console.error('Error fetching user data:', error);
    }
  };

  const handleAddToWatchlist = async () => {
   

    try {
        const formData = new FormData();
        formData.append("Id", userData.id);
        formData.append("ProfileDTO.Id", userData.id);
        formData.append("ProfileDTO.UserName", userData.userName);
        formData.append("ProfileDTO.FullName", userData.fullName);
        formData.append("ProfileDTO.Email", userData.email);
        formData.append("ProfileDTO.PhoneNumber", userData.phoneNumber);
        formData.append("ProfileDTO.Birthday", userData.birthday);
        formData.append("ProfileDTO.Country", userData.country);
        formData.append("ProfileDTO.City", userData.city);
        formData.append("ProfileDTO.Address", userData.address);
        formData.append("ProfileDTO.ZipCode", userData.zipCode);
        formData.append("ProfileDTO.MovieIds", movieId);
  
        const response = await axios.put(
          `https://arzugoyushova-001-site1.htempurl.com/api/Account/${userData.id}`,
          formData,
          {
            headers: {
              "Content-Type": "multipart/form-data",
              Authorization: `Bearer ${localStorage.getItem('authToken')}`
            },
          }
        );

      toast.success('Added to watchlist successfully!', {
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    } catch (error) {
      toast.error('Error adding to watchlist. Please sign in and try again.', {
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
      onClick={handleAddToWatchlist}
      className='py-2 px-4 border border-red-800 text-white bg-red-800 rounded-full hover:bg-red-900'
    >
      Add to Watchlist
    </button>
    </div>
  );
};

export default AddToWatchlist;
