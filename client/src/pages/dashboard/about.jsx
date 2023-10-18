import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import AboutCreateForm from "@/components/admin/AboutCreateForm";
import AboutUpdateForm from "@/components/admin/AboutUpdateForm";

export function About() {
    const [showForm, setShowForm] = useState(false);
    const [showUpdateForm, setShowUpdateForm] = useState(false);
    const [about, setAbout] = useState([]);
    const [selectedAboutId, setSelectedAboutId] = useState(null);

    const handleAddAboutClick = () => {
        setShowForm(true);
        setShowUpdateForm(false);
        setSelectedAboutId(null);
    };

    const handleEditAboutClick = (movieId) => {
        setShowForm(true);
        setShowUpdateForm(true);
        setSelectedAboutId(movieId);
    };


    useEffect(() => {
        fetchAbout();
    }, [showForm]);

    const fetchAbout = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/About");
            const about = response.data;
            setAbout(about);
        } catch (error) {
            console.error("Error fetching about:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showForm ? (
                <div className="mt-4">
                    {showUpdateForm ? (
                        <AboutUpdateForm aboutId={selectedAboutId} />
                    ) : (
                        <AboutCreateForm />
                    )}
                </div>
            ) : (
                <Card>
                    <button
                        onClick={handleAddAboutClick}
                        className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
                    >
                        Add About Information
                    </button>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3">
                        <Typography variant="h6" color="white">
                            About Table
                        </Typography>
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "Origin Title", "Origin Desc", "Origin Image", "Ghibli Title", "Ghibli Desc", "Ghibli Image", "Message Title", "Message Desc", "Message Image", "Global Title", "Global Desc", "Global Image", "Height Title", "Height Desc", "Height Image", "Future Title", "Future Desc", "Future Image", ""].map((el) => (
                                        <th
                                            key={el}
                                            className="border-b border-blue-gray-50 py-3 px-5 text-left"
                                        >
                                            <Typography
                                                variant="small"
                                                className="text-[11px] font-bold uppercase text-blue-gray-400"
                                            >
                                                {el}
                                            </Typography>
                                        </th>
                                    ))}
                                </tr>
                            </thead>
                            <tbody>
                                {about.map(({ id, originTitle, originDesc, originImageUrl, ghibliTitle, ghibliDesc, ghibliImageUrl, messageTitle, messageDesc, messageImageUrl, globalTitle, globalDesc, globalImageUrl, heightTitle, heightDesc, heightImageUrl, futureTitle, futureDesc, futureImageUrl }, index) => {
                                    const uniqueKey = id || index;
                                    const className = `py-3 px-5 text-left border-b border-blue-gray-50`;
                                    return (
                                        <tr key={uniqueKey}>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {id}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {originTitle}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {originDesc}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                {originImageUrl ? (
                                                    <img
                                                        src={`./images/about/${originImageUrl}`}
                                                        alt={`${originTitle}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {ghibliTitle}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {ghibliDesc}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                {ghibliImageUrl ? (
                                                    <img
                                                        src={`./images/about/${ghibliImageUrl}`}
                                                        alt={`${ghibliTitle}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {messageTitle}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {messageDesc}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                {messageImageUrl ? (
                                                    <img
                                                        src={`./images/about/${messageImageUrl}`}
                                                        alt={`${messageTitle}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {globalTitle}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {globalDesc}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                {globalImageUrl ? (
                                                    <img
                                                        src={`./images/about/${globalImageUrl}`}
                                                        alt={`${globalTitle}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {heightTitle}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {heightDesc}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                {heightImageUrl ? (
                                                    <img
                                                        src={`./images/about/${heightImageUrl}`}
                                                        alt={`${heightTitle}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {futureTitle}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {futureDesc}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                {futureImageUrl ? (
                                                    <img
                                                        src={`./images/about/${futureImageUrl}`}
                                                        alt={`${futureTitle}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer  font-semibold text-blue-600 mr-2"
                                                    onClick={() => handleEditAboutClick(id)}
                                                >
                                                    Edit
                                                </Typography>
                                            </td>
                                        </tr>
                                    );
                                })}
                            </tbody>
                        </table>
                    </CardBody>
                </Card>
            )}
        </div>
    );
}

export default About;
