import React from 'react';
import { LuArmchair } from 'react-icons/lu';
import {GiTheaterCurtains} from 'react-icons/gi';

const SeatSelection = ({ event, selectedSeat, onSeatSelect, reservedSeats }) => {
  return (
    <div className="mt-4 w-64 ">
       <div><GiTheaterCurtains className='w-64 h-64'/></div>
      <div className="flex flex-wrap justify-center max-w-sm mx-auto">
       
        {Array.from({ length: event.maxSeats }, (_, index) => {
          const seatNumber = index + 1;
          const isReserved = reservedSeats.includes(seatNumber);

          return (
            <div
              key={index}
              className={`w-12 h-162border rounded-md flex flex-col items-center justify-center cursor-pointer ${
                selectedSeat === seatNumber ? 'bg-blue-500 text-white' : isReserved ? 'bg-gray-500' : 'bg-gray-200 text-gray-600'
              }`}
              onClick={() => !isReserved && onSeatSelect(seatNumber)}
            >
              <LuArmchair className='w-6 h-6'/>
              {seatNumber}
            </div>
          );
        })}
      </div>
    </div>
  );
};
export default SeatSelection;