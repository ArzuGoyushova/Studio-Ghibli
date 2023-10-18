import axios from "axios";
import React from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';

const validationSchema = Yup.object().shape({
  categoryName: Yup.string().required("Please fill in the field.").max(50, "Name can't be longer than 50 characters."),
  desc: Yup.string().required("Please fill in the field.").max(120, "Description can't be longer than 120 characters."),
});

function CategoryCreateForm() {
  const handleSubmit = async (values) => {
    try {
      const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Category", {
        categoryDTO: {
          name: values.categoryName,
          parentId: values.parentId !== "" ? values.parentId : null,
          desc: values.desc,
        },
      });

      toast.success("Category created successfully!", {
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
      toast.error("Error creating category. Please try again.", {
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
    <Formik
      initialValues={{
        categoryName: "",
        parentId: "",
        desc: "",
      }}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      {({ getFieldProps, touched, errors }) => (
        <Form>
          <div className="flex flex-col gap-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="categoryName">
              Add a new category
            </label>
            <ErrorMessage name="categoryName" component="div" className="text-red-600" />
            <Field
              id="categoryName"
              type="text"
              placeholder="Category Name"
              {...getFieldProps('categoryName')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.categoryName && errors.categoryName ? 'border-red-500' : ''}`}
              required
            />
            <ErrorMessage name="parentId" component="div" className="text-red-600" />
            <Field
              id="parentId"
              type="text"
              placeholder="Parent Category ID (Optional)"
              {...getFieldProps('parentId')}
              className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            />
            <ErrorMessage name="desc" component="div" className="text-red-600" />
            <Field
              id="desc"
              type="text"
              placeholder="Category Description"
              {...getFieldProps('desc')}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.desc && errors.desc ? 'border-red-500' : ''}`}
            />
            <button
              type="submit"
              className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
            >
              Add
            </button>
          </div>
          <ToastContainer />
        </Form>
      )}
    </Formik>
  );
}

export default CategoryCreateForm;