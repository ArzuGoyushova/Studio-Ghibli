import React, {useState, useEffect} from 'react';
import QRCode from 'qrcode.react';
import SeatSelection from './SeatSelection';
import axios from 'axios';

const CinemaTicket = ({ event, ticketCode, selectedSeat, onSeatSelect, showSeatSelection }) => {

  const [reservedSeats, setReservedSeats] = useState([]);

  useEffect(() => {
    fetchReservedSeats();
  }, []);

  const fetchReservedSeats = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Ticket`);
      const tickets = response.data;
     
      const reservedSeatsData = [];

      tickets.forEach(ticket => {
        if (ticket.seatNumber !== null) {
          reservedSeatsData.push(ticket.seatNumber);
        }
      });
      console.log(reservedSeatsData);
      setReservedSeats(reservedSeatsData);
    } catch (error) {
      console.error("Error fetching reserved seats:", error);
    }
  };


  return (
    <div className="container mx-auto flex">
    <div>
    {showSeatSelection && (
        <SeatSelection event={event} selectedSeat={selectedSeat} onSeatSelect={onSeatSelect} reservedSeats={reservedSeats} />
      )}
    </div>
    <div className="bg-white p-4 w-80 h-100 flex flex-col border border-blue-800 text-center my-4 space-y-5">
      <div className="">
        <h3 className="text-3xl">{event.title}</h3> <br />
        <p className="text-gray-600">
          Event time:{' '}
          {new Date(event.eventDate).toLocaleString('en-US', {
            year: 'numeric',
            month: '2-digit',
            day: '2-digit',
            hour: '2-digit',
            minute: '2-digit',
          })}
        </p>
      </div>
      <p className="text-sm mt-2 text-gray-500">{event.address}</p>
      <p className="text-xl font-semibold text-red-800">${event.price.toFixed(2)}</p>
      {selectedSeat !== null && (
        <p className="text-xl font-semibold text-red-800">Seat Number: {selectedSeat}</p>
      )}
      <div className="mt-4 flex justify-center">
        <QRCode value={`Ticket Code: ${ticketCode}`} size={100} />
      </div>
    </div>
  </div>
);
};


export default CinemaTicket;
