import axios from "axios";
import React, { useState, useEffect } from "react";

function EventDetailForm({ eventId }) {
    const [event, setEvent] = useState(null);
    const [categoryId, setCategoryId] = useState(null);
    const [categories, setCategories] = useState(null);

    useEffect(() => {
        fetchEventDetails();
        fetchCategories();
    }, [eventId]);

    const fetchEventDetails = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Event/${eventId}`);
            setCategoryId(response.data.categoryId);
            setEvent(response.data);
        } catch (error) {
            console.error("Error fetching event details:", error);
        }
    };
    const fetchCategories = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
            setCategories(response.data);
        } catch (error) {
            console.error("Error fetching categories:", error);
        }
    };

    function refreshPage() {
        window.location.reload(false);
      }

    const getCategoryNameById = (categories, categoryId) => {
        const categoryKeys = Object.keys(categories ?? {});
    for (const key of categoryKeys) {
      if (categories[key].id === categoryId) {
        return categories[key].name;
      }
    }
    return 'Category Not Found';
      };

      const categoryName = getCategoryNameById(categories, categoryId);

      
    const dataFields = [
        { label: "Id", property: "id" },
        { label: "Title", property: "title" },
        { label: "Description", property: "description" },
        { label: "Event Type", property: "eventType" },
        { label: "Event Date", property: "eventDate" },
        { label: "Location", property: "location" },
        { label: "Address", property: "address" },
        { label: "MaxSeats", property: "maxSeats" },
        { label: "ReservedSeats", property: "reservedSeats" },
        { label: "Price", property: "price" },
    ];

    

    return (
        <div>
           <div className="flex justify-end">
        <button
          onClick={refreshPage}
          className="text-left bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
        >
          Go Back
        </button>
      </div>
            {event && (
                <div>
                    <div className="px-4 sm:px-0">
                        <h3 className="text-base font-semibold leading-7 text-gray-900">Event Details</h3>
                    </div>
                    <div className="mt-6 border-t border-gray-100">
                        <dl className="divide-y divide-gray-500">
                            {dataFields.map((field) => (
                                <div key={field.label} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        {field.label}:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {event[field.property]}
                                    </dd>
                                </div>
                            ))}
                            <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        Category:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {categoryName}
                                    </dd>
                                </div>


                            <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                    Image:
                                </dt>
                                <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                   {event.imageUrl? (
                                            <img
                                                key={event.imageUrl}
                                                src={`./images/event/${event.imageUrl}`}
                                                alt={`Event ${event.title}`}
                                                className="h-16 w-16 object-cover rounded"
                                            />
                                        
                                    ) : (
                                        <p className="text-xs font-semibold text-blue-gray-600">
                                            No Images
                                        </p>
                                    )}
                                </dd>
                            </div>
                        </dl>
                    </div>
                </div>
            )}
        </div>
        
    );
}

export default EventDetailForm;
