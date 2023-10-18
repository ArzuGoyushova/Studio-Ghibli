import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import axios from 'axios';
import OpenEventTicket from './OpenEventTicket';
import CinemaTicket from './CinemaTicket';
import { v4 as uuidv4 } from 'uuid';
import setAuthToken from '../account/setAuthToken';

const TicketConfirmation = () => {
  const {eventId} = useParams();
  const [event, setEvent] = useState(null);
  const [ticketCode, setTicketCode] = useState(null);
  const [selectedSeat, setSelectedSeat] = useState(null); 
  const navigate = useNavigate();


  const generateTicketCode = () => {
    const newTicketCode = uuidv4();
    setTicketCode(newTicketCode);
  };

  const handleSeatSelect = (seatNumber) => {
    setSelectedSeat(seatNumber);
  };
  useEffect(() => {
    fetchEventDetails();
    generateTicketCode(); 
  }, []);

  const fetchEventDetails = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Event/${eventId}`);
      const event = response.data;
      console.log(event);
      setEvent(event);
    } catch (error) {
      console.error("Error fetching event details:", error);
    }
  };

  const handleAddToBasket = () => {
    const authToken = localStorage.getItem('authToken'); 
    if (authToken) {
      setAuthToken(authToken); 
      const existingBasketItems = JSON.parse(localStorage.getItem('basketItems')) || [];
      
      const newBasketItem = {
        event: event,
        ticketCode: ticketCode,
        seatNumber: selectedSeat,
      };
      
      const updatedBasketItems = [...existingBasketItems, newBasketItem];
      localStorage.setItem('basketItems', JSON.stringify(updatedBasketItems));
      navigate('/basket');
    } else {
      navigate('/account/login'); 
    }
  };
  
  
  return (
    <div className='container mx-auto my-10 flex flex-col items-center'>
      {event ? (
        <div className="">
          {event.eventType === 0 ? (
            <OpenEventTicket event={event} ticketCode={ticketCode} />
          ) : (
            
            <CinemaTicket
            event={event}
            ticketCode={ticketCode}
            selectedSeat={selectedSeat} 
            onSeatSelect={handleSeatSelect}
            showSeatSelection={true} />
          )}
        </div>
      ) : (
        <div>Loading...</div>
      )}
      <button
        className="px-4 py-2 bg-blue-500 text-white rounded-md hover:bg-blue-600 transition duration-300 ease-in-out"
        onClick={handleAddToBasket}
      >
        Add to Basket
      </button>
    </div>
  );
  
};

export default TicketConfirmation;
