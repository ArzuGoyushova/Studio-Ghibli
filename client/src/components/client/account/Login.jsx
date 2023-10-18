import React, { useState } from 'react';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import { Link, useNavigate } from 'react-router-dom';
import { RiEyeLine, RiEyeOffLine } from 'react-icons/ri';
import { GoogleLogin } from '@react-oauth/google';
import jwtDecode from 'jwt-decode';

const Login = () => {
    const initialValues = {
        userNameOrEmail: '',
        password: '',
    };

    const navigate = useNavigate();
    const [userNameError, setError] = useState("");

    const validationSchema = Yup.object().shape({
        userNameOrEmail: Yup.string().required('Username or Email is required'),
        password: Yup.string().required('Password is required')
    });

    const [showPassword, setShowPassword] = useState(false);

    const togglePasswordVisibility = () => {
        setShowPassword(!showPassword);
    };

    const handleGoogleLogin = async (googleCredential) => {
        try {
            const response = await axios.post(
                'https://arzugoyushova-001-site1.htempurl.com/api/Account/google-login',
                null,
                {
                    params: {
                        googleCredential: googleCredential,
                    },
                }
            );
            console.log(response.data);
            const token = response.data.token;
            const decodedToken = jwtDecode(token);
            const decodedRole = decodedToken.role;
            const userRole = decodedRole;
            localStorage.setItem('authToken', token);

            toast.success("Successfully Signed In!", {
                position: "top-right",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                onClose: () => {
                    setTimeout(() => {
                        if (userRole==='Admin' || userRole==='SuperAdmin' || userRole === 'SalesManager') {
                            navigate('/dashboard/home');
                            window.location.reload();
                        } else {
                            navigate('/account/user-profile');
                            window.location.reload();
                        }
                    }, 2000);
                },

            });
        } catch (error) {
            if (error.response && error.response.data) {
                setError(error.response.data.message);
            }
            toast.error("Error trying to login. Please try again.", {
                position: "top-right",
                autoClose: 5000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
            });
        }
    };

    const handleSubmit = async (values) => {
        try {
            const response = await axios.post(
                'https://arzugoyushova-001-site1.htempurl.com/api/Account/Login',
                values
            );

            const token = response.data.token;
            const decodedToken = jwtDecode(token);
            const decodedRole = decodedToken.role;
            const userRole = decodedRole;
            localStorage.setItem('authToken', token);

            toast.success("Successfully Signed In!", {
                position: "top-right",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                  onClose: () => {
                    setTimeout(() => {
                        if (userRole==='Admin' || userRole==='SuperAdmin' || userRole === 'SalesManager') {
                            navigate('/dashboard/home');
                            window.location.reload();
                        } else {
                            navigate('/account/user-profile');
                            window.location.reload();
                        }
                    }, 2000);
                },

            });
        } catch (error) {
            if (error.response && error.response.data) {
                setError(error.response.data.message);
            }
            toast.error("Error trying to login. Please try again.", {
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
            <section id="loginSection" className="container mx-auto flex flex-col md:flex-row items-center rounded shadow-md mt-5">
                <div className="w-full md:w-1/2 h-3/4 max-w-md mx-auto p-6 bg-white rounded shadow-md">
                    <h2 className="text-2xl font-semibold mb-4 text-center">Login</h2>


                    <Formik
                        initialValues={initialValues}
                        validationSchema={validationSchema}
                        onSubmit={handleSubmit}
                    >
                        <Form>
                            <div className="mb-4">
                                <label htmlFor="userNameOrEmail" className="block text-gray-600 mb-1">
                                    Username
                                </label>
                                <Field
                                    type="text"
                                    id="userNameOrEmail"
                                    name="userNameOrEmail"
                                    className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                                />
                                <ErrorMessage
                                    name="userNameOrEmail"
                                    component="div"
                                    className="text-red-500"
                                />
                                {userNameError && <div className="text-red-500">{userNameError}</div>}

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
                            <button
                                type="submit"
                                className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 focus:outline-none"
                            >
                                Login
                            </button>


                            <ToastContainer />
                        </Form>
                    </Formik>
                    <div className="flex flex-col items-center">
                        <p className="my-4">Don't have an account? <Link className="text-red-600 font-semibold" to="/account/register">Create Here</Link></p>

                        <GoogleLogin
                            onSuccess={credentialResponse => {
                                handleGoogleLogin(credentialResponse.credential);
                            }}
                            onError={() => {
                                console.log('Google Login Failed');
                            }}
                            useOneTap
                        />
                        <p className="my-4">Forgot your password?  <Link className="text-red-600 font-semibold" to="/account/reset-password">Reset Here</Link></p>
                    </div>
                </div>

                <div className=' w-full md:w-1/2'>
                    <img src="./images/register.gif" alt="keyboard" className='rounded' />
                </div>
            </section>
        </div>
    );
};

export default Login;
