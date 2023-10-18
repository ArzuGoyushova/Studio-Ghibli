import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function SizeUpdateForm({ sizeId }) {
  const [sizeName, setSizeName] = useState("");
  

  useEffect(() => {
    fetchSizeDetails();
  }, []);

  const fetchSizeDetails = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Size/${sizeId}`);
      setSizeName(response.data.name);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching size details:", error);
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.put(
        `https://arzugoyushova-001-site1.htempurl.com/api/Size/${sizeId}`,
        {
          "sizeId": `${sizeId}`,
          "sizeDTO": {
          "name": `${sizeName}`
            },
        }
      );

      toast.success("Size updated successfully!", {
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
      toast.error("Error creating size. Please try again.", {
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
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="sizeName">
          Update size
        </label>
        <input
          id="sizeName"
          type="text"
          placeholder="Size Name"
          value={sizeName}
          onChange={(e) => setSizeName(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <button
          type="submit"
          className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
        >
          Update
        </button>
      </div>
      <ToastContainer/>
    </form>
  );
}

export default SizeUpdateForm;
