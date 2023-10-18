import axios from "axios";
import React, { useState, useEffect } from "react";
import TicketDetailForm from "./TicketDetailForm";

const TicketOrderDetailForm = ({ticketOrderId}) => {
    const [ticketOrder, setTicketOrder] = useState("");
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [selectedTicketOrderId, setSelectedTicketOrderId] = useState("");
    useEffect(() => {
        fetchTicketOrderDetails();
    }, [ticketOrderId]);

    const fetchTicketOrderDetails = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder/admin/${ticketOrderId}`);
            setTicketOrder(response.data);
            console.log(response.data);
        } catch (error) {
            console.error("Error fetching ticket order details:", error);
        }
    };

    function refreshPage() {
        window.location.reload(false);
      }

      const dataFields = [
        { label: "Id", property: "id" },
        { label: "Order Number", property: "orderNumber" },
        { label: "User Id", property: "appUserId" },
        { label: "Order Date", property: "orderDate", format: "date" },
        { label: "Total Price", property: "totalPrice" },
        { label: "PaymentStatus", property: "paymentStatus", format: "enum" },
        { label: "Tickets", property: "tickets" },
    ];

    const formatDate = (dateString) => {
        const date = new Date(dateString);
        return `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()} ${date.getHours()}:${date.getMinutes()}`;
    };

    const formatPaymentStatus = (status) => {
        switch (status) {
            case 0: return "Pending";
            case 1: return "Completed";
            case 2: return "Failed";
            case 3: return "Refunded";
            default: return "";
        }
    };


  return (
    <div>
    <div className="flex justify-end">
 <button
   onClick={refreshPage}
   className="text-left bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
 >
   Go Back
 </button>
</div>
     {ticketOrder && (
         <div>
             <div className="px-4 sm:px-0">
                 <h3 className="text-base font-semibold leading-7 text-gray-900">Ticket Order Details</h3>
             </div>
             <div className="mt-6 border-t border-gray-100">
                        <dl className="divide-y divide-gray-500">
                            {dataFields.map((field) => (
                                <div
                                    key={field.label}
                                    className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0"
                                >
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        {field.label}:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {field.format === "date"
                                            ? formatDate(ticketOrder[field.property])
                                            : field.format === "enum"
                                            ? formatPaymentStatus(ticketOrder[field.property])
                                            : field.property === "tickets"
                                            ? ticketOrder[field.property].map((ticket) => (
                                                <div key={ticket.id}>
                                                <a
                                                    href="#"
                                                    onClick={(e) => {
                                                        e.preventDefault();
                                                        setShowDetailForm(true);
                                                        setSelectedTicketOrderId(ticket.id);
                                                    }}
                                                >
                                                    Ticket ID: {ticket.id}
                                                </a>
                                            </div>
                                              ))
                                            : ticketOrder[field.property]}
                                    </dd>
                                </div>
                            ))}
                        </dl>
                    </div>
         </div>
     )}
      {showDetailForm && <TicketDetailForm ticketId={selectedTicketOrderId} />}
 </div>
 
  )
}

export default TicketOrderDetailForm
