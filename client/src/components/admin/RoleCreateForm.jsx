import React from "react";
import { Formik, Form, Field, ErrorMessage } from "formik";
import * as Yup from "yup";
import axios from "axios";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const validationSchema = Yup.object().shape({
  roleName: Yup.string().required("Please fill in the field."),
});

const RoleCreateForm = () => {
  const handleSubmit = async (values, { setErrors }) => {
    try {
      const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Role", {
        roleDTO: {
          name: values.roleName,
        },
      });

      toast.success("Role created successfully!", {
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
      if (error.response && error.response.data && error.response.data.errors) {
        const validationErrors = error.response.data.errors;
        setErrors(validationErrors);
      } else {
        toast.error("Error creating role. Please try again.", {
          position: "top-right",
          autoClose: 5000,
          hideProgressBar: false,
          closeOnClick: true,
          pauseOnHover: true,
          draggable: true,
        });
      }
    }
  };

  return (
    <Formik
      initialValues={{
        roleName: "",
      }}
      validationSchema={validationSchema}
      onSubmit={handleSubmit}
    >
      {({ getFieldProps, touched, errors }) => (
        <Form>
          <div className="flex flex-col gap-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="roleName">
              Add a new role
            </label>
            <ErrorMessage name="roleName" component="div" className="text-red-600" />
            <Field
              id="roleName"
              type="text"
              placeholder="Role Name"
              {...getFieldProps("roleName")}
              className={`shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${touched.roleName && errors.roleName ? "border-red-500" : ""}`}
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
        </Form>
      )}
    </Formik>
  );
};

export default RoleCreateForm;