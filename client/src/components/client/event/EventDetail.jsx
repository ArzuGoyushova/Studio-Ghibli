import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';
import Loading from '../Loading';

const EventDetail = () => {

    const { eventId } = useParams();
    const [event, setEvent] = useState("");
    const navigate = useNavigate();

    useEffect(() => {
        fetchEvent();
    }, []);

    const fetchEvent = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Event/${eventId}`);
            const event = response.data;
            setEvent(event);
        } catch (error) {
            console.error("Error fetching event:", error);
        }
    };
    if (!event) {
        return <Loading/>;
    }

    const handleGetTicket = () => {
        navigate(`/event/confirm-ticket/${eventId}`);
      };


  return (
    <div className="container mx-auto p-4 my-5">
      <div className="bg-white shadow-lg rounded-lg overflow-hidden flex flex-col md:flex-row ">
        <img
          src={`./images/event/${event.imageUrl}`}
          alt={event.title}
          className="md:w-80 h-80 object-cover object-center"
        />
        <div className="p-5 ms-4">
          <h2 className="text-3xl font-semibold mb-2">{event.title}</h2>
          <p className="text-gray-600">{event.description}</p>
          <p className="text-s mt-2 text-neutral-500 dark:text-neutral-300">
            Event time: {new Date(event.eventDate).toLocaleString('en-US', {
              year: 'numeric',
              month: '2-digit',
              day: '2-digit',
              hour: '2-digit',
              minute: '2-digit'
            })}
          </p>
          <p className="text-s mt-2 text-neutral-500 dark:text-neutral-300">
            Location: {event.location}
          </p>
          <p className="text-s mt-2 text-neutral-500 dark:text-neutral-300">
            Address: {event.address}
          </p>
          {event.eventType === 1 && (
            <p className="text-s mt-2 text-neutral-500 dark:text-neutral-300">
              Max Seats: {event.maxSeats}
            </p>
          )}
          <p className="text-s mt-2 text-neutral-500 dark:text-neutral-300">
            Price: ${event.price.toFixed(2)}
          </p>
          <button 
          onClick={handleGetTicket}
          className="px-4 py-2 mt-4 bg-blue-500 text-white rounded-md hover:bg-blue-600 transition duration-300 ease-in-out">
            Get Ticket
          </button>
        </div>
      </div>
    </div>
  );
};

export default EventDetail;

