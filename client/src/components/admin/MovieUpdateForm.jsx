import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function MovieUpdateForm({ movieId }) {
  const [movieData, setMovieData] = useState(null);
  const [title, setTitle] = useState("");
  const [releaseDate, setReleaseDate] = useState("");
  const [desc, setDesc] = useState("");
  const [director, setDirector] = useState("");
  const [runningTime, setRunningTime] = useState("");
  const [genre, setGenre] = useState("");
  const [trailerVideoUrl, setTrailerVideoUrl] = useState("");
  const [mainVideoUrl, setMainVideoUrl] = useState("");
  const [imdbRating, setImdbRating] = useState("");
  const [categoryId, setCategoryId] = useState("");
  const [selectedImages, setSelectedImages] = useState([]);
  const [existingPictures, setExistingPictures] = useState([]);

  const [categories, setCategories] = useState([]);

  useEffect(() => {
    fetchMovieData();
    fetchCategories();
  }, []);

  const fetchMovieData = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Movie/${movieId}`);
      const movieData = response.data;
      setMovieData(movieData);
      setTitle(movieData.title);
      setDesc(movieData.description);
      setDirector(movieData.director);
      setGenre(movieData.genre);
      setReleaseDate(movieData.releaseDate);
      setRunningTime(movieData.runningTime);
      setTrailerVideoUrl(movieData.trailerVideoUrl);
      setMainVideoUrl(movieData.mainVideoUrl);
      setImdbRating(movieData.imdbRating);
      setCategoryId(movieData.categoryId);
      setExistingPictures(movieData.imageUrls);
    } catch (error) {
      console.error("Error fetching movie data:", error);
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
  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const formData = new FormData();
      formData.append("MovieId", movieId);
      formData.append("MovieDTO.Title", title);
      formData.append("MovieDTO.ReleaseDate", releaseDate);
      formData.append("MovieDTO.Description", desc);
      formData.append("MovieDTO.Director", director);
      formData.append("MovieDTO.RunningTime", runningTime);
      formData.append("MovieDTO.TrailerVideoUrl", trailerVideoUrl);
      formData.append("MovieDTO.MainVideoUrl", mainVideoUrl);
      formData.append("MovieDTO.Genre", genre);
      formData.append("MovieDTO.ImdbRating", imdbRating);
      formData.append("MovieDTO.CategoryId", categoryId);
      selectedImages.forEach((image) => formData.append("MovieDTO.NewPictures", image));
      existingPictures.forEach((imageUrl) => formData.append("MovieDTO.ExistingPictures", imageUrl));

      const response = await axios.put(
        `https://arzugoyushova-001-site1.htempurl.com/api/Movie/${movieId}`,
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );


      toast.success("Movie updated successfully!", {
        position: "top-right",
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        onClose: () => {
          setTimeout(() => {
            window.location.reload();
          }, 2000);
        },
      });
    } catch (error) {
      toast.error("Error updating movie. Please try again.", {
        position: "top-right",
        autoClose: 2000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    }
  };
  

  const handleDeleteImage = async (imageType, index, imageUrl) => {
    try {
        await axios.delete(`https://arzugoyushova-001-site1.htempurl.com/api/Image/images/Movies/${imageUrl}`);
        
            const updatedImages = [...existingPictures];
            updatedImages.splice(index, 1);
            setExistingPictures(updatedImages);
       
        toast.success("Image deleted successfully!");
    } catch (error) {
        toast.error("Failed to delete image. Please try again later.");
    }
};


  return (
    <form onSubmit={handleSubmit}>
           <div className="flex justify-end">
        <button
          onClick={refreshPage}
          className="text-left bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
        >
          Go Back
        </button>
      </div>
      <div className="flex flex-col gap-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="MovieName">
          Update movie
        </label>
        <input
          id="title"
          type="text"
          placeholder="Movie Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
           <input
          id="releaseDate"
          type="date"
          placeholder="Release Date"
          value={releaseDate ? releaseDate.toString().split("T")[0] : ""}
          onChange={(e) => setReleaseDate(new Date(e.target.value))}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="desc"
          type="text"
          placeholder="Description"
          value={desc}
          onChange={(e) => setDesc(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
         <input
          id="director"
          type="text"
          placeholder="Director"
          value={director}
          onChange={(e) => setDirector(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
        <input
          id="runningTime"
          type="number"
          placeholder="Running Time"
          value={runningTime}
          onChange={(e) => setRunningTime(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="genre"
          type="text"
          placeholder="Genre"
          value={genre}
          onChange={(e) => setGenre(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
         <input
          id="trailerVideoUrl"
          type="url"
          placeholder="Trailer URL"
          value={trailerVideoUrl}
          onChange={(e) => setTrailerVideoUrl(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
          <input
          id="mainVideoUrl"
          type="url"
          placeholder="Video URL"
          value={mainVideoUrl}
          onChange={(e) => setMainVideoUrl(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
          <input
          id="imdbRating"
          type="number"
          placeholder="IMDB Rating"
          value={imdbRating}
          onChange={(e) => setImdbRating(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
        <div className="relative">
          <select
            id="categoryId"
            value={categoryId}
            onChange={(e) => setCategoryId(e.target.value)}
            className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          >
            <option value="">
              Select different category
            </option>
            {categories.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </select>
          <div className="pointer-events-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
            <svg
              className="fill-current h-4 w-4"
              xmlns="https://www.w3.org/2000/svg"
              viewBox="0 0 20 20"
            >
              <path
                fillRule="evenodd"
                d="M6.293 9.293a1 1 0 011.414 0L10 11.586l2.293-2.293a1 1 0 111.414 1.414l-3 3a1 1 0 01-1.414 0l-3-3a1 1 0 010-1.414z"
                clipRule="evenodd"
              />
            </svg>
          </div>
        </div>
        <div>
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="existingImages">
          Current Movie Images
        </label>
        {existingPictures.map((imageUrl, index) => (
    <div key={index} className="flex items-center gap-2 mb-2">
        <img
            src={`./images/movies/${imageUrl}`}
            alt={`Movie Image ${index + 1}`}
            className="h-16 w-16 object-cover rounded"
        />
        <button
            type="button"
            onClick={() => handleDeleteImage("movies", index, imageUrl)}
            className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 rounded"
        >
            Delete
        </button>
    </div>
))}
      <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="images">
            Movie Images
          </label>
          <input
            type="file"
            id="images"
            multiple
            onChange={(e) => setSelectedImages(Array.from(e.target.files))}
            className="py-2 px-3 border rounded"
          />
        </div>


        <button
          type="submit"
          className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
        >
          Update
        </button>
      </div>
      <ToastContainer />
    </form>
  );
}

export default MovieUpdateForm;