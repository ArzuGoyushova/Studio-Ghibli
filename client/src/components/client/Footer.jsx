import { FaFacebookF, FaInstagram, FaLine, FaTwitter } from 'react-icons/fa';
import axios from "axios";
import React, { useState } from "react";
import { toast, ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const Footer = () => {
const [userEmail, setUserEmail] = useState("");

const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Subscription", {
        subscriptionDTO: {
          email: userEmail,
        },
      });
        
      toast.success("Subscribed successfully!", {
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
      toast.error("Error while subscribing. Please try again.", {
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
            <footer className="chat-background text-white">
                <div className="container mx-auto flex flex-col md:flex-row md:space-x-20 justify-between px-4 py-20">
                    <div className="w-full flex flex-col items-center space-y-4 md:w-1/3  mb-5 md:mb-0">
                        <h2 className="text-2xl font-semibold mb-3 md:text-3xl text-center">
                            Do you have any questions or feedbacks? 
                            Contact Us!
                        </h2>
                        <a href="mailto:studioghibli@gmail.com" class="my-2 text-lg text-linkColor">Email: <b>studioghibli@gmail.com</b></a>
                        <h2 className='my-2 text-2xl text-mainBlueColor md:text-3xl'>Our Social Media Accounts:</h2>
                        <div className="flex space-x-4 mt-4">
                            
                            <a href="https://www.facebook.com/GhibliUSA/" className="text-linkColor hover:text-blue-800">
                                <FaFacebookF />
                            </a>
                            <a href="https://www.instagram.com/ghibli.movies/" className="text-linkColor hover:text-blue-800">
                                <FaInstagram />
                            </a>
                            <a href="https://store.line.me/stickershop/author/95792/en" className="text-linkColor hover:text-blue-800">
                                <FaLine />
                            </a>
                            <a href="https://twitter.com/ghibliusa?lang=en" className="text-linkColor hover:text-blue-800">
                                <FaTwitter />
                            </a>
                        </div>
                        <div>
                        <form onSubmit={handleSubmit}>
      <div className="flex ">
        <input
          id="userEmail"
          type="email"
          placeholder="Add your email address"
          value={userEmail}
          onChange={(e) => setUserEmail(e.target.value)}
          className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
          required
        />
        <button

          type="submit"
          className="flex-shrink-0 bg-mainBlueColor hover:bg-teal-700 border-mainBlueColor hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
        >
         Subscribe
        </button>
      </div>
      <ToastContainer />
    </form>
                        </div>
                    </div>
                    <div className="w-full flex my-5 justify-around md:justify-end md:w-1/3 md:my-0 md:space-x-20">
                        <div className='website-navigation'>
                        <h2 className=" w-1/2 text-xl font-semibold mb-2">Website Navigation</h2>
                        <ul className="space-y-2 text-black">
                            <li><a className="text-linkColor underlineHover" href="/movies">Movies</a></li>
                            <li><a className="text-linkColor underlineHover" href="/chat">Chat</a></li>
                            <li><a className="text-linkColor underlineHover" href="/event">Event</a></li>
                            <li><a className="text-linkColor underlineHover" href="/blog">Blog</a></li>
                            <li><a className="text-linkColor underlineHover" href="/games">Games</a></li>
                        </ul>
                        </div>
                        <div className='resources'>
                        <h2 className="text-lg font-semibold mb-2">Resources</h2>
                        <ul className="space-y-2 text-black">
                            <li><a className="text-linkColor underlineHover" href="/about">About</a></li>
                            <li><a className="text-linkColor underlineHover" href="/privacy-policy">Privacy Policy</a></li>
                            <li><a className="text-linkColor underlineHover" href="/legacies">Legacies</a></li>
                        </ul>
                        </div>
                    </div>
                    <div className="w-full h-auto md:w-1/3">
                        <img src="./images/nofaceKnit.png" alt="" />
                    </div>
                </div>
                <div className="mt-8 py-3 text-center bg-mainBlueColor">
                    <p className="text-white">
                        &copy; {new Date().getFullYear()} Studio Ghibli. All rights reserved.
                    </p>
                </div>
            </footer>

        </div>
    )
}

export default Footer
