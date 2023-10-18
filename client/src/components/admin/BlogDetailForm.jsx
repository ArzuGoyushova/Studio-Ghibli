import axios from "axios";
import React, { useState, useEffect } from "react";

function BlogDetailForm({ blogId }) {
    const [blog, setBlog] = useState(null);
    const [categoryId, setCategoryId] = useState(null);
    const [categories, setCategories] = useState(null);

    useEffect(() => {
        fetchBlogDetails();
        fetchCategories();
    }, [blogId]);

    const fetchBlogDetails = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Blog/${blogId}`);
            setCategoryId(response.data.categoryId);
            setBlog(response.data);
        } catch (error) {
            console.error("Error fetching Blog details:", error);
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
        { label: "Author", property: "author" },
        { label: "Blog Content", property: "blogContent" },
        { label: "Created Time", property: "createdTime" }
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
            {blog && (
                <div>
                    <div className="px-4 sm:px-0">
                        <h3 className="text-base font-semibold leading-7 text-gray-900">Blog Details</h3>
                    </div>
                    <div className="mt-6 border-t border-gray-100">
                        <dl className="divide-y divide-gray-500">
                            {dataFields.map((field) => (
                                <div key={field.label} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        {field.label}:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {blog[field.property]}
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


                            <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                    Image:
                                </dt>
                                <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                   {blog.imageUrl? (
                                            <img
                                                key={blog.imageUrl}
                                                src={`./images/blog/${blog.imageUrl}`}
                                                alt={`Blog ${blog.title}`}
                                                className="h-16 w-16 object-cover rounded"
                                            />
                                        
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

export default BlogDetailForm;
