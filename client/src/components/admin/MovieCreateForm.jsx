import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

const validationSchema = Yup.object().shape({
  title: Yup.string().required("Please fill in the field.").max(120, "Title can't be longer than 120 characters."),
  genre: Yup.string().required("Please fill in the field.").max(30, "Genre can't be longer than 30 characters."),
  director: Yup.string().required("Please fill in the field.").max(30, "Director name can't be longer than 30 characters."),
  desc: Yup.string().required("Please fill in the field."),
  runningTime: Yup.string().required("Please fill in the field."),
  trailerVideoUrl: Yup.string().required("Please fill in the field."),
  mainVideoUrl: Yup.string().required("Please fill in the field."),
  imdbRating: Yup.string().required("Please fill in the field."),
  releaseDate: Yup.string().required("Please fill in the field.")
});

function MovieCreateForm() {
  const [selectedImages, setSelectedImages] = useState([]);

  const [categories, setCategories] = useState([]);

  useEffect(() => {
    fetchCategories();
  }, []);

  const fetchCategories = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
      setCategories(response.data);
    } catch (error) {
      console.error("Error fetching categories:", error);
    }
  };


  const handleSubmit = async (values, { setErrors }) => {
    const { title, desc, genre, releaseDate, director, runningTime, trailerVideoUrl, mainVideoUrl, imdbRating, categoryId } = values;
    try {
      const formData = new FormData();
      formData.append("MovieDTO.Title", title);
      formData.append("MovieDTO.Description", desc);
      formData.append("MovieDTO.ReleaseDate", releaseDate);
      formData.append("MovieDTO.Director", director);
      formData.append("MovieDTO.RunningTime", runningTime);
      formData.append("MovieDTO.Genre", genre);
      formData.append("MovieDTO.TrailerVideoUrl", trailerVideoUrl);
      formData.append("MovieDTO.MainVideoUrl", mainVideoUrl);
      formData.append("MovieDTO.ImdbRating", imdbRating);
      formData.append("MovieDTO.CategoryId", categoryId);

      selectedImages.forEach((image) => formData.append("MovieDTO.NewPictures", image));


      const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Movie", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      toast.success("Movie created successfully!", {
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
      if (error.response && error.response.data && error.response.data.errors) {
        const validationErrors = error.response.data.errors;
        setErrors(validationErrors);
      } else {
        toast.error("Error creating movie. Please try again.", {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
        });
      }
    }
  };

  return (
    <Formik
      initialValues={{
        title: "",
        desc: "",
        releaseDate: "",
        genre: "",
        director: "",
        runningTime: "",
        trailerVideoUrl: "",
        mainVideoUrl: "",
        categoryId: "",
        imdbRating: "",
      }}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      {({ getFieldProps, touched, errors }) => (
        <Form>
          <div className="flex flex-col gap-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="title">
              Add a new event
            </label>
            <ErrorMessage name="title" component="div" className="text-red-600" />
            <Field
              id="title"
              type="text"
              placeholder="Event Title"
              {...getFieldProps('title')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.title && errors.title ? 'border-red-500' : ''}`}
              required
            />
            <ErrorMessage name="releaseDate" component="div" className="text-red-600" />
            <Field
              id="releaseDate"
              type="date"
              placeholder="Release Date"
              {...getFieldProps('releaseDate')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="desc" component="div" className="text-red-600" />
            <Field
              id="desc"
              type="text"
              placeholder="Description"
              {...getFieldProps('desc')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
            <ErrorMessage name="director" component="div" className="text-red-600" />
            <Field
              id="director"
              type="text"
              placeholder="Director"
              {...getFieldProps('director')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
            <ErrorMessage name="runningTime" component="div" className="text-red-600" />
            <Field
              id="runningTime"
              type="number"
              placeholder="Running Time"
              {...getFieldProps('runningTime')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="genre" component="div" className="text-red-600" />
            <Field
              id="genre"
              type="text"
              placeholder="Genre"
              {...getFieldProps('genre')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="trailerVideourl" component="div" className="text-red-600" />
            <Field
              id="trailerVideoUrl"
              type="url"
              placeholder="Trailer URL"
              {...getFieldProps('trailerVideoUrl')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="mainVideoUrl" component="div" className="text-red-600" />
            <Field
              id="mainVideoUrl"
              type="url"
              placeholder="Video URL"
              {...getFieldProps('mainVideoUrl')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="imdbRating" component="div" className="text-red-600" />
            <Field
              id="imdbRating"
              type="number"
              placeholder="IMDB Rating"
              {...getFieldProps('imdbRating')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
            <div className="relative">
              <Field
                as="select"
                id="categoryId"
                {...getFieldProps('categoryId')}
                className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              >
                <option disabled defaultValue="">
                  Select a category
                </option>

                {categories.map((category) => (
                  <option key={category.id} value={category.id}>
                    {category.name}
                  </option>
                ))}
              </Field>
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
              Add
            </button>
          </div>
          <ToastContainer />
        </Form>
      )}
    </Formik>
  );
}

export default MovieCreateForm;
