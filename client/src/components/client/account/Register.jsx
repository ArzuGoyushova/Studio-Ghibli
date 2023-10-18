import React, { useState } from 'react';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

import { RiEyeLine, RiEyeOffLine } from 'react-icons/ri';

const Register = () => {
    const initialValues = {
        userName: '',
        fullName: '',
        email: '',
        phoneNumber: '',
        password: '',
        confirmPassword: '',
    };
    const [userNameError, setError] = useState("");
    const navigate = useNavigate();

    const validationSchema = Yup.object().shape({
        userName: Yup.string().required('Username is required'),
        fullName: Yup.string().required('Full Name is required'),
        email: Yup.string().email('Invalid email').required('Email is required'),
        phoneNumber: Yup.string().required('Phone Number is required'),
        password: Yup.string()
            .min(8, 'Password must be at least 8 characters')
            .required('Password is required'),
        confirmPassword: Yup.string()
            .oneOf([Yup.ref('password'), null], 'Passwords must match')
            .required('Confirm Password is required'),
    });

    const [showPassword, setShowPassword] = useState(false);

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    const handleSubmit = async (values) => {
        try {
            const response = await axios.post(
                'https://arzugoyushova-001-site1.htempurl.com/api/Account/Register',
                values
            );

            toast.success("Successfully Signed Up!", {
                position: "top-right",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                onClose: () => {
                    setTimeout(() => {
                        navigate('/account/verify-account', {
                            state: { email: values.email, phoneNumber: values.phoneNumber, userId: response.data.value }
                        });
                    }, 3000);
                },
                
            });
        } catch (error) {
            if (error.response && error.response.data) {
                setError(error.response.data.message);
            }
            toast.error("Error creating account. Please try again.", {
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
        <div>
            <section id="registerSection" className="container mx-auto flex flex-col md:flex-row items-center rounded shadow-md mt-5">
                <div className=' w-full md:w-1/2'>
                    <img src="./images/register.gif" alt="keyboard" className='rounded' />
                </div>
                <div className="w-full md:w-1/2 h-3/4 max-w-md mx-auto p-6 bg-white rounded shadow-md">
                    <h2 className="text-2xl font-semibold mb-4 text-center">Register</h2>


                    <Formik
                        initialValues={initialValues}
                        validationSchema={validationSchema}
                        onSubmit={handleSubmit}
                    >
                        <Form>
                            <div className="mb-4">
                                <label htmlFor="userName" className="block text-gray-600 mb-1">
                                    Username
                                </label>
                                <Field
                                    type="text"
                                    id="userName"
                                    name="userName"
                                    className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                                />
                                <ErrorMessage
                                    name="userName"
                                    component="div"
                                    className="text-red-500"
                                />
                                {userNameError && <div className="text-red-500">{userNameError}</div>}

                            </div>
                            <div className="mb-4">
                                <label htmlFor="fullName" className="block text-gray-600 mb-1">
                                    Full Name
                                </label>
                                <Field
                                    type="text"
                                    id="fullName"
                                    name="fullName"
                                    className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                                />
                                <ErrorMessage
                                    name="fullName"
                                    component="div"
                                    className="text-red-500"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="email" className="block text-gray-600 mb-1">
                                    Email
                                </label>
                                <Field
                                    type="email"
                                    id="email"
                                    name="email"
                                    className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                                />
                                <ErrorMessage
                                    name="email"
                                    component="div"
                                    className="text-red-500"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="phoneNumber" className="block text-gray-600 mb-1">
                                    Phone Number
                                </label>
                                <Field
                                    type="tel"
                                    id="phoneNumber"
                                    name="phoneNumber"
                                    className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                                />
                                <ErrorMessage
                                    name="phoneNumber"
                                    component="div"
                                    className="text-red-500"
                                />
                            </div>
                            <div className="mb-4 relative">
                                <label htmlFor="password" className="block text-gray-600 mb-1">
                                    Password
                                </label>
                                <Field
                                    type={showPassword ? "text" : "password"}
                                    id="password"
                                    name="password"
                                    className="relative w-full p-2 border rounded focus:outline-none focus:border-blue-400"

                                />
                                <button
                                    type="button"
                                    onClick={togglePasswordVisibility}
                                    className="text-black absolute top-10 right-3"
                                >
                                    {showPassword ? <RiEyeLine /> : <RiEyeOffLine />}
                                </button>
                                <ErrorMessage
                                    name="password"
                                    component="div"
                                    className="text-red-500"
                                />
                            </div>
                            <div className="mb-4">
                                <label htmlFor="confirmPassword" className="block text-gray-600 mb-1">
                                    Confirm Password
                                </label>
                                <Field
                                    type="password"
                                    id="confirmPassword"
                                    name="confirmPassword"
                                    className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                                />
                                <ErrorMessage
                                    name="confirmPassword"
                                    component="div"
                                    className="text-red-500"
                                />
                            </div>


                            <button
                                type="submit"
                                className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 focus:outline-none"
                            >
                                Register
                            </button>
                            <ToastContainer />
                        </Form>
                    </Formik>
                </div>
            </section>
        </div>
    );
};

export default Register;
