import React, {useEffect, useState} from 'react'
import { useNavigate } from 'react-router-dom';
import EventCard from '../event/EventCard';
import axios
 from 'axios';
const HomeEvent = () => {
    const navigate = useNavigate();
    const [event, setEvent] = useState("");

  const goToEvents = async () => {
    navigate('/event');
  }

  useEffect(() => {
    fetchRandomEvent();
}, []);

const fetchRandomEvent = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Event");
      const events = response.data.filter((e) => !e.isDeleted);
      const randomIndex = Math.floor(Math.random() * events.length);
      const randomEvent = events[randomIndex];
      setEvent(randomEvent);
    } catch (error) {
      console.error("Error fetching events:", error);
    }
  };

    return (
        <div>
            <section id="event-section" className='container mx-auto mt-20'>
                <div className='event-header'>
                    <h1 className="m-10 text-3xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl dark:text-white">
                        <button onClick={goToEvents} className="animate-bounce text-red-500 pointer">Check out</button> the latest events <br />and join Ghibli adventures</h1>
                </div>
                <div className='event-content m-20'>
                    <EventCard  key={event.id} event={event}/>
                </div>
            </section>
        </div>
    )
}

export default HomeEvent
