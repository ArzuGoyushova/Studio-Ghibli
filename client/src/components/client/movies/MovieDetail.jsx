import React, { useState, useEffect } from 'react';
import ReactPlayer from 'react-player';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import AddToWatchlist from './AddToWatchlist';
import Loading from '../Loading';
import { StarIcon } from '@heroicons/react/24/solid';
import jwtDecode from 'jwt-decode';
import { toast } from 'react-toastify';

const MovieDetail = () => {
    const { movieId } = useParams();
    const [movie, setMovie] = useState("");
    const [selectedImageIndex, setSelectedImageIndex] = useState(1);
    const [ratingHover, setRatingHover] = useState(0);
    const [reviewForm, setReviewForm] = useState({
        rating: 0,
        comment: ""
    });
    const [username, setUsername] = useState("");
    const [showReviews, setShowReviews] = useState(false);
    const [movieReviews, setMovieReviews] = useState("");

    useEffect(() => {
        const token = localStorage.getItem('authToken');

        if (token) {
            const decodedToken = jwtDecode(token);
            const decodedUsername = decodedToken.username;
            setUsername(decodedUsername);
        }
        fetchMovie();
    }, []);

    const fetchMovie = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Movie/${movieId}`);
            const movie = response.data;
            setMovie(movie);
        } catch (error) {
            console.error("Error fetching movie:", error);
        }
    };

    const handleShowReviews = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Review`,
                { params: { movieId: movieId } });
            console.log(response.data);
            const movieReviews = response.data;
            setMovieReviews(movieReviews);
            setShowReviews(true);
        } catch (error) {
            console.error("Error fetching reviews:", error);
        }

    };
    const calculateAverageRating = () => {
        const totalRating = movieReviews.reduce((sum, review) => sum + review.rate, 0);
        const averageRating = totalRating / movieReviews.length;
    
        if (isNaN(averageRating)) {
            return 0;
        }
    
        return averageRating.toFixed(1);
    };
    
    const handleThumbnailClick = (index) => {
        setSelectedImageIndex(index);
    };

    const handleStarClick = (rating) => {
        setReviewForm(prevState => ({
            ...prevState,
            rating
        }));
    };

    const handleStarHover = (rating) => {
        setRatingHover(rating);
    };

    const handleStarHoverEnd = () => {
        setRatingHover(0);
    };

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setReviewForm((prevState) => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmitReview = async () => {

        try {
            const userReviewExists = movieReviews.some(
                (review) => review.username === username
            );

            if (userReviewExists) {
                toast.error("You have already submitted review for this movie")
                return;
            }
            const newReview = {
                reviewDTO: {
                    username: username,
                    rate: reviewForm.rating,
                    comment: reviewForm.comment,
                    movieId: movieId
                }
            };

            await axios.post(`https://arzugoyushova-001-site1.htempurl.com/api/Review`, newReview);

            setReviewForm({
                rating: 0,
                comment: ""
            });

            setTimeout(() => {
                window.location.reload();
            }, 2000);
        } catch (error) {
            console.error("Error submitting review:", error);
        }
    };

    if (!movie) {
        return <Loading />
    }
    return (
        <div className="">
            <div className='detail-header relative'>
                <img className='object-cover w-full' src={`./images/movies/${movie.imageUrls[selectedImageIndex]}`} />
                <div className='flex flex-col md:flex-row'>
                    <div className='w-1/2 md:w-1/3 '>
                        <img src={`./images/movies/${movie.imageUrls[0]}`} className="w-64 mt-[-120px] ms-[100px] rounded-xl outline outline-white" />
                    </div>
                    <div className='movie-info space-y-1 w-full md:w-1/3 text-center'>
                        <h2 className='my-5 rounded text-2xl md:text-3xl lg:text-4xl text-mainBlueColor'>
                            {movie.title}
                        </h2>
                        <p className='text-lg'><span className='text-red-800 font-bold'>Duration: </span>{movie.runningTime} minutes</p>
                        <p className='text-lg'><span className='text-red-800 font-bold'>Release Date: </span>{formatDate(movie.releaseDate)}</p>
                        <p className='text-lg'><span className='text-red-800 font-bold'>Director: </span>{movie.director}</p>
                        <p className='text-lg'><span className='text-red-800 font-bold'>IMDB Rating: </span>{movie.imdbRating}</p>
                        <p className='text-lg'><span className='text-red-800 font-bold'>Genre: </span>{movie.genre}</p>
                        <div className="py-4">
                        <AddToWatchlist movieId={movieId} />
                        </div>
                    </div>
                    <div className='movie-info flex flex-col space-y-2 items-center md:items-end w-full md:w-1/3 md:justify-start my-2 md:pe-28'>
                        {movie.imageUrls.slice(1).map((image, index) => (
                            <img
                                key={index + 1}
                                src={`./images/movies/${image}`}
                                alt={`Movie Image ${index + 1}`}
                                className={`w-48 ${selectedImageIndex === index + 1 ? 'active' : ''}`}
                                onClick={() => handleThumbnailClick(index + 1)}
                            />
                        ))}
                    </div>

                </div>
                <div className='flex flex-col mx-4 md:mx-28'>
                    <h2 className='my-5 rounded text-3xl md:text-4xl text-mainBlueColor'>
                        Description:
                    </h2>
                    <p className='text-lg'>{movie.description}</p>
                </div>
                <div className='flex flex-col mx-4 md:mx-28 '>
                    <div className="video-container my-10 md:my-20">
                        <h2 className='my-5 rounded text-2xl md:text-3xl lg:text-4xl text-mainBlueColor'>
                            Watch Trailer:
                        </h2>
                        <ReactPlayer url={movie.trailerVideoUrl} controls width="100%" height="80%" />
                    </div>

                    <div className="video-container">
                        <h2 className='my-5 rounded text-2xl md:text-3xl lg:text-4xl text-mainBlueColor'>
                            Watch Movie:
                        </h2>
                        <ReactPlayer url={movie.mainVideoUrl} controls width="100%" height="80%" />
                    </div>
                </div>
            </div>
            <div className="review-content my-5 mx-5 md:mx-24">
                {showReviews ? (
                    <div>
                        <div className='flex justify-between'>
                         <h2 className="text-2xl mb-3">Reviews:</h2>
                         <h2 className="text-2xl mb-3">Average Rating: {calculateAverageRating()}</h2>
                    </div>
                        {movieReviews.length === 0 ? (
                            <p>No Reviews yet</p>
                        ) : (
                            movieReviews.map((movieReview, index) => (
                                <div key={index} className="bg-gray-100 p-4 rounded-lg mb-4">
                                    <p className="text-lg font-semibold">{movieReview.username}</p>
                                    <p className="text-xs text-gray-500 mb-1">
                                        {Array.from({ length: movieReview.rate }, (_, index) => (
                                            <StarIcon key={index} className="text-yellow-500 w-3 h-3 inline-block" />
                                        ))}
                                        {" - "}
                                        {formatDate(movieReview.date)}
                                    </p>
                                    <p className="text-gray-700">{movieReview.comment}</p>
                                </div>
                            ))
                        )}
                    </div>
                ) : (
                    <button onClick={handleShowReviews} className="w-full px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 focus:outline-none">
                        Show Reviews
                    </button>
                )}
            </div>


            <div className="review-form my-5 mx-5 md:mx-24 ">
                <h3 className="text-2xl mb-2">Leave a Review:</h3>
                <div className="stars flex">
                    {[1, 2, 3, 4, 5].map((starIndex) => (
                        <StarIcon
                            key={starIndex}
                            className={`h-8 w-8 cursor-pointer ${(starIndex <= (ratingHover || reviewForm.rating)) ? "text-yellow-500" : "text-gray-400"
                                }`}
                            onClick={() => handleStarClick(starIndex)}
                            onMouseEnter={() => handleStarHover(starIndex)}
                            onMouseLeave={handleStarHoverEnd}
                        />
                    ))}
                </div>
                <div className="mt-3">
                    <label htmlFor="comment" className="block mb-1 font-semibold">
                        Comment:
                    </label>
                    <textarea
                        id="comment"
                        name="comment"
                        value={reviewForm.comment}
                        onChange={handleInputChange}
                        className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                        rows="4"
                        placeholder="Leave your comment here..."
                    />

                    <button
                        type="button"
                        onClick={handleSubmitReview}
                        className="mt-3 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600 focus:outline-none"
                    >
                        Submit Review
                    </button>
                </div>
            </div>
        </div>
    )
}

function formatDate(dateString) {
    const options = { year: 'numeric', month: '2-digit', day: '2-digit' };
    return new Date(dateString).toLocaleDateString(undefined, options);
}

export default MovieDetail
