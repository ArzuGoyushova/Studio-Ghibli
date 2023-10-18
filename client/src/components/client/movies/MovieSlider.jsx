import React, { useState } from 'react';
import Slider from 'react-slick';
import {
  ChevronLeftIcon,
  ChevronRightIcon,
} from "@heroicons/react/24/outline";
import { FaImdb } from 'react-icons/fa';
import AddToWatchlist from './AddToWatchlist';
import ViewDetails from './ViewDetails';

const MovieSlider = ({ movies }) => {
  const [activeSlide, setActiveSlide] = useState(0);
  const [activeImageIndex, setActiveImageIndex] = useState(0);

  const PrevArrow = ({ onClick }) => (
    <div className="arrow prev w-6 h-6" onClick={onClick}>
      <ChevronLeftIcon />
    </div>
  );

  const NextArrow = ({ onClick }) => (
    <div className="arrow next w-6 h-6" onClick={onClick}>
      <ChevronRightIcon />
    </div>
  );

  const settings = {
    dots: false,
    infinite: true,
    speed: 300,
    nextArrow: <NextArrow />,
    prevArrow: <PrevArrow />,
    slidesToShow: 1,
    slidesToScroll: 1,
    beforeChange: (current, next) => {
      setActiveSlide(next);
      setActiveImageIndex(0);
    },
    fade: true,
  };


  const handleThumbnailClick = (index) => {
    setActiveImageIndex(index);
  };

  return (
    <div>
      <div className=" relative movie-slider-container transition-opacity duration-300 ease-in-out">
        <Slider {...settings} className="w-full">
          {movies.map((movie, movieIndex) => (
            <div
              key={movieIndex}
              className={`movie-slide ${activeImageIndex !== 0 ? 'fade' : ''}`}
            >
              <div className="main-image">
                <img
                  src={`./images/movies/${movies[activeSlide].imageUrls[activeImageIndex + 1]
                    }`}
                  alt={`Movie ${activeSlide + 1}`}
                  className="transition-opacity duration-300 ease-in-out"
                />
               
              </div>
              <div className="absolute top-0 left-0 p-6 bg-black h-full bg-opacity-50 text-white">
                  <div className=" w-full md:w-1/2 pt-20">
                    <span className="text-m font-bold md:text-xl flex"><FaImdb className='w-7 h-7 text-yellow-500 me-1' /> : {movie.imdbRating}</span>
                    <h2 className="text-xl my-5 text-white drop-shadow-md leading-none tracking-tight md:text-5xl lg:text-6xl ">{movie.title}</h2>
                    <p className="my-3">
                      {movie.description.length > 200
                        ? `${movie.description.substr(0, 200)}...`
                        : movie.description}
                    </p>
                  </div>
                </div>
                
                
              <div className='absolute bottom-28 left-6 md:bottom-6 space-y-2 md:space-x-2 flex flex-col justify-end items-start md:flex-row  md:items-center md:justify-start md:space-y-0'>
                      <ViewDetails movie={movie} />
                      <AddToWatchlist movieId={movie.id}/>
                    </div>
              <div className="thumbnails">
                {movie.imageUrls.slice(1).map((imageUrl, index) => (
                  <div
                    key={index}
                    className={`thumbnail ${activeImageIndex === index ? 'active' : ''
                      }`}
                    onClick={() => handleThumbnailClick(index)}
                  >
                    <img
                      src={`./images/movies/${imageUrl}`}
                      alt={`Thumbnail ${movieIndex + 1}-${index + 1}`}
                      className="transition-opacity duration-300 ease-in-out"
                    />
                  </div>
                ))}
              </div>
            </div>
            
          ))}
        </Slider>
      </div>
    </div>
  );
};

export default MovieSlider;
