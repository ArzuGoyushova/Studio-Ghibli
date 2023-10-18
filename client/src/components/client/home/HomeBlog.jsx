import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import ReadMore from '../blog/ReadMore';
import axios from 'axios';

const HomeBlog = () => {
  const [blogs, setBlogs] = useState([]);
  const navigate = useNavigate();

  const goToBlogs = async () => {
    navigate('/blog');
  }

  useEffect(() => {
    fetchBlogs();
  }, []);

  const fetchBlogs = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Blog");
      const filteredBlogs = response.data.filter((e) => !e.isDeleted).slice(0, 3);
      setBlogs(filteredBlogs);
    } catch (error) {
      console.error("Error fetching blogs:", error);
    }
  };


  return (
    <section id="blog-section" className="mt-8 mb-16 chat-background py-5">
      <div className="container mx-auto px-4">
        <div className='blog-header'>
          <h1 className="m-6 text-3xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
            <button onClick={goToBlogs} className="animate-bounce text-red-500 pointer">Read</button> latest news and blogs</h1>
        </div>

        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
          {blogs.map((blog) => (
            <div key={blog.id} className="bg-white shadow-lg rounded-lg p-6 flex flex-col justify-between">
              <div>
                <img src={`./images/blog/${blog.imageUrl}`} alt={blog.title} className="mb-4 rounded-md w-full h-48 object-cover" />
                <h3 className="text-xl font-semibold mb-2">{blog.title}</h3>
                <p className="text-gray-700 mb-5">
                  {blog.blogContent.length > 100
                    ? `${blog.blogContent.substr(0, 100)}...`
                    : blog.blogContent}
                </p>
              </div>
              <ReadMore blog={blog} />
            </div>
          ))}
        </div>
      </div>
    </section>
  );
};

export default HomeBlog;
