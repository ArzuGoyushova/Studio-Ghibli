import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const BlogDetail = () => {
  const { blogId } = useParams();
  const [blog, setBlog] = useState("");
  const navigate = useNavigate();

  useEffect(() => {
    fetchBlog();
  }, []);

  const fetchBlog = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Blog/${blogId}`);
      const blog = response.data;
      setBlog(blog);
    } catch (error) {
      console.error("Error fetching blog:", error);
    }
  };

  if (!blog) {
    return <div>Loading...</div>;
  }

  return (
    <div className="container mx-auto p-4 my-5">
      <div className="bg-white rounded-lg shadow-md overflow-hidden">
        <img
          className="w-full h-full object-cover"
          src={`./images/blog/${blog.imageUrl}`}
          alt={blog.title}
        />
        <div className="p-4">
          <h2 className="text-3xl font-semibold mb-2">{blog.title}</h2>
          <div className="flex">
        <p className="text-red-800 mb-1 text-xs me-2">{`By ${blog.author}`}</p>
        <p className="text-red-800 mb-1 text-xs">{new Date(blog.createdTime).toLocaleString('en-US', {
                                day: '2-digit',
                                month: '2-digit',
                                year: 'numeric',
                                hour: '2-digit',
                                minute: '2-digit',
                                hour12: false
                            })} 
        </p>
        </div>
          <p className="text-gray-700 mb-4">{blog.blogContent}</p>
          <button
            onClick={() => navigate(-1)}
            className="bg-purple-500 hover:bg-purple-600 text-white py-2 px-4 rounded-lg"
          >
            Back to Blogs
          </button>
        </div>
      </div>
    </div>
  );
};

export default BlogDetail;
