import React, { useState, useEffect } from 'react';
import axios from 'axios';
import jwtDecode from 'jwt-decode';
import { Link } from 'react-router-dom';
import {
    UserIcon,
    MagnifyingGlassIcon,
    ChevronDownIcon,
    ChevronUpIcon
} from "@heroicons/react/24/outline";


const MovieSidebar = ({ movies, onSearch, onCategoryClick, switchHidden }) => {
    const [categories, setCategories] = useState([]);
    const [randomMovies, setRandomMovies] = useState([]);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [profilePictureUrl, setProfilePictureUrl] = useState("");
    const [searchQuery, setSearchQuery] = useState("");
    const [menuVisible, setMenuVisible] = useState(false); 

    const toggleMenu = () => {
      setMenuVisible(!menuVisible);
    };

    useEffect(() => {
        shuffleMovies();
        fetchCategories();


        const authToken = localStorage.getItem('authToken');
        setIsLoggedIn(!!authToken);

        if (authToken) {
            const decodedToken = jwtDecode(authToken);
            const profilePictureName = decodedToken.imageUrl || "avatar.jpg";
            const fullProfilePictureUrl = `./images/users/${profilePictureName}`;

            setProfilePictureUrl(fullProfilePictureUrl);
        }
    }, [movies]);

    const fetchCategories = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
            const filteredCategories = response.data.filter(category => category.desc === "Ghibli Movie Category");
            setCategories(filteredCategories);
        } catch (error) {
            console.error("Error fetching categories:", error);
        }
    };
  
    const shuffleArray = (array) => {
        const shuffledArray = [...array];
        for (let i = shuffledArray.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [shuffledArray[i], shuffledArray[j]] = [shuffledArray[j], shuffledArray[i]];
        }
        return shuffledArray;
    };

    const shuffleMovies = () => {
        const shuffledMovies = shuffleArray(movies);
        const choosenMovies = shuffledMovies.slice(0, 5);
        setRandomMovies(choosenMovies);
    };

    const handleSearch = () => {
        onSearch(searchQuery);
    };

    return (
        <div className="border py-5 ps-4 lg:w-56 h-full rounded-l-lg bg-white">
            <aside>
                <div className="my-5">
                    <div className="my-5 w-full md:w-48 flex border border-red-900 rounded-full ">
                        <input
                            type="text"
                            placeholder="Search..."
                            className=" w-full md:w-36 h-4/5 mt-1 px-3 py-2 rounded-full border border-white outline-none"
                            value={searchQuery}
                            onChange={(e) => setSearchQuery(e.target.value)}
                        />
                        <button
                            className="px-3 py-1 text-red-900 "
                            onClick={handleSearch}
                        >
                            <MagnifyingGlassIcon className='w-6 h-6' />
                        </button>
                    </div>
                </div>
                <div className="menu-toggle flex justify-center w-full md:hidden">
          {menuVisible ? (
            <ChevronUpIcon onClick={toggleMenu} className="w-6 h-6" />
          ) : (
            <ChevronDownIcon onClick={toggleMenu} className="w-6 h-6" />
          )}
        </div>
            <div className={`${menuVisible || 'hidden md:block'}`}>
                <div className="mx-2 my-5 py-5 border-b border-t">
                    <h3 className="font-semibold mb-3 text-xl">Categories</h3>
                    <ul className="space-y-1">
                    <a className="text-linkColor font-semibold cursor-pointer p-2 hover:bg-red-200 hover:rounded-xl" onClick={switchHidden}> All Movies </a>
                         {categories.map(category => (
                            <li
                                className='text-sm'
                                key={category.id}
                                onClick={() => onCategoryClick(category.id)}
                            >
                                <a className="text-linkColor cursor-pointer p-2 hover:bg-red-200 hover:rounded-xl">{category.name}</a>
                            </li>
                        ))}
                    </ul>
                </div>
                <div className="mx-2 my-5 py-5 border-b">
                    <h3 className="font-semibold mb-3 text-xl">Movies just for You</h3>
                    <ul className="space-y-1">
                        {randomMovies.map(movie => (
                            <li className='text-sm flex items-center' key={movie.id}>
                                <img className="w-1/5 me-2" src={`./images/movies/${movie.imageUrls[0]}`} />
                                <Link className="text-linkColor p-2 hover:bg-red-200 hover:rounded-xl" to={`/movies/${movie.id}`}>{movie.title}</Link>
                            </li>
                        ))}
                    </ul>
                </div>
                <div className="mx-2 my-5 py-5 border-b">
                    {isLoggedIn ? (
                        <div id="userNavLink" className='m-2'>
                            <Link to="/account/user-profile" className="flex items-center">
                                <img
                                    src={profilePictureUrl}
                                    alt="User Profile"
                                    className="w-8 h-8 rounded-full cursor-pointer border border-red-900 border-lg"
                                />
                                <span className="text-s text-red-900 ms-3">Your Profile</span>
                            </Link>
                        </div>
                    ) : (
                        <div id="userNavLink" className='m-2'>
                            <Link to="/account/login" className="flex">
                                <UserIcon className="w-6 h-6 text-blue-900 nav-link me-4" />
                                <span className="text-s text-red-900">Your Profile</span>
                            </Link>
                        </div>
                    )}
                </div>
                </div>
    
            </aside>
        </div>
    );
};

export default MovieSidebar;
