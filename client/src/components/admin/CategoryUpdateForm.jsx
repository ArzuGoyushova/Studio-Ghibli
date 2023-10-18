import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function CategoryUpdateForm({ categoryId }) {
  const [categoryName, setCategoryName] = useState("");
  const [categoryParentId, setCategoryParentId] = useState(null); 
  const [categoryDesc, setCategoryDesc] = useState(""); 

  useEffect(() => {
    fetchCategoryDetails();
  }, []);

  const fetchCategoryDetails = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Category/${categoryId}`);
      setCategoryName(response.data.name);
      setCategoryParentId(response.data.parentId); 
      setCategoryDesc(response.data.desc);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching category details:", error);
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.put(
        `https://arzugoyushova-001-site1.htempurl.com/api/Category/${categoryId}`,
        {
          "categoryId": `${categoryId}`,
          "categoryDTO": {
            "id": `${categoryId}`,
            "name": `${categoryName}`,
            "parentId": categoryParentId, // Use the updated parent category ID
            "desc": `${categoryDesc}`,
          },
        }
      );

      toast.success("Category updated successfully!", {
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
      toast.error("Error updating category. Please try again.", {
        position: "top-right",
        autoClose: 5000,
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
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="categoryName">
          Update category
        </label>
        <input
          id="categoryName"
          type="text"
          placeholder="Category Name"
          value={categoryName}
          onChange={(e) => setCategoryName(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        {/* Input field for parent category ID */}
        <input
          id="categoryParentId"
          type="text"
          placeholder="Parent Category ID (Optional)"
          value={categoryParentId !== null ? categoryParentId : ""}
          onChange={(e) =>
            e.target.value !== "" ? setCategoryParentId(e.target.value) : setCategoryParentId(null)
          }
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
        {/* Input field for category description */}
        <input
          id="categoryDesc"
          type="text"
          placeholder="Category Description"
          value={categoryDesc}
          onChange={(e) => setCategoryDesc(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
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

export default CategoryUpdateForm;
