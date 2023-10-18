import React from 'react';
import TicketGeneration from './TicketGeneration';

const TicketGenerationPage = () => {
  return (
    <div className="text-center my-4 mx-2">
      <h2 className="text-3xl">Thanks for your purchase!</h2>
      <p>Your payment was successful and the ticket has been sent to your email. Enjoy!</p>
      <TicketGeneration existingBasketItems={JSON.parse(localStorage.getItem('basketItems'))} />
    </div>
  );
};

export default TicketGenerationPage;
