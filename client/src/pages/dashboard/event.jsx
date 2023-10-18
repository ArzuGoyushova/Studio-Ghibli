import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import EventCreateForm from "@/components/admin/EventCreateForm";
import EventUpdateForm from "@/components/admin/EventUpdateForm";
import EventDetailForm from "@/components/admin/EventDetailForm";
import SearchInput from "@/components/admin/SearchInput";

export function Event() {
    const [showForm, setShowForm] = useState(false);
    const [showUpdateForm, setShowUpdateForm] = useState(false);
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [events, setEvents] = useState([]);
    const [selectedEventId, setSelectedEventId] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");
    
    const handleAddEventClick = () => {
        setShowForm(true);
        setShowUpdateForm(false);
        setSelectedEventId(null);
    };

    const handleEditEventClick = (eventId) => {
        setShowForm(true);
        setShowUpdateForm(true);
        setSelectedEventId(eventId);
    };

    const handleDeleteEventClick = async (eventId) => {
        try {
            const response = await axios.delete(
                `https://arzugoyushova-001-site1.htempurl.com/api/Event/${eventId}`
            );
            console.log(response);
            console.log("Event is deleted successfully!");
            fetchEvents();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDetailEventClick = (eventId) => {
        setShowForm(false);
        setShowUpdateForm(false);
        setShowDetailForm(true);
        setSelectedEventId(eventId);
    };

    useEffect(() => {
        fetchEvents();
    }, [searchTerm]);

    const fetchEvents = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Event");
            const allEvents = response.data.filter((e) => !e.isDeleted);
            
            const filteredEvents = allEvents.filter((event) =>
                event.title.toLowerCase().includes(searchTerm.toLowerCase()))
            setEvents(filteredEvents);
        } catch (error) {
            console.error("Error fetching events:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showForm ? (
                <div className="mt-4">
                    {showUpdateForm ? (
                        <EventUpdateForm eventId={selectedEventId} />
                    ) : (
                        <EventCreateForm />
                    )}
                </div>
            ) : showDetailForm ? (
                <div className="mt-4">
                    <EventDetailForm eventId={selectedEventId} />
                </div>
            ) : (
                <Card>
                    <button
                        onClick={handleAddEventClick}
                        className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
                    >
                        Add an event
                    </button>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3 flex justify-between">
                        <Typography variant="h6" color="white">
                            Events Table
                        </Typography>
                        <SearchInput placeholder="Search by movie title.." searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "Image", "Title", "Address", "Location", "Price", ""].map((el) => (
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
                                {events.map(({ id, imageUrl, title, address, location, price }, index) => {
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
                                            {imageUrl ? (
                                                    <img
                                                        src={`./images/event/${imageUrl}`}
                                                        alt={`${title}`}
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
                                                    {title}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {address}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {location}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {price}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600 mr-2"
                                                    onClick={() => handleEditEventClick(id)}
                                                >
                                                    Edit
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-red-600 mr-2"
                                                    onClick={() => handleDeleteEventClick(id)}
                                                >
                                                    Delete
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600"
                                                    onClick={() => handleDetailEventClick(id)}
                                                >
                                                    Detail
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

export default Event;
