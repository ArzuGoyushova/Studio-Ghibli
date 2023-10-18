import React, { useState, useEffect } from "react";
import axios from "axios";
import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';
import { Link, useNavigate } from "react-router-dom";
import {
    ChevronLeftIcon,
    ChevronRightIcon,
} from "@heroicons/react/24/outline";
import Loading from "../Loading";


const HomeMovies = () => {
    const [movies, setMovies] = useState("");
    const navigate = useNavigate();

    const goToMovies = async () => {
      navigate('/movies');
    }
    
    const PrevArrow = ({onClick}) =>{

        return(
            <div className="arrow prev w-6 h-6" onClick={onClick}>
                <ChevronLeftIcon/>
            </div>
        )
    };

const NextArrow = ({onClick}) =>{

    return(
        <div className="arrow next w-6 h-6" onClick={onClick}>
            <ChevronRightIcon/>
        </div>
    )
};



    useEffect(() => {
        fetchMovies();
    },[]);

    const fetchMovies = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Movie");
            const filteredMovies = response.data.filter((movie) => !movie.isDeleted);
            setMovies(filteredMovies);
        } catch (error) {
            console.error("Error fetching movies:", error);
        }
    };
    
    const slickSettings = {
        centerMode: true,
        lazyload: true,
        infinite: true,
        centerPadding: '0',
        slidesToShow: 7,
        speed: 300,
        nextArrow: <NextArrow/>,
        prevArrow: <PrevArrow/>,
        responsive: [
          {
            breakpoint: 1024,
            settings: {
              slidesToShow: 5,
            },
          },
          {
            breakpoint: 600,
            settings: {
              slidesToShow: 3,
            },
          },
        ],
      };

  return (
    <div className="bg-white p-5">
        <div>
        <h1 className="m-10 text-3xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
  Watch Ghibli Movies <button onClick={goToMovies} className="animate-bounce text-red-500 pointer">Here</button>
</h1>

        </div>
     {movies.length > 0 ? (
      <Slider {...slickSettings}>
        {movies.map((movie) => (
          <div key={movie.id} className="p-5 relative">
            <img
              src={`./images/movies/${movie.imageUrls[0]}`}
              alt={movie.title}
              className="rounded-lg shadow-md w-full"
          />
            <div className="rounded-lg movie-info-container absolute top-4 left-3.5 p-5 bg-black bg-opacity-50 text-white opacity-0 transition-opacity duration-300 flex flex-col justify-center items-center w-3/4 h-4/5 lg:top-5 lg:left-5 lg:w-4/5 lg:h-5/6 md:top-5 md:left-5 md:w-4/5 md:h-5/6">
          <h3 className="text-xs text-center font-semibold mb-2 text-white md:text-xl">{movie.title}</h3>
          <Link to={`/movies/${movie.id}`} className="bg-white py-1 px-2 rounded-md text-mainBlueColor text-xxs md:text-sm">Watch Now</Link>
        </div>
          </div>
        ))}
      </Slider>
    ) : (
      <Loading/>
    )}
    </div>
  )
}

export default HomeMovies
