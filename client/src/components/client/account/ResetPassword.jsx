import React, { useState } from 'react';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const ResetPassword = () => {
    const [email, setEmail] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post(
                'https://arzugoyushova-001-site1.htempurl.com/api/Account/reset-password',
                null,
    { params: { email: email } } 
            );
            toast.success("Please go to your email!", {
                position: "top-right",
                autoClose: 3000,
                hideProgressBar: false,
                closeOnClick: true,
                pauseOnHover: true,
                draggable: true,
            });
        } catch (error) {
            if (error.response && error.response.data) {
                console.log(error);
            }
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
            <section id="resetPassword" className="container mx-auto flex items-center rounded shadow-md mt-5">
                <div className="w-1/2 h-3/4 max-w-md mx-auto p-6 bg-white rounded shadow-md">
                    <h2 className="text-2xl font-semibold mb-4 text-center">Reset Password</h2>

                    <form onSubmit={handleSubmit}>
                        <div className="mb-4">
                            <label htmlFor="email" className="block text-gray-600 mb-1">
                                Email Address
                            </label>
                            <input
                                type="text"
                                id="email"
                                name="email"
                                value={email}
                                onChange={(e) => setEmail(e.target.value)}
                                className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
                            />
                        </div>
                        <button
                            type="submit"
                            className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 focus:outline-none"
                        >
                            Reset Password
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

export default ResetPassword;
