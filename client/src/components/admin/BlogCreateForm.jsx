import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

const validationSchema = Yup.object().shape({
  title: Yup.string().required("Please fill in the field.").max(50, "Title can't be longer than 50 characters."),
  author: Yup.string().required("Please fill in the field.").max(30, "Author name can't be longer than 30 characters."),
  blogContent: Yup.string().required("Please fill in the field."),
});
function BlogCreateForm() {
  const [title, setTitle] = useState("");
  const [author, setAuthor] = useState("");
  const [createdTime, setCreatedTime] = useState("");
  const [blogContent, setBlogContent] = useState("");
  const [categoryId, setCategoryId] = useState(null);
  const [selectedImage, setSelectedImage] = useState([]);
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
    const { title, author, blogContent, createdTime, categoryId } = values;
    try {
      const formData = new FormData();
      formData.append("BlogDTO.Title", title);
      formData.append("BlogDTO.Author", author);
      formData.append("BlogDTO.CreatedTime", createdTime);
      formData.append("BlogDTO.BlogContent", blogContent);
      formData.append("BlogDTO.CategoryId", categoryId);
      formData.append("BlogDTO.NewImage", selectedImage);


      const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Blog", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      toast.success("Blog created successfully!", {
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
        toast.error("Error creating Blog. Please try again.", {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
        });
      }
    };
  }

  return (
    <Formik
      initialValues={{
        title: "",
        author: "",
        createdTime: "",
        blogContent: "",
        categoryId: "",
      }}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      {({ getFieldProps, touched, errors }) => (
        <Form>
          <div className="flex flex-col gap-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="title">
              Add a new blog
            </label>
            <ErrorMessage name="title" component="div" className="text-red-600" />
            <Field
              id="title"
              type="text"
              placeholder="Blog Title"
              {...getFieldProps('title')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.title && errors.title ? 'border-red-500' : ''}`}
              required
            />
            <ErrorMessage name="createdTime" component="div" className="text-red-600" />
            <Field
              id="createdTime"
              type="datetime-local"
              placeholder="Blog Created Time YYYY-MM-DDTHH:mm"
              {...getFieldProps('createdTime')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="author" component="div" className="text-red-600" />
            <Field
              id="author"
              type="text"
              placeholder="Author"
              {...getFieldProps('author')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="blogContent" component="div" className="text-red-600" />
            <Field
              id="blogContent"
              type="text"
              placeholder="Blog Content"
              {...getFieldProps('blogContent')}
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
              <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="selectedImage">
                Blog Image
              </label>
              <input
                type="file"
                id="selectedImage"
                onChange={(e) => setSelectedImage(e.target.files[0])}
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

export default BlogCreateForm;
