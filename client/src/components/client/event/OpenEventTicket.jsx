import React from 'react';
import QRCode from 'qrcode.react';


const OpenEventTicket = ({ event, ticketCode }) => {
    
  return (
    <div className="container mx-auto flex">
     <div className="bg-white p-4 w-80 h-100 flex flex-col border border-blue-800 text-center my-4 space-y-5"> 
        <h3 className="text-3xl">{event.title}</h3> <br/>
        <p className="text-gray-600">
        Event time: {new Date(event.eventDate).toLocaleString('en-US', {
              year: 'numeric',
              month: '2-digit',
              day: '2-digit',
              hour: '2-digit',
              minute: '2-digit'
            })}
            </p>
      
      <p className="text-sm mt-2 text-gray-500">{event.address}</p>
      <p className="text-xl font-semibold text-red-800">${event.price.toFixed(2)}</p>
      <div className="mt-4 flex justify-center">
        <QRCode value={`Ticket Code: ${ticketCode}`} size={100} />
      </div>
    </div>
    </div>
  );
};


export default OpenEventTicket;
