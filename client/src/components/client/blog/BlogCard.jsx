import React from 'react';
import ReadMore from './ReadMore';

const BlogCard = ({ blog }) => {
    return (
        <div className="container mb-10  rounded-lg shadow-md overflow-hidden transform hover:scale-105 transition-transform duration-300">
            <img
                className="w-full h-96 object-cover"
                src={`./images/blog/${blog.imageUrl}`}
                alt={blog.title}
            />
            <div className="p-4">
                <h2 className="text-2xl font-semibold mb-2">{blog.title}</h2>
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
                <p className="text-gray-700 mb-5">
                    {blog.blogContent.length > 300
                        ? `${blog.blogContent.substr(0, 300)}...`
                        : blog.blogContent}
                </p>
                <ReadMore blog={blog} />
            </div>
        </div>
    );
};

export default BlogCard;
