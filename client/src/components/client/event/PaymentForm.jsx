import React, { useState } from 'react';
import { useStripe, useElements, CardNumberElement, CardExpiryElement, CardCvcElement } from '@stripe/react-stripe-js';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const PaymentForm = () => {
  const stripe = useStripe();
  const elements = useElements();
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
  
    if (!stripe || !elements) {
      return;
    }
  
    const cardNumberElement = elements.getElement(CardNumberElement);
  
    setLoading(true);
  
    try {
      const paymentMethodResult = await stripe.createPaymentMethod({
        type: 'card',
        card: cardNumberElement,
      });
  
      if (paymentMethodResult.error) {
        console.error(paymentMethodResult.error.message);
        setLoading(false);
        return;
      }
  
      const ticketOrderId = localStorage.getItem('ticketOrderId');
  
      const verifyResponse = await axios.post(
        `https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder/verify-payment`,
        {
          ticketOrderId: ticketOrderId,
          paymentMethodId: paymentMethodResult.paymentMethod.id,
        }
      );
  
      console.log(verifyResponse);
  
      if (verifyResponse.data.clientSecret) {
        const paymentIntent = verifyResponse.data.paymentIntent;
  
        if (paymentIntent && paymentIntent.status === 'succeeded') {
          console.log('Payment already succeeded:', verifyResponse.data.message);
          localStorage.removeItem('ticketOrderId');
          navigate('/event/ticket-generation');
        } else {
          console.log('Payment verification succeeded:', verifyResponse.data.message);
          navigate('/event/ticket-generation');
        }
      } else {
        console.error('Missing client secret in the API response.');
      }
    } catch (error) {
      console.error('Error:', error.message);
    } finally {
      setLoading(false);
    }
  };
  
  
  
  return (
    <form className="max-w-sm mx-auto p-6 bg-white rounded shadow-md">
      <div className="mb-4">
        <label className="block text-gray-700">Card Number</label>
        <CardNumberElement className="mt-1 p-2 border rounded w-full" />
      </div>
      <div className="mb-4">
        <label className="block text-gray-700">Expiration Date</label>
        <CardExpiryElement className="mt-1 p-2 border rounded w-full" />
      </div>
      <div className="mb-4">
        <label className="block text-gray-700">CVC</label>
        <CardCvcElement className="mt-1 p-2 border rounded w-full" />
      </div>
      <input type="hidden" name="paymentMethodId" value="" />
      <button
        onClick={handleSubmit}
        className="px-4 py-2 bg-blue-500 text-white rounded-md hover:bg-blue-600 transition duration-300 ease-in-out"
        disabled={loading}
      >
        {loading ? 'Processing...' : 'Pay Now'}
      </button>
    </form>
  );
};

export default PaymentForm;
