import React from 'react';
import OpenEventTicket from './OpenEventTicket';
import CinemaTicket from './CinemaTicket';
import { TrashIcon
 } from '@heroicons/react/24/solid';
const BasketItem = ({ item, onDelete }) => {
  const handleDelete = () => {
    onDelete(item.ticketCode);
  };
  
  return (
    <div className="basket-item relative">
      {item.event.eventType === 0 ? ( 
        <OpenEventTicket event={item.event} ticketCode={item.ticketCode} />
      ) : (
        <CinemaTicket
          event={item.event}
          ticketCode={item.ticketCode}
          selectedSeat={item.seatNumber}
          showSeatSelection={false} 
        />
      )}
      <button
        onClick={handleDelete}
      >
         <TrashIcon className="w-12 h-12 text-red-900 absolute bottom-6 right-0" />
      </button>
    </div>
  );
};

export default BasketItem;
