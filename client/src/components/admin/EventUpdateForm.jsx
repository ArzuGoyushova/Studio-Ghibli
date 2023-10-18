import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function EventUpdateForm({ eventId }) {
  const [eventData, setEventData] = useState("");
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const [eventDate, setEventDate] = useState("");
  const [location, setLocation] = useState("");
  const [address, setAddress] = useState("");
  const [eventType, setEventType] = useState("");
  const [maxSeats, setMaxSeats] = useState(null);
  const [price, setPrice] = useState("");
  const [categoryId, setCategoryId] = useState(null);
  const [reservedSeats, setReservedSeats] = useState("");
  const [selectedImage, setSelectedImage] = useState([]);
  const [existingPicture, setExistingPicture] = useState(null);
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    fetchCategories();
    fetchEventData();
  }, []);

  const fetchCategories = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
      setCategories(response.data);
    } catch (error) {
      console.error("Error fetching categories:", error);
    }
  };

  const fetchEventData = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Event/${eventId}`);
      const eventData = response.data;
      setEventData(eventData);
      setTitle(eventData.title);
      setDescription(eventData.description);
      setEventDate(eventData.eventDate);
      setLocation(eventData.location);
      setAddress(eventData.address);
      setEventType(eventData.eventType);
      setMaxSeats(eventData.maxSeats);
      setPrice(eventData.price);
      setReservedSeats(eventData.reservedSeats);
      setCategoryId(eventData.categoryId);
      setExistingPicture(eventData.imageUrl);
    } catch (error) {
      console.error("Error fetching event data:", error);
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const formData = new FormData();
      formData.append("EventId", eventId);
      formData.append("EventDTO.Title", title);
      formData.append("EventDTO.Description", description);
      formData.append("EventDTO.EventDate", eventDate);
      formData.append("EventDTO.Location", location);
      formData.append("EventDTO.Address", address);
      formData.append("EventDTO.EventType", eventType);
      formData.append("EventDTO.MaxSeats", maxSeats !== null ? maxSeats : "");
      formData.append("EventDTO.ReservedSeats", reservedSeats);
      formData.append("EventDTO.Price", price);
      formData.append("EventDTO.CategoryId", categoryId);
      formData.append("EventDTO.NewPicture", selectedImage);

      const response = await axios.put(`https://arzugoyushova-001-site1.htempurl.com/api/Event/${eventId}`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      toast.success("Event updated successfully!", {
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
      console.log(error)
      toast.error("Error updating Event. Please try again.", {
        position: "top-right",
        autoClose: 2000,
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
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="title">
          Add a new event
        </label>
        <input
          id="title"
          type="text"
          placeholder="Event Title"
          value={title}
          onChange={(e) => setTitle(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="eventDate"
          type="datetime-local"
          placeholder="Event Date YYYY-MM-DDTHH:mm"
          value={eventDate}
          onChange={(e) => setEventDate(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="eventType"
          type="text"
          placeholder="Event Type"
          value={eventType}
          onChange={(e) => setEventType(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="description"
          type="text"
          placeholder="Description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="location"
          type="text"
          placeholder="Location"
          value={location}
          onChange={(e) => setLocation(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="address"
          type="text"
          placeholder="Address"
          value={address}
          onChange={(e) => setAddress(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="price"
          type="number"
          placeholder="Price"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <input
          id="maxSeats"
          type="number"
          placeholder="Max Seats"
          value={maxSeats !== null ? maxSeats : ""}
          onChange={(e) => setMaxSeats(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
        <input
          id="reservedSeats"
          type="string"
          placeholder="Reserved Seats"
          value={reservedSeats}
          onChange={(e) => setReservedSeats(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
        <div className="relative">
          <select
            id="categoryId"
            value={categoryId}
            onChange={(e) => setCategoryId(e.target.value)}
            className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          >
            <option disabled defaultValue={categoryId}>
              Select a category
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
        <div>

          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="existingImage">
            Current Event Image
          </label>
          <div className="flex items-center gap-2 mb-2">
            <img
              src={`./images/event/${existingPicture}`}
              alt={`event`}
              className="h-16 w-16 object-cover rounded"
            />
          </div>

          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="selectedImage">
            Event Image
          </label>
          <input
            type="file"
            id="selectedImage"
            onChange={(e) => setSelectedImage(e.target.files[0])}
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

export default EventUpdateForm;
