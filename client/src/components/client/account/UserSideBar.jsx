import React, { useState, useEffect } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { RiUser2Line, RiMovie2Line, RiShoppingBasket2Line, RiCalendarEventLine, RiLogoutCircleLine, RiDeleteBin3Line } from 'react-icons/ri';
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import axios from 'axios';
import jwtDecode from 'jwt-decode';

const UserSideBar = () => {
	const [isOpen, setIsOpen] = useState(true);
	const navigate = useNavigate();

	const toggleSidebar = () => {
		setIsOpen(!isOpen);
	};

	const handleLogout = () => {
		localStorage.removeItem('authToken');
		toast.success('Logged out successfully!', { autoClose: 2000 });
		setTimeout(() => {
			navigate('/home');
			localStorage.removeItem('basketItems');
			window.location.reload();
		}, 2000);
	};

	const handleDeleteAccount = async () => {
		const authToken = localStorage.getItem('authToken');
		const userId = authToken ? jwtDecode(authToken).nameid : null;
	  
		const userConfirmed = window.confirm("Are you sure you want to delete your account?");
		if (!userConfirmed) {
		  return; 
		}
	  
		try {
		  const response = await axios.delete(
			`https://arzugoyushova-001-site1.htempurl.com/api/User/${userId}`
		  );
		  
		  if (response.status === 200) {
			toast.success('Account deleted successfully!', { autoClose: 2000 });
			localStorage.removeItem('authToken');
			setTimeout(() => {
			  navigate('/home');
			  window.location.reload();
			}, 2000);
		  } else {
			toast.error('Account deletion failed. Please try again later.', { autoClose: 2000 });
		  }
		} catch (error) {
		  console.error(error);
		  toast.error('An error occurred while deleting the account. Please try again later.', { autoClose: 2000 });
		}
	  };
	  
	  

	return (
		<div className={`userSideBar flex flex-col items-center w-16 md:w-48 h-full text-gray-900 transition-all duration-300 py-20`}>
			<div className={`flex items-center ${isOpen ? 'justify-center' : 'justify-between'} w-full px-3 mt-3`} onClick={toggleSidebar}>


				{isOpen && <span className="text-sm font-bold">User Profile</span>}
			</div>

			<div className="w-full px-2">
				<div className="flex flex-col items-center w-full mt-3 border-t border-gray-300">
					<Link className="flex cursor-pointer items-center w-full h-12 px-3 mt-2 rounded hover:bg-gray-300" to="/account/user-profile">
						<RiUser2Line />
						<span className="ml-2 text-sm font-medium hidden md:block">Edit Profile</span>
					</Link>
					<Link className="flex cursor-pointer items-center w-full h-12 px-3 mt-2 rounded hover:bg-gray-300" to="/account/user-watchlist">
						<RiMovie2Line />
						<span className="ml-2 text-sm font-medium hidden md:block">Watch List</span>
					</Link>
					<Link className="flex cursor-pointer items-center w-full h-12 px-3 mt-2 hover:bg-gray-300 rounded" to="/basket">
						<RiShoppingBasket2Line />
						<span className="ml-2 text-sm font-medium hidden md:block">Shopping Cart</span>
					</Link>
					<Link className="flex cursor-pointer items-center w-full h-12 px-3 mt-2 rounded hover:bg-gray-300" to="/account/user-events">
						<RiCalendarEventLine />
						<span className="ml-2 text-sm font-medium hidden md:block">Events</span>
					</Link>
				</div>
				<div className="flex flex-col items-center w-full mt-2 border-t border-gray-300">
					<a className="cursor-pointer flex items-center w-full h-12 px-3 mt-2 rounded hover:bg-gray-300" onClick={handleLogout}>
						<RiLogoutCircleLine />
						<span className="ml-2 text-sm font-medium hidden md:block ">Log Out</span>
					</a>
					<a className="flex items-center w-full h-12 px-3 mt-2 rounded hover:bg-gray-300" onClick={handleDeleteAccount} href="#">
						<RiDeleteBin3Line />
						<span className="ml-2 text-sm font-medium hidden md:block">Delete Account</span>
					</a>
				</div>
			</div>
			<ToastContainer />
		</div>
	);
};

export default UserSideBar;
