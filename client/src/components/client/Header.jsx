import React, { useEffect, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import { navLinks } from '@/constants/constant';
import jwtDecode from 'jwt-decode';

import {
    UserIcon,
    ShoppingCartIcon,
    XMarkIcon,
    Bars3Icon
} from "@heroicons/react/24/outline";
import HoverBasket from './event/HoverBasket';

const Header = () => {
    const [toggle, setToggle] = useState(false);
    const [isScrolled, setIsScrolled] = useState(false);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [profilePictureUrl, setProfilePictureUrl] = useState("");
    const location = useLocation();
    const basketItems = JSON.parse(localStorage.getItem('basketItems')) || [];
    const basketItemCount = basketItems.length;
    const [isCartHovered, setIsCartHovered] = useState(false);

    useEffect(() => {
        const handleScroll = () => {
            const scrollTop = window.pageYOffset;
            setIsScrolled(scrollTop > 0);
        };
        window.addEventListener('scroll', handleScroll);
        return () => {
            window.removeEventListener('scroll', handleScroll);
        };
    }, []);

    useEffect(() => {
        const authToken = localStorage.getItem('authToken');
        setIsLoggedIn(!!authToken);

        if (authToken) {
            const decodedToken = jwtDecode(authToken);
            const profilePictureName = decodedToken.imageUrl || "avatar.jpg";
            const fullProfilePictureUrl = `./images/users/${profilePictureName}`;

            setProfilePictureUrl(fullProfilePictureUrl);
            console.log(decodedToken);
        }
    }, []);

    return (
        <div style={{
            backgroundColor: '#247b99'
        }}>
            <header id="header" className='container mx-auto'>
                <nav className={`navbar  ${isScrolled ? 'scrolled' : ''}`}>
                    <div className='flex justify-between items-center relative'>
                        <div >
                            <Link to="/home">
                                <img className='w-28 m-2' src="./images/whiteLogo.png" alt='WhiteLogo' />
                            </Link>
                        </div>
                        <div className="menu-links">
                            <ul className="text-white list-unstyled hidden md:flex justify-end items-center flex-grow-1 h-16">
                                {navLinks.map((nav, index) => (
                                    <li key={nav.id} className={`me-4 ${location.pathname === `/${nav.id}` ? 'active' : ''}`}>
                                        <Link className="nav-link" to={`/${nav.id}`}>
                                            {nav.title}
                                        </Link>
                                    </li>
                                ))}
                            </ul>
                        </div>
                        <div className='text-blue-900 sm:flex hidden md:flex justify-end items-center flex-grow-1 h-16'>
                        <div
  id="shoppingNavLink"
  className='m-2 relative'
  onMouseEnter={() => setIsCartHovered(true)}
  onMouseLeave={() => setIsCartHovered(false)}
>
  <Link to='/basket' className={location.pathname === '/basket' ? 'text-red-900' : 'text-white'}>
    <ShoppingCartIcon className={`w-6 h-6 nav-link`} />
  </Link>
  {basketItemCount > 0 && (
    <span className="absolute -top-2 -right-2 bg-red-500 text-white rounded-full px-1.5 py-0.5 text-xxs">
      {basketItemCount}
    </span>
  )}
  {isCartHovered && <HoverBasket/>}
</div>



                            {isLoggedIn ? (
                                <div id="userNavLink" className='m-2'>
                                    <Link to="/account/user-profile">
                                        <img
                                            src={profilePictureUrl}
                                            alt="User Profile"
                                            className="w-6 h-6 rounded-full cursor-pointer"
                                        />
                                    </Link>
                                </div>
                            ) : (
                                <div id="userNavLink" className='m-2'>
                                    <Link to="/account/login">
                                        <UserIcon className="w-6 h-6 text-white nav-link" />
                                    </Link>
                                </div>
                            )}

                        </div>
                        <div className="md:hidden flex-grow-1 justify-end items-center">
                            {toggle ? (
                                <XMarkIcon
                                    className="w-6 h-6 text-white cursor-pointer me-3"
                                    onClick={() => setToggle((prev) => !prev)}
                                />
                            ) : (
                                <Bars3Icon
                                    className="w-6 h-6 text-white cursor-pointer me-3"
                                    onClick={() => setToggle((prev) => !prev)}
                                />
                            )}
                            <div
                                id="sidebar"
                                className={`${toggle ? 'flex' : 'hidden'
                                    } p-5 flex-col justify-start items-center absolute top-16 right-10 mx-4 my-2 w-64 h-96 z-10 bg-mainBlueColor rounded-xl`}
                            >
                                  <div className="menu-links h-full text-center ">
                            <ul className="text-white list-unstyled flex-col space-y-2 justify-center items-center flex-grow-1 h-16 text-xl">
                                {navLinks.map((nav, index) => (
                                    <li key={nav.id} className={` ${location.pathname === `/${nav.id}` ? 'active' : ''}`}>
                                        <Link className="nav-link text-2xl" to={`/${nav.id}`}>
                                            {nav.title}
                                        </Link>
                                    </li>
                                ))}
                            </ul>
                        </div>
                        <div className='text-blue-900 flex-col justify-end items-center flex-grow-1 h-16'>
                            <div id="shoppingNavLink" className='m-2 relative'>
                                <Link to='/basket' className={location.pathname === '/basket' ? 'text-red-900' : 'text-white'}>
                                    <ShoppingCartIcon className={`w-6 h-6 nav-link`} />
                                </Link>
                                {basketItemCount > 0 && (
                                    <span className="absolute -top-2 -right-2 bg-red-500 text-white rounded-full px-1.5 py-0.5 text-xxs">
                                        {basketItemCount}
                                    </span>
                                )}
                            </div>


                            {isLoggedIn ? (
                                <div id="userNavLink" className='m-2'>
                                    <Link to="/account/user-profile">
                                        <img
                                            src={profilePictureUrl}
                                            alt="User Profile"
                                            className="w-6 h-6 rounded-full cursor-pointer"
                                        />
                                    </Link>
                                </div>
                            ) : (
                                <div id="userNavLink" className='m-2'>
                                    <Link to="/account/login">
                                        <UserIcon className="w-6 h-6 text-white nav-link" />
                                    </Link>
                                </div>
                            )}

                        </div>
                            </div>
                        </div>
                    </div>
                </nav>
            </header>
        </div>
    )
}

export default Header
