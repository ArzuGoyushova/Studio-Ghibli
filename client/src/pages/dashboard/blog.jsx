import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import BlogCreateForm from "@/components/admin/BlogCreateForm";
import BlogUpdateForm from "@/components/admin/BlogUpdateForm";
import BlogDetailForm from "@/components/admin/BlogDetailForm";
import SearchInput from "@/components/admin/SearchInput";

export function Blog() {
    const [showForm, setShowForm] = useState(false);
    const [showUpdateForm, setShowUpdateForm] = useState(false);
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [blogs, setBlogs] = useState([]);
    const [selectedBlogId, setSelectedBlogId] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");

    const handleAddBlogClick = () => {
        setShowForm(true);
        setShowUpdateForm(false);
        setSelectedBlogId(null);
    };

    const handleEditBlogClick = (blogId) => {
        setShowForm(true);
        setShowUpdateForm(true);
        setSelectedBlogId(blogId);
    };

    const handleDeleteBlogClick = async (blogId) => {
        try {
            const response = await axios.delete(
                `https://arzugoyushova-001-site1.htempurl.com/api/Blog/${blogId}`
            );
            console.log(response);
            console.log("Blog is deleted successfully!");
            fetchBlogs();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDetailBlogClick = (blogId) => {
        setShowForm(false);
        setShowUpdateForm(false);
        setShowDetailForm(true);
        setSelectedBlogId(blogId);
    };

    useEffect(() => {
        fetchBlogs();
    }, [searchTerm]);

    const fetchBlogs = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Blog");
            const allBlogs = response.data.filter((e) => !e.isDeleted);

            const filteredBlogs = allBlogs.filter((blog) =>
                blog.title.toLowerCase().includes(searchTerm.toLowerCase()))
            setBlogs(filteredBlogs);

        } catch (error) {
            console.error("Error fetching Blogs:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showForm ? (
                <div className="mt-4">
















































































































                    
                    {showUpdateForm ? (
                        <BlogUpdateForm blogId={selectedBlogId} />
                    ) : (
                        <BlogCreateForm />
                    )}
                </div>
            ) : showDetailForm ? (
                <div className="mt-4">
                    <BlogDetailForm blogId={selectedBlogId} />
                </div>
            ) : (
                <Card>
                    <button
                        onClick={handleAddBlogClick}
                        className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
                    >
                        Add a Blog
                    </button>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3 flex justify-between">
                        <Typography variant="h6" color="white">
                            Blogs Table
                        </Typography>
                        <SearchInput placeholder="Search by title.." searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "Image", "Title", "Author", "CreatedTime", ""].map((el) => (
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
                                {blogs.map(({ id, imageUrl, title, author, createdTime }, index) => {
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
                                            {imageUrl ? (
                                                    <img
                                                        src={`./images/blog/${imageUrl}`}
                                                        alt={`${title}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
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
                                                    {author}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {createdTime}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600 mr-2"
                                                    onClick={() => handleEditBlogClick(id)}
                                                >
                                                    Edit
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-red-600 mr-2"
                                                    onClick={() => handleDeleteBlogClick(id)}
                                                >
                                                    Delete
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600"
                                                    onClick={() => handleDetailBlogClick(id)}
                                                >
                                                    Detail
                                                </Typography>
                                            </td>
                                        </tr>
                                    );
                                })}
                            </tbody>
                        </table>
                    </CardBody>
                </Card>
            )}
        </div>
    );
}

export default Blog;
