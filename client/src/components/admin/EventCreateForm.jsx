import axios from "axios";
import React, { useState, useEffect } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import sendSubscriptionMessages from "./sendSubscriptionMessage";

const validationSchema = Yup.object().shape({
  title: Yup.string().required("Please fill in the field.").max(50, "Title can't be longer than 50 characters."),
  description: Yup.string().required("Please fill in the field.").max(160, "Description can't be longer than 160 characters."),
  location: Yup.string().required("Please fill in the field."),
  address: Yup.string().required("Please fill in the field."),
  price: Yup.number().required("Please fill in the field."),
});

function EventCreateForm() {
  const [selectedImage, setSelectedImage] = useState([]);
  const [categories, setCategories] = useState([]);
  useEffect(() => {
    fetchCategories();
  }, []);

  const fetchCategories = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
      setCategories(response.data);
    } catch (error) {
      console.error("Error fetching categories:", error);
    }
  };


  const handleSubmit = async (values, { setErrors }) => {
    const { title, description, eventDate, location, address, eventType, maxSeats, reservedSeats, price, categoryId } = values;
    const eventTypeValue = eventType === "OpenEvent" ? 0 : 1;
    
    

    try {
      const formData = new FormData();
      formData.append("EventDTO.Title", title);
      formData.append("EventDTO.Description", description);
      formData.append("EventDTO.EventDate", eventDate);
      formData.append("EventDTO.Location", location);
      formData.append("EventDTO.Address", address);
      formData.append("EventDTO.EventType", eventTypeValue);
      formData.append("EventDTO.MaxSeats", maxSeats);
      formData.append("EventDTO.ReservedSeats", reservedSeats);
      formData.append("EventDTO.Price", price);
      formData.append("EventDTO.CategoryId", categoryId);
      formData.append("EventDTO.NewPicture", selectedImage);


      const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Event", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });

      toast.success("Event created successfully!", {
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
      await sendSubscriptionMessages(values);
    } catch (error) {
      if (error.response && error.response.data && error.response.data.errors) {
        const validationErrors = error.response.data.errors;
        setErrors(validationErrors);
      } else {
        toast.error("Error creating Event. Please try again.", {
          position: "top-right",
          autoClose: 2000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
        });
      }
    }
  }

  return (
    <Formik
      initialValues={{
        title: "",
        description: "",
        eventDate: "",
        location: "",
        address: "",
        eventType: "OpenEvent",
        maxSeats: "",
        price: "",
        categoryId: "",
        reservedSeats: "",
      }}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      {({ getFieldProps, touched, errors }) => (
        <Form>
          <div className="flex flex-col gap-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="title">
              Add a new event
            </label>
            <ErrorMessage name="title" component="div" className="text-red-600" />
            <Field
              id="title"
              type="text"
              placeholder="Event Title"
              {...getFieldProps('title')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.title && errors.title ? 'border-red-500' : ''}`}
              required
            />
            <ErrorMessage name="eventDate" component="div" className="text-red-600" />
            <Field
              id="eventDate"
              type="datetime-local"
              placeholder="Event Date YYYY-MM-DDTHH:mm"
              {...getFieldProps('eventDate')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              required
            />
            <ErrorMessage name="eventType" component="div" className="text-red-600" />
            <Field
              as="select"
              id="eventType"
              {...getFieldProps('eventType')}
              className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            >
              <option value="OpenEvent">Open Event</option>
              <option value="CinemaEvent">Cinema Event</option>
            </Field>

            <ErrorMessage name="description" component="div" className="text-red-600" />
            <Field
              id="description"
              type="text"
              placeholder="Description"
              {...getFieldProps('description')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.description && errors.description ? 'border-red-500' : ''}`}
            />

            <ErrorMessage name="location" component="div" className="text-red-600" />
            <Field
              id="location"
              type="text"
              placeholder="Location"
              {...getFieldProps('location')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.location && errors.location ? 'border-red-500' : ''}`}
            />

            <ErrorMessage name="address" component="div" className="text-red-600" />
            <Field
              id="address"
              type="text"
              placeholder="Address"
              {...getFieldProps('address')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.address && errors.address ? 'border-red-500' : ''}`}
            />

            <ErrorMessage name="price" component="div" className="text-red-600" />
            <Field
              id="price"
              type="number"
              placeholder="Price"
              {...getFieldProps('price')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.price && errors.price ? 'border-red-500' : ''}`}
              required
            />

            <Field
              id="maxSeats"
              type="number"
              placeholder="Max Seats"
              {...getFieldProps('maxSeats')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline`}
            />

            <Field
              id="reservedSeats"
              type="string"
              placeholder="Reserved Seats"
              {...getFieldProps('reservedSeats')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline`}
            />

            <div className="relative">
              <Field
                as="select"
                id="categoryId"
                {...getFieldProps('categoryId')}
                className="block appearance-none w-full bg-white border rounded py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              >
                <option disabled defaultValue="">
                  Select a category
                </option>

                {categories.map((category) => (
                  <option key={category.id} value={category.id}>
                    {category.name}
                  </option>
                ))}
              </Field>
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
              <div>
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="selectedImage">
                  Event Image
                </label>
                <input
                  type="file"
                  id="selectedImage"
                  name="selectedImage"
                  onChange={(e) => setSelectedImage(e.target.files[0])}
                  className="py-2 px-3 border rounded"
                />
              </div>

              <button
                type="submit"
                className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
              >
                Add
              </button>
            </div>
           
          </div>
          
          <ToastContainer />
        </Form>
      )}
       
    </Formik>
  );
}

export default EventCreateForm;
