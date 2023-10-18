import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import setAuthToken from "./setAuthToken";

function UserEditProfile() {
  const [userData, setUserData] = useState(null);
  const [userName, setUserName] = useState("");
  const [fullName, setFullName] = useState("");
  const [email, setEmail] = useState("");
  const [phoneNumber, setPhoneNumber] = useState("");
  const [birthday, setBirthday] = useState("");
  const [country, setCountry] = useState("");
  const [city, setCity] = useState("");
  const [address, setAddress] = useState("");
  const [zipCode, setZipCode] = useState("");
  const [selectedImage, setSelectedImage] = useState([]);
  const [existingPicture, setExistingPicture] = useState("");


  useEffect(() => {
    const token = localStorage.getItem('authToken');
    setAuthToken(token);
    fetchUserData();
  }, []);

  const fetchUserData = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/account/user-data`, {
        headers: {
          Authorization: `Bearer ${localStorage.getItem('authToken')}`
        }
      });
      const userData = response.data;
      setUserData(userData);
      setUserName(userData.userName);
      setFullName(userData.fullName);
      setPhoneNumber(userData.phoneNumber);
      setEmail(userData.email);

        if (userData.birthday) {
      const birthdayDate = new Date(userData.birthday);
      const formattedBirthday = `${birthdayDate.getFullYear()}-${(birthdayDate.getMonth() + 1).toString().padStart(2, '0')}-${birthdayDate.getDate().toString().padStart(2, '0')}`;
      setBirthday(formattedBirthday);
    }

      setCountry(userData.country);
      setCity(userData.city);
      setAddress(userData.address);
      setZipCode(userData.zipCode);
      setExistingPicture(userData.imageUrl || "avatar.jpg");
    } catch (error) {
      console.error("Error fetching user data:", error);
    }
  };


  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const formData = new FormData();
      formData.append("Id", userData.id);
      formData.append("ProfileDTO.Id", userData.id);
      formData.append("ProfileDTO.UserName", userName);
      formData.append("ProfileDTO.FullName", fullName);
      formData.append("ProfileDTO.Email", email);
      formData.append("ProfileDTO.PhoneNumber", phoneNumber);
      formData.append("ProfileDTO.Birthday", birthday);
      formData.append("ProfileDTO.Country", country);
      formData.append("ProfileDTO.City", city);
      formData.append("ProfileDTO.Address", address);
      formData.append("ProfileDTO.ZipCode", zipCode);
      formData.append("ProfileDTO.Image", selectedImage);

      const response = await axios.put(
        `https://arzugoyushova-001-site1.htempurl.com/api/Account/${userData.id}`,
        formData,
        {
          headers: {
            "Content-Type": "multipart/form-data",
            Authorization: `Bearer ${localStorage.getItem('authToken')}`
          },
        }
      );


      toast.success("Profile updated successfully!", {
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
      console.log(error);
      toast.error("Error updating profile. Please try again.", {
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
    await axios.delete(`https://arzugoyushova-001-site1.htempurl.com/api/Image/images/${imageType}/${imageUrl}`);
    
    if (imageType === "users") {
      setExistingPicture("avatar.jpg");
    } 
    
    toast.success("Image deleted successfully!");
  } catch (error) {
    toast.error("Failed to delete image. Please try again later.");
  }
};

 return (
  <div className="flex-grow p-8 w-1/2 md:w-full">
  <form onSubmit={handleSubmit}>
    <div className="flex flex-col gap-4">
      <input
        id="userName"
        type="text"
        placeholder="Username"
        value={userName}
        onChange={(e) => setUserName(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        required
      />
      <input
        id="fullName"
        type="text"
        placeholder="Full Name"
        value={fullName}
        onChange={(e) => setFullName(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        required
      />
      <input
        id="email"
        type="email"
        placeholder="Email"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        required
      />
      <input
        id="phoneNumber"
        type="tel"
        placeholder="Phone Number"
        value={phoneNumber}
        onChange={(e) => setPhoneNumber(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
      />
      <input
        id="birthday"
        type="date"
        placeholder="Birthday"
        value={birthday}
        onChange={(e) => setBirthday(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
      />
      <input
        id="country"
        type="text"
        placeholder="Country"
        value={country}
        onChange={(e) => setCountry(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
      />
        <input
        id="city"
        type="text"
        placeholder="City"
        value={city}
        onChange={(e) => setCity(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
      />
        <input
        id="address"
        type="text"
        placeholder="Address"
        value={address}
        onChange={(e) => setAddress(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
      />
        <input
        id="zipCode"
        type="text"
        placeholder="Zip Code"
        value={zipCode}
        onChange={(e) => setZipCode(e.target.value)}
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
      />
      <div>
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="existingPicture">
          Current Profile Picture
        </label>
        <img
           src={`./images/users/${existingPicture}`}
          alt="User Profile"
          className="h-16 w-16 object-cover rounded"
        />
        <button
          type="button"
          onClick={() => handleDeleteImage("users", 0, existingPicture)}
          className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 rounded"
        >
          Delete
        </button>
      </div>
      <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="image">
        Profile Picture
      </label>
      <input
        type="file"
        id="image"
        onChange={(e) => setSelectedImage(e.target.files[0])}
        className="py-2 px-3 border rounded"
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
  </div>
);
}

export default UserEditProfile;