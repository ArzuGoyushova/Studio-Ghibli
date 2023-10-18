import axios from "axios";
import React, { useState, useEffect } from "react";

function MovieDetailForm({ movieId }) {
    const [movie, setMovie] = useState(null);
    const [categoryId, setCategoryId] = useState(null);
    const [categories, setCategories] = useState(null);

    useEffect(() => {
        fetchMovieDetails();
        fetchCategories();
    }, [movieId]);

    const fetchMovieDetails = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Movie/${movieId}`);
            setCategoryId(response.data.categoryId);
            setMovie(response.data);
        } catch (error) {
            console.error("Error fetching movie details:", error);
        }
    };
    const fetchCategories = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
            setCategories(response.data);
        } catch (error) {
            console.error("Error fetching categories:", error);
        }
    };

    function refreshPage() {
        window.location.reload(false);
      }

    const getCategoryNameById = (categories, categoryId) => {
        const categoryKeys = Object.keys(categories ?? {});
    for (const key of categoryKeys) {
      if (categories[key].id === categoryId) {
        return categories[key].name;
      }
    }
    return 'Category Not Found';
      };

      const categoryName = getCategoryNameById(categories, categoryId);

      
    const dataFields = [
        { label: "Id", property: "id" },
        { label: "Title", property: "title" },
        { label: "Release Date", property: "releaseDate" },
        { label: "Director", property: "director" },
        { label: "Genre", property: "genre" },
        { label: "Running Time", property: "runningTime" },
        { label: "Trailer URL", property: "trailerVideoUrl" },
        { label: "Video URL", property: "mainVideoUrl" },
        { label: "Description", property: "description" },
        { label: "IMDB Rating", property: "imdbRating" },
    ];

    

    return (
        <div>
           <div className="flex justify-end">
        <button
          onClick={refreshPage}
          className="text-left bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
        >
          Go Back
        </button>
      </div>
            {movie && (
                <div>
                    <div className="px-4 sm:px-0">
                        <h3 className="text-base font-semibold leading-7 text-gray-900">Movie Details</h3>
                    </div>
                    <div className="mt-6 border-t border-gray-100">
                        <dl className="divide-y divide-gray-500">
                            {dataFields.map((field) => (
                                <div key={field.label} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        {field.label}:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {movie[field.property]}
                                    </dd>
                                </div>
                            ))}
                            <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        Category:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {categoryName}
                                    </dd>
                                </div>


                            <div key={movie.imageUrls} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                    Pictures:
                                </dt>
                                <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                    {movie.imageUrls && movie.imageUrls.length > 0 ? (
                                        movie.imageUrls.map((imageUrl, idx) => (

                                            <img
                                                key={idx}
                                                src={`./images/movies/${imageUrl}`}
                                                alt={`Movie ${movie.name}`}
                                                className="h-16 w-16 object-cover rounded"
                                            />
                                        ))
                                    ) : (
                                        <Typography className="text-xs font-semibold text-blue-gray-600">
                                            No Images
                                        </Typography>
                                    )}
                                </dd>
                            </div>

                        </dl>
                    </div>
                </div>
            )}
        </div>
        
    );
}

export default MovieDetailForm;
