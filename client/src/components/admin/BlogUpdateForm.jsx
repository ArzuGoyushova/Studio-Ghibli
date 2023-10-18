import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function BlogUpdateForm({ blogId }) {
  const [blogData, setBlogData] = useState("");
  const [title, setTitle] = useState("");
  const [author, setAuthor] = useState("");
  const [createdTime, setCreatedTime] = useState("");
  const [blogContent, setBlogContent] = useState("");
  const [categoryId, setCategoryId] = useState(null);
  const [selectedImage, setSelectedImage] = useState([]);
  const [existingPicture, setExistingPicture] = useState(null);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    fetchCategories();
    fetchBlogData();
  }, []);

  const fetchCategories = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
      setCategories(response.data);
    } catch (error) {
      console.error("Error fetching categories:", error);
    }
  };

  const fetchBlogData = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Blog/${blogId}`);
      const BlogData = response.data;
      setBlogData(BlogData);
      setTitle(BlogData.title);
      setAuthor(BlogData.author);
      setCreatedTime(BlogData.createdTime);
      setBlogContent(BlogData.blogContent);
      setCategoryId(BlogData.categoryId);
      setExistingPicture(BlogData.imageUrl);
    } catch (error) {
      console.error("Error fetching blog data:", error);
    }
  };

  const handleSubmit = async (Blog) => {
    Blog.preventDefault();
    try {
      const formData = new FormData();
      formData.append("BlogId", blogId);
      formData.append("BlogDTO.Title", title);
      formData.append("BlogDTO.Author", author);
      formData.append("BlogDTO.CreatedTime", createdTime);
      formData.append("BlogDTO.BlogContent", blogContent);
      formData.append("BlogDTO.CategoryId", categoryId);
      formData.append("BlogDTO.NewImage", selectedImage);

      const response = await axios.put(`
https://arzugoyushova-001-site1.htempurl.com/api/Blog/${blogId}`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      toast.success("Blog updated successfully!", {
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
      console.log(error)
      toast.error("Error updating Blog. Please try again.", {
        position: "top-right",
        autoClose: 2000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div className="flex flex-col gap-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="title">
          Update Blog
        </label>
        <input
          id="title"
          type="text"
          placeholder="Blog Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="createdTime"
          type="datetime-local"
          placeholder="Created Time YYYY-MM-DDTHH:mm"
          value={createdTime}
          onChange={(e) => setCreatedTime(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="author"
          type="text"
          placeholder="Author"
          value={author}
          onChange={(e) => setAuthor(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="blogContent"
          type="text"
          placeholder="Blog Content"
          value={blogContent}
          onChange={(e) => setBlogContent(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <div className="relative">
          <select
            id="categoryId"
            value={categoryId}
            onChange={(e) => setCategoryId(e.target.value)}
            className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          >
            <option disabled defaultValue={categoryId}>
              Select a category
            </option>

            {categories.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </select>
          <div className="pointer-Blogs-none absolute inset-y-0 right-0 flex items-center px-2 text-gray-700">
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

          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="existingImage">
            Current Blog Image
          </label>
          <div className="flex items-center gap-2 mb-2">
            <img
              src={`./images/blog/${existingPicture}`}
              alt={`Blog`}
              className="h-16 w-16 object-cover rounded"
            />
          </div>

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
          Update
        </button>
      </div>
      <ToastContainer />
    </form>
  );
}

export default BlogUpdateForm;
