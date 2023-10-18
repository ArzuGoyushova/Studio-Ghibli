import React, {useState} from 'react';
import BasketItem from '@/components/client/event/BasketItem';
import axios from 'axios';
import jwtDecode from 'jwt-decode';
import PaymentForm from '@/components/client/event/PaymentForm';

const Basket = () => {
  const [showPaymentForm, setShowPaymentForm] = useState(false);
  const basketItems = JSON.parse(localStorage.getItem('basketItems')) || [];
  const totalItems = basketItems.length;
  const totalPrice = basketItems.reduce((total, item) => total + item.event.price, 0);

  const handleDeleteItem = (ticketCode) => {
    const updatedBasketItems = basketItems.filter(item => item.ticketCode !== ticketCode);
    localStorage.setItem('basketItems', JSON.stringify(updatedBasketItems));
    window.location.reload();
  };


  const handleCheckOut = async () => {
    try {
      const authToken = localStorage.getItem('authToken');
      const appUserId = authToken ? jwtDecode(authToken).nameid : null;
      
      const ticketOrderDTO = {
        appUserId: appUserId,
        basketItems: basketItems.map(item => ({
          ticketId: item.event.id,
          eventId: item.event.id,
          appUserId: appUserId,
          ticketCode: item.ticketCode,
          seatNumber: item.seatNumber,
        })),
        totalPrice: totalPrice
      };
      
      const orderResponse = await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder", {
        ticketOrderDTO: ticketOrderDTO,
      });
      
      console.log("Order Response:", orderResponse);
      const ticketOrderId = orderResponse.data.ticketOrderId;
     
      setShowPaymentForm(true);
      localStorage.setItem('ticketOrderId', ticketOrderId);
    } catch (error) {
      console.error("Error creating tickets and order:", error);
    }
  };
  
  
  return (
    <div className="container mx-auto my-10 basket-background">
    {showPaymentForm ? (
      <PaymentForm />
    ) : (
      <div className="flex flex-col justify-between md:flex-row">
        {basketItems.length === 0 ? (
          <div className="w-full h-80 flex flex-col justify-center items-center md:flex-row">
            <h2 className="text-3xl">You have no items in the basket.</h2>
            <img src="./images/noFaceBasket.gif" className="w-80 h-80" alt="No Items in Basket" />
          </div>
        ) : (
          <>
            <div className="w-full md:w-2/3 p-4 border rounded-lg">
              <div className='flex justify-between'>
              <h2 className="text-3xl font-semibold mb-4">Basket Items</h2>
              <p className="text-lg text-white font-semibold mb-2 bg-red-800 rounded-lg w-36 p-2 text-center">Total Items: {totalItems}</p>
              </div>
              <div className='flex flex-col flex-wrap md:flex-row md:space-x-10'>
              {basketItems.map((item) => (
                 <BasketItem key={item.ticketCode} item={item} onDelete={handleDeleteItem} />
              ))}
            </div>
            </div>
            <div className="w-full md:w-1/3 p-4 border rounded-lg ">
              <h2 className="text-3xl font-semibold mb-4">Checkout</h2>
              <p className="text-lg text-white font-semibold mb-2 bg-red-800 rounded-lg w-56 p-2 text-center">Total Price: ${totalPrice.toFixed(2)}</p>

              <button
                onClick={handleCheckOut}
                className="px-4 py-2 w-56 bg-blue-500 font-semibold text-white rounded-md hover:bg-blue-600 transition duration-300 ease-in-out"
              >
                Proceed to Checkout
              </button>
            </div>
          </>
        )}
      </div>
    )}
  </div>
);
};

export default Basket;
