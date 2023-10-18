import axios from "axios";
import React, { useState } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function ColorCreateForm() {
    const [colorName, setColorName] = useState("");

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
          const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Color", {
            colorDTO: {
              name: colorName,
            },
          });
            
          toast.success("Color created successfully!", {
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
          toast.error("Error creating color. Please try again.", {
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
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="colorName">
          Add a new color
        </label>
        <input
          id="colorName"
          type="text"
          placeholder="Color Name"
          value={colorName}
          onChange={(e) => setColorName(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <button

          type="submit"
          className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
        >
          Add
        </button>
      </div>
      <ToastContainer />
    </form>
  );
}

export default ColorCreateForm;


