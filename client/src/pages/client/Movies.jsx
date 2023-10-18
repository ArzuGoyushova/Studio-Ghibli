import React, { useState, useEffect } from 'react';
import axios from 'axios';
import MovieSidebar from '@/components/client/movies/MovieSidebar';
import MovieSlider from '@/components/client/movies/MovieSlider';
import MoviesRecent from '@/components/client/movies/MoviesRecent';
import MoviesTopRated from '@/components/client/movies/MoviesTopRated';
import MoviesFamily from '@/components/client/movies/MoviesFamily';
import SearchResultsModal from '@/components/client/movies/SearchResultsModal';
import AllMovies from '@/components/client/movies/AllMovies';
import ViewDetails from '@/components/client/movies/ViewDetails';

const Movies = () => {
  const [movies, setMovies] = useState([]);
  const [showSearchModal, setShowSearchModal] = useState(false);
  const [searchResults, setSearchResults] = useState([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);
  const [categoryMovies, setCategoryMovies] = useState([]);
  const [showAllMovies, setShowAllMovies] = useState(false);

  const handleSwitchHidden = () => {
    setShowAllMovies(!showAllMovies);
  };
  const handleCategoryClick = (categoryId) => {
    const categoryMovies = movies.filter(movie => movie.categoryId === categoryId && !movie.isDeleted);

    setSelectedCategoryId(categoryId);
    setCategoryMovies(categoryMovies);
  };


  useEffect(() => {
    fetchMovies();
  }, []);

  const fetchMovies = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Movie");
      const allMovies = response.data.filter(movie => !movie.isDeleted);

      setMovies(allMovies);
    } catch (error) {
      console.error("Error fetching movies:", error);
    }
  };
  
  const handleGoBack = () => {
    setSelectedCategoryId(null);
    setCategoryMovies([]);
  };

  const handleSearch = async (searchTerm) => {
    const filteredResults = movies.filter(movie =>
      movie.title.toLowerCase().includes(searchTerm.toLowerCase())
    );

    setSearchResults(filteredResults);
    setShowSearchModal(true);
  };

  return (
    <div className="container mx-auto rounded-lg mt-5 mb-10 pb-5 md:pe-5 border flex flex-col md:flex-row">
      <div className="w-full md:w-1/4 ">
        <MovieSidebar movies={movies} onSearch={handleSearch} onCategoryClick={handleCategoryClick} switchHidden={handleSwitchHidden}/>
      </div>
      <div className="w-full md:w-3/4">
      {selectedCategoryId !== null ? (
          <div>
            <button
              className="mt-2 mb-4 px-4 py-2 bg-gray-300 text-gray-700 rounded hover:bg-gray-400"
              onClick={handleGoBack}
            >
              Go Back
            </button>
            <div className="flex space-x-2 flex-wrap space-y-2">
              {categoryMovies.map((movie, index) => (
              <div key={movie.id} className='card border p-3 flex flex-col'>
                <img src={`./images/movies/${movie.imageUrls[0]}`} alt={`Movie ${index + 1}`} className='w-56 h-80 object-cover' />
                <h3 className='text-lg font-semibold mt-2'>{movie.title}</h3>
                <p className='text-gray-500 text-sm mt-1 mb-2'>
                  IMDB Point: {movie.imdbRating}
                </p>
                <ViewDetails movie={movie}/>
              </div>
            ))}
          </div>
          </div>
          ) : (
          <div>
             {showAllMovies ? (
          <div>
            <AllMovies movies={movies} />
          </div>
        ) : (
          <div>
            <MovieSlider movies={movies} />
            <MoviesRecent movies={movies} />
            <MoviesTopRated movies={movies} />
            <MoviesFamily movies={movies} />
          </div>
        )}
          </div>
        )}

      </div>
      {showSearchModal && (
        <SearchResultsModal
          searchResults={searchResults}
          onClose={() => setShowSearchModal(false)}
        />
      )}
    </div>
  );
};

export default Movies;
