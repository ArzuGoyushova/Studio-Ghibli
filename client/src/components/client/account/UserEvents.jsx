import React, { useState, useEffect } from 'react';
import { Calendar, momentLocalizer } from 'react-big-calendar';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import moment from 'moment';
import jwtDecode from 'jwt-decode';
import axios from 'axios';

const localizer = momentLocalizer(moment);

const UserEvents = () => {
  const token = localStorage.getItem('authToken');
  const [userId, setUserId] = useState("");
  const [eventIds, setEventIds] = useState([]);
  const [events, setEvents] = useState([]);

  useEffect(() => {
    fetchUserData();
  }, []);

  useEffect(() => {
    fetchEventIds();
  }, [userId]);

  useEffect(() => {
    fetchEvents();
  }, [eventIds]);

  const fetchUserData = async () => {
    try {
      const decodedToken = jwtDecode(token);
      const decodedUserId = decodedToken.nameid;
      setUserId(decodedUserId);
      console.log('Decoded User ID:', decodedUserId);
    } catch (error) {
      console.error('Error decoding token:', error);
    }
  };

  const fetchEventIds = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Ticket`);
      const tickets = response.data;
      
      const filteredTickets = tickets.filter(ticket => ticket.appUserId === userId);
      const eventIds = filteredTickets.map(ticket => ticket.eventId);
      console.log(filteredTickets);
      console.log(eventIds);
      setEventIds(eventIds);
    } catch (error) {
      console.error("Error fetching event:", error);
    }
  };

  const fetchEvents = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Event`);
      const allEvents = response.data;

      const filteredEvents = allEvents.filter(event => eventIds.includes(event.id));
        console.log(filteredEvents);
      setEvents(filteredEvents);
    } catch (error) {
      console.error("Error fetching events:", error);
    }
  };

  const formattedEvents = events.map(event => ({
    title: event.title,
    start: new Date(event.eventDate),
    end: new Date(event.eventDate),
  }));

  return (
    <div className='container mx-auto'> 
      <h2 className='text-3xl my-2'>Your Events Calendar</h2>
      <Calendar 
        localizer={localizer} 
        events={formattedEvents} 
        startAccessor="start" 
        endAccessor="end"
        style={{ height: 500 }}
      />
    </div>
  );
};

export default UserEvents;
