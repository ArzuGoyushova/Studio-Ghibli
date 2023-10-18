import React, { useState, useEffect } from 'react'
import axios from 'axios';

const About = () => {
    const [about, setAbout] = useState("");

    useEffect(() => {
        fetchAbout();
    }, []);

    const fetchAbout = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/About");
            const about = response.data[0];
            console.log(about);
            setAbout(about);
        } catch (error) {
            console.error("Error fetching about:", error);
        }
    };


    return (
        <div className="container mx-auto">
            <div className='about-header'>
                <h1 className="m-10 text-3xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                    About Studio Ghibli
                </h1>

            </div>
            <div className='about-origin flex flex-col md:flex-row mb-10 mx-10'>
                <div className='w-full md:w-1/2 relative '>
                    <svg viewBox="0 0 240 240" xmlns="http://www.w3.org/2000/svg" className="hidden md:block">
                        <path fill="#247b99" d="M40.4,-53.5C51.6,-47.4,59.6,-34.7,65.1,-20.5C70.7,-6.3,73.9,9.4,67.7,20C61.5,30.6,45.9,36.1,33,44.8C20.2,53.5,10.1,65.3,-4.4,71.3C-18.9,77.4,-37.8,77.7,-51.3,69.2C-64.8,60.7,-72.9,43.5,-75.7,26.6C-78.4,9.6,-75.8,-7.1,-71.8,-24.5C-67.7,-41.9,-62.2,-59.9,-50,-65.7C-37.8,-71.5,-18.9,-65,-2.2,-62.1C14.6,-59.1,29.1,-59.6,40.4,-53.5Z" transform="translate(100 100)" />
                    </svg>
                    <img src={`./images/about/${about.originImageUrl}`} alt="Origin Image" className="md:absolute w-80 h-80 top-40 left-32 " />
                </div>
                <div className='w-full md:w-1/2 '>
                    <h1 className="m-10 text-2xl text-center text-linkColor leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        {about.originTitle}
                    </h1>
                    <p>{about.originDesc}</p>
                </div>
            </div>
            <div className='about-ghibli flex flex-col md:flex-row mb-10 relative mx-10'>
                <div className='w-full md:w-1/2 '>
                    <h1 className="m-10 text-2xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        {about.ghibliTitle}
                    </h1>
                    <p>{about.ghibliDesc}</p>
                </div>
                <div className='w-full md:w-1/2 relative '>
                    <svg viewBox="0 0 240 240" xmlns="http://www.w3.org/2000/svg" className='ms-20 hidden md:block'>
                        <path fill="#980c28" d="M40.4,-53.5C51.6,-47.4,79.6,-34.7,65.1,-20.5C70.7,-6.3,73.9,9.4,75.7,20C61.5,30.6,45.9,36.1,33,44.8C20.2,53.5,10.1,65.3,-4.4,71.3C-18.9,77.4,-37.8,77.7,-51.3,69.2C-64.8,60.7,-72.9,43.5,-75.7,26.6C-78.4,9.6,-75.8,-7.1,-71.8,-24.5C-67.7,-41.9,-62.2,-59.9,-50,-65.7C-37.8,-71.5,-18.9,-65,-2.2,-62.1C14.6,-59.1,29.1,-59.6,40.4,-53.5Z" transform="translate(100 100)" />
                    </svg>
                    <img src={`./images/about/${about.ghibliImageUrl}`} alt="Origin Image" className="md:absolute w-88 h-48 top-40 right-32 mt-16 md:mt-0" />
                </div>
            </div>
            <div className='about-global flex flex-col md:flex-row mb-10 mx-10'>
                <div className='w-full md:w-1/2 relative '>
                    <svg viewBox="0 0 240 240" xmlns="http://www.w3.org/2000/svg" className="hidden md:block">
                        <path fill="#247b99" d="M40.4,-53.5C51.6,-47.4,59.6,-34.7,65.1,-20.5C70.7,-6.3,73.9,9.4,67.7,20C61.5,30.6,45.9,36.1,33,44.8C20.2,53.5,10.1,65.3,-4.4,71.3C-18.9,77.4,-37.8,77.7,-51.3,69.2C-64.8,60.7,-72.9,43.5,-75.7,26.6C-78.4,9.6,-75.8,-7.1,-71.8,-24.5C-67.7,-41.9,-62.2,-59.9,-50,-65.7C-37.8,-71.5,-18.9,-65,-2.2,-62.1C14.6,-59.1,29.1,-59.6,40.4,-53.5Z" transform="translate(100 100)" />
                    </svg>
                    <img src={`./images/about/${about.globalImageUrl}`} alt="Origin Image" className="md:absolute w-88 h-48 top-40 left-32 " />
                </div>
                <div className='w-full md:w-1/2'>
                    <h1 className="m-10 text-2xl text-center text-linkColor leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        {about.globalTitle}
                    </h1>
                    <p>{about.globalDesc}</p>
                </div>
            </div>
            <div className='about-message flex flex-col md:flex-row mb-10 relative mx-10'>
                <div className='w-full md:w-1/2 '>
                    <h1 className="m-10 text-2xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        {about.messageTitle}
                    </h1>
                    <p>{about.messageDesc}</p>
                </div>
                <div className='w-full md:w-1/2'>
                    <svg viewBox="0 0 240 240" xmlns="http://www.w3.org/2000/svg" className='ms-20 hidden md:block'>
                        <path fill="#980c28" d="M40.4,-53.5C51.6,-47.4,79.6,-34.7,65.1,-20.5C70.7,-6.3,73.9,9.4,75.7,20C61.5,30.6,45.9,36.1,33,44.8C20.2,53.5,10.1,65.3,-4.4,71.3C-18.9,77.4,-37.8,77.7,-51.3,69.2C-64.8,60.7,-72.9,43.5,-75.7,26.6C-78.4,9.6,-75.8,-7.1,-71.8,-24.5C-67.7,-41.9,-62.2,-59.9,-50,-65.7C-37.8,-71.5,-18.9,-65,-2.2,-62.1C14.6,-59.1,29.1,-59.6,40.4,-53.5Z" transform="translate(100 100)" />
                    </svg>
                    <img src={`./images/about/${about.messageImageUrl}`} alt="Message Image" className="md:absolute w-88 h-48 top-40 right-32 mt-10 md:mt-0" />
                </div>
            </div>
            <div className='about-height flex flex-col md:flex-row mb-10 mx-10'>
                <div className='w-full md:w-1/2 relative '>
                    <svg viewBox="0 0 240 240" xmlns="http://www.w3.org/2000/svg" className='ms-20 hidden md:block'>
                        <path fill="#247b99" d="M40.4,-53.5C51.6,-47.4,59.6,-34.7,65.1,-20.5C70.7,-6.3,73.9,9.4,67.7,20C61.5,30.6,45.9,36.1,33,44.8C20.2,53.5,10.1,65.3,-4.4,71.3C-18.9,77.4,-37.8,77.7,-51.3,69.2C-64.8,60.7,-72.9,43.5,-75.7,26.6C-78.4,9.6,-75.8,-7.1,-71.8,-24.5C-67.7,-41.9,-62.2,-59.9,-50,-65.7C-37.8,-71.5,-18.9,-65,-2.2,-62.1C14.6,-59.1,29.1,-59.6,40.4,-53.5Z" transform="translate(100 100)" />
                    </svg>
                    <img src={`./images/about/${about.heightImageUrl}`} alt="Height Image" className="md:absolute w-88 h-48 top-40 left-32 " />
                </div>
                <div className='w-full md:w-1/2'>
                    <h1 className="m-10 text-2xl text-center text-linkColor leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        {about.heightTitle}
                    </h1>
                    <p>{about.heightDesc}</p>
                </div>
            </div>
            <div className='about-future flex flex-col md:flex-row mb-10 relative mx-10'>
                <div className='w-full md:w-1/2'>
                    <h1 className="m-10 text-2xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        {about.futureTitle}
                    </h1>
                    <p>{about.futureDesc}</p>
                </div>
                <div className='w-full md:w-1/2'>
                    <svg viewBox="0 0 240 240" xmlns="http://www.w3.org/2000/svg" className='ms-20 hidden md:block'>
                        <path fill="#980c28" d="M40.4,-53.5C51.6,-47.4,79.6,-34.7,65.1,-20.5C70.7,-6.3,73.9,9.4,75.7,20C61.5,30.6,45.9,36.1,33,44.8C20.2,53.5,10.1,65.3,-4.4,71.3C-18.9,77.4,-37.8,77.7,-51.3,69.2C-64.8,60.7,-72.9,43.5,-75.7,26.6C-78.4,9.6,-75.8,-7.1,-71.8,-24.5C-67.7,-41.9,-62.2,-59.9,-50,-65.7C-37.8,-71.5,-18.9,-65,-2.2,-62.1C14.6,-59.1,29.1,-59.6,40.4,-53.5Z" transform="translate(100 100)" />
                    </svg>
                    <img src={`./images/about/${about.futureImageUrl}`} alt="Origin Image" className="md:absolute w-88 h-48 top-40 right-32 mt-10 md:mt-0" />
                </div>
            </div>
        </div>
    )
}

export default About
