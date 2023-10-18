import React, { useState, useEffect } from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import axios from 'axios';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const NewPassword = () => {
    const location = useLocation();
    const [token, setToken] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        const searchParams = new URLSearchParams(location.search);
        const tokenFromQueryString = searchParams.get('token');
        const emailFromQueryString = searchParams.get('email');
        setToken(tokenFromQueryString);
        setEmail(emailFromQueryString);
    }, [location.search]);

   
    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('https://arzugoyushova-001-site1.htempurl.com/api/Account/update-password', {
                token,
                email,
                password,
                confirmPassword
            });
            toast.success("Password is updated!", {
                position: "top-right",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
                onClose: () => {
                        navigate('/account/login');
                },
            });
        } catch (error) {
            console.log("Error", error);
            toast.error("Please try again.", {
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
            <section id="newPassword" className="container mx-auto flex items-center rounded shadow-md mt-5">
                <div className="w-1/2 h-3/4 max-w-md mx-auto p-6 bg-white rounded shadow-md">
                    <h2 className="text-2xl font-semibold mb-4 text-center">Reset Password</h2>

                    <form onSubmit={handleSubmit}>
                        <div className="mb-4">
                            <label htmlFor="password" className="block text-gray-600 mb-1">
                                New Password
                            </label>
                            <input
                                type="password"
                                id="password"
                                value={password}
                                name="password"
                                onChange={(e) => setPassword(e.target.value)}
                                className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                            />
                        </div>
                        <div className="mb-4">
                            <label htmlFor="confirmPassword" className="block text-gray-600 mb-1">
                                Confirm Password
                            </label>
                            <input
                                type="password"
                                id="confirmPassword"
                                value={confirmPassword}
                                name="confirmPassword"
                                onChange={(e) => setConfirmPassword(e.target.value)}
                                className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                            />
                        </div>
                        <button
                            type="submit"
                            className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 focus:outline-none"
                        >
                            Update Password
                        </button>
                        <ToastContainer />
                    </form>
                </div>
                <div className='w-1/2'>
                    <img src="./images/register.gif" alt="keyboard" className='rounded' />
                </div>
            </section>
        </div>
    );
}

export default NewPassword;
