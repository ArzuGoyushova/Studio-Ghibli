import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function ProductUpdateForm({ productId }) {
  const [productData, setProductData] = useState(null);
  const [productName, setProductName] = useState("");
  const [oldPrice, setOldPrice] = useState(null);
  const [regularPrice, setRegularPrice] = useState("");
  const [count, setCount] = useState("");
  const [desc, setDesc] = useState("");
  const [brand, setBrand] = useState("");
  const [tax, setTax] = useState("");
  const [code, setCode] = useState("");
  const [availability, setAvailability] = useState("");

  const [categoryId, setCategoryId] = useState("");
  const [selectedColors, setSelectedColors] = useState([]);
  const [selectedSizes, setSelectedSizes] = useState([]);
  const [selectedImages, setSelectedImages] = useState([]);
  const [existingPictures, setExistingPictures] = useState([]);

  const [categories, setCategories] = useState([]);
  const [colors, setColors] = useState([]);
  const [sizes, setSizes] = useState([]);

  useEffect(() => {
    fetchProductData();
    fetchCategories();
    fetchColors();
    fetchSizes();
  }, []);

  const fetchProductData = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Product/${productId}`);
      const productData = response.data;
      setProductData(productData);
      setProductName(productData.name);
      setOldPrice(productData.oldPrice);
      setRegularPrice(productData.regularPrice);
      setCount(productData.count);
      setDesc(productData.desc);
      setBrand(productData.brand);
      setTax(productData.tax);
      setCode(productData.code);
      setAvailability(productData.availability);
      setCategoryId(productData.categoryId);
      setSelectedColors(productData.colorIds);
      setSelectedSizes(productData.sizeIds);
      setExistingPictures(productData.imageUrls);
    } catch (error) {
      console.error("Error fetching product data:", error);
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

  const fetchColors = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Color");
      setColors(response.data);
    } catch (error) {
      console.error("Error fetching colors:", error);
    }
  };

  const fetchSizes = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Size");
      setSizes(response.data);
    } catch (error) {
      console.error("Error fetching sizes:", error);
    }
  };
  
  function refreshPage() {
    window.location.reload(false);
  }
  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const formData = new FormData();
      formData.append("ProId", productId);
      formData.append("ProductDTO.Name", productName);
      formData.append("ProductDTO.OldPrice", oldPrice !== null ? oldPrice : "");
      formData.append("ProductDTO.RegularPrice", parseFloat(regularPrice));
      formData.append("ProductDTO.Count", parseInt(count));
      formData.append("ProductDTO.Desc", desc);
      formData.append("ProductDTO.Brand", brand);
      formData.append("ProductDTO.Tax", tax);
      formData.append("ProductDTO.Code", code);
      formData.append("ProductDTO.Availability", availability);

      formData.append("ProductDTO.CategoryId", categoryId);
      selectedColors.forEach((colorId) => formData.append("ProductDTO.ColorIds", colorId));
      selectedSizes.forEach((sizeId) => formData.append("ProductDTO.SizeIds", sizeId));
      selectedImages.forEach((image) => formData.append("ProductDTO.NewPictures", image));
      existingPictures.forEach((imageUrl) => formData.append("ProductDTO.ExistingPictures", imageUrl));

      const response = await axios.put(
        `https://arzugoyushova-001-site1.htempurl.com/api/Product/${productId}`,
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
          },
        }
      );


      toast.success("Product updated successfully!", {
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
      toast.error("Error updating product. Please try again.", {
        position: "top-right",
        autoClose: 2000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    }
  };
  

  const handleDeleteImage = async (imageType, index, imageUrl) => {
    try {
        await axios.delete(`https://arzugoyushova-001-site1.htempurl.com/api/Image/images/products/${imageUrl}`);
        
            const updatedImages = [...existingPictures];
            updatedImages.splice(index, 1);
            setExistingPictures(updatedImages);
       
        toast.success("Image deleted successfully!");
    } catch (error) {
        toast.error("Failed to delete image. Please try again later.");
    }
};


  return (
    <form onSubmit={handleSubmit}>
           <div className="flex justify-end">
        <button
          onClick={refreshPage}
          className="text-left bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
        >
          Go Back
        </button>
      </div>
      <div className="flex flex-col gap-4">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="productName">
          Update product
        </label>
        <input
          id="productName"
          type="text"
          placeholder="Product Name"
          value={productName}
          onChange={(e) => setProductName(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="oldPrice"
          type="number"
          placeholder="Old Price"
          value={oldPrice !== null ? oldPrice : ""}
          onChange={(e) => setOldPrice(e.target.value !== "" ? parseFloat(e.target.value) : null)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
        <input
          id="regularPrice"
          type="number"
          placeholder="Regular Price"
          value={regularPrice}
          onChange={(e) => setRegularPrice(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="count"
          type="number"
          placeholder="Count"
          value={count}
          onChange={(e) => setCount(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="desc"
          type="text"
          placeholder="Description"
          value={desc}
          onChange={(e) => setDesc(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="brand"
          type="text"
          placeholder="Brand"
          value={brand}
          onChange={(e) => setBrand(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="tax"
          type="number"
          placeholder="Tax"
          value={tax}
          onChange={(e) => setTax(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="code"
          type="text"
          placeholder="Code"
          value={code}
          onChange={(e) => setCode(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="availability"
          type="text"
          placeholder="Availability"
          value={availability}
          onChange={(e) => setAvailability(e.target.value)}
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
            <option value="">
              Select different category
            </option>
            {categories.map((category) => (
              <option key={category.id} value={category.id}>
                {category.name}
              </option>
            ))}
          </select>
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
        <div className="relative">
          <select
            multiple
            id="colorIds"
            value={selectedColors}
            onChange={(e) => setSelectedColors(Array.from(e.target.selectedOptions, (option) => option.value))}
            className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          >
            <option value="" disabled>
              Select colors (multiple)
            </option>
            {colors.map((color) => (
              <option key={color.id} value={color.id}>
                {color.name}
              </option>
            ))}
          </select>
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
        <div className="relative">
          <select
            multiple
            id="sizeIds"
            value={selectedSizes}
            onChange={(e) => setSelectedSizes(Array.from(e.target.selectedOptions, (option) => option.value))}
            className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          >
            <option value="" disabled>
              Select sizes (multiple)
            </option>
            {sizes.map((size) => (
              <option key={size.id} value={size.id}>
                {size.name}
              </option>
            ))}
          </select>
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
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="existingImages">
          Current Product Images
        </label>
        {existingPictures.map((imageUrl, index) => (
    <div key={index} className="flex items-center gap-2 mb-2">
        <img
            src={`./images/products/${imageUrl}`}
            alt={`Product Image ${index + 1}`}
            className="h-16 w-16 object-cover rounded"
        />
        <button
            type="button"
            onClick={() => handleDeleteImage("products", index, imageUrl)}
            className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 rounded"
        >
            Delete
        </button>
    </div>
))}
      <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="images">
            Product Images
          </label>
          <input
            type="file"
            id="images"
            multiple
            onChange={(e) => setSelectedImages(Array.from(e.target.files))}
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

export default ProductUpdateForm;