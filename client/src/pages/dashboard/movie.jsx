import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import MovieCreateForm from "@/components/admin/MovieCreateForm";
import MovieUpdateForm from "@/components/admin/MovieUpdateForm";
import MovieDetailForm from "@/components/admin/MovieDetailForm";
import SearchInput from "@/components/admin/SearchInput";
import Pagination from "@/components/admin/Pagination";

export function Movie() {
    const [showForm, setShowForm] = useState(false);
    const [showUpdateForm, setShowUpdateForm] = useState(false);
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [movies, setMovies] = useState([]);
    const [selectedMovieId, setSelectedMovieId] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");
    const [currentPage, setCurrentPage] = useState(1);
    const [pageCount, setPageCount] = useState(null);
    const itemsPerPage = 10;

    const handleAddMovieClick = () => {
        setShowForm(true);
        setShowUpdateForm(false);
        setSelectedMovieId(null);
    };

    const handleEditMovieClick = (movieId) => {
        setShowForm(true);
        setShowUpdateForm(true);
        setSelectedMovieId(movieId);
    };

    const handleDeleteMovieClick = async (movieId) => {
        try {
            const response = await axios.post(
                `https://arzugoyushova-001-site1.htempurl.com/api/Movie/${movieId}`, {
                    headers: {
                      Authorization: `Bearer ${localStorage.getItem('authToken')}`
                    }
                  }
            );
            console.log("Movie deleted successfully!");
            fetchMovies();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDetailMovieClick = (movieId) => {
        setShowForm(false);
        setShowUpdateForm(false);
        setShowDetailForm(true);
        setSelectedMovieId(movieId);
    };

    const handlePageChange = (pageNumber) => {
        setCurrentPage(pageNumber);
      };

    useEffect(() => {
        fetchMovies();
    }, [searchTerm, currentPage]);

    const fetchMovies = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Movie");
            const allMovies = response.data.filter((movie) => !movie.isDeleted);

            const filteredMovies = allMovies.filter((movie) =>
                movie.title.toLowerCase().includes(searchTerm.toLowerCase()))

                const startIndex = (currentPage - 1) * itemsPerPage;
                const endIndex = startIndex + itemsPerPage;
                const pageCount = Math.ceil(filteredMovies.length / 10);
                setPageCount(pageCount);
            setMovies(filteredMovies.slice(startIndex, endIndex));
        } catch (error) {
            console.error("Error fetching movies:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showForm ? (
                <div className="mt-4">
                    {showUpdateForm ? (
                        <MovieUpdateForm movieId={selectedMovieId} />
                    ) : (
                        <MovieCreateForm />
                    )}
                </div>
            ) : showDetailForm ? (
                <div className="mt-4">
                    <MovieDetailForm movieId={selectedMovieId} />
                </div>
            ) : (
                <Card>
                    <button
                        onClick={handleAddMovieClick}
                        className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
                    >
                        Add a movie
                    </button>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3 flex justify-between">
                        <Typography variant="h6" color="white">
                            Movies Table
                        </Typography>
                        <SearchInput placeholder="Search by movie title.." searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "Image", "Title", "Running Time", "Video URL", ""].map((el) => (
                                        <th
                                            key={el}
                                            className="border-b border-blue-gray-50 py-3 px-5 text-left"
                                        >
                                            <Typography
                                                variant="small"
                                                className="text-[11px] font-bold uppercase text-blue-gray-400"
                                            >
                                                {el}
                                            </Typography>
                                        </th>
                                    ))}
                                </tr>
                            </thead>
                            <tbody>
                                {movies.map(({ id, imageUrls, title, runningTime, mainVideoUrl }, index) => {
                                    const uniqueKey = id || index;
                                    const className = `py-3 px-5 text-left border-b border-blue-gray-50`;
                                    return (
                                        <tr key={uniqueKey}>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {id}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                            {imageUrls && imageUrls.length > 0 ? (
        <img
            src={`./images/movies/${imageUrls[0]}`} 
            alt={`Movie ${title}`}
            className="h-20 w-20 object-cover rounded"
        />
    ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Images
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {title}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {runningTime}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {mainVideoUrl}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600 mr-2"
                                                    onClick={() => handleEditMovieClick(id)}
                                                >
                                                    Edit
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-red-600 mr-2"
                                                    onClick={() => handleDeleteMovieClick(id)}
                                                >
                                                    Delete
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600"
                                                    onClick={() => handleDetailMovieClick(id)}
                                                >
                                                    Detail
                                                </Typography>
                                            </td>
                                        </tr>
                                    );
                                })}
                            </tbody>
                        </table>
                        <Pagination pageCount={pageCount} currentPage={currentPage} onPageChange={handlePageChange} />
                    </CardBody>
                </Card>
            )}
        </div>
    );
}

export default Movie;
