import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import TicketOrderDetailForm from "@/components/admin/TicketOrderDetailForm";
import SearchInput from "@/components/admin/SearchInput";

export function TicketOrder() {
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [ticketOrders, setTicketOrders] = useState([]);
    const [selectedTicketOrderId, setSelectedTicketOrderId] = useState(null);
    const [searchTerm, setSearchTerm] = useState("");

    const [paymentStatusOptions, setPaymentStatusOptions] = useState([
        { value: 0, label: "Pending" },
        { value: 1, label: "Completed" },
        { value: 2, label: "Failed" },
        { value: 3, label: "Refunded" },
    ]);

    const handleEditTicketOrderClick = (ticketOrderId) => {
        setSelectedTicketOrderId(ticketOrderId);
    };

    const handleDeleteTicketOrderClick = async (ticketOrderId) => {
        try {
            const response = await axios.delete(
                `https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder/${ticketOrderId}`
            );
            console.log(response);
            console.log("TicketOrder is deleted successfully!");
            fetchTicketOrders();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDetailTicketOrderClick = (ticketOrderId) => {
        setShowDetailForm(true);
        setSelectedTicketOrderId(ticketOrderId);
    };
    const handlePaymentStatusChange = async (event, ticketOrderId) => {
        const newPaymentStatus = parseInt(event.target.value);
        try {
            await axios.put(`https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder/${ticketOrderId}`, 
            {
                ticketOrderId: ticketOrderId,
                paymentStatusDTO: {
                  id: ticketOrderId,
                  paymentStatus: newPaymentStatus
                }
              }
            );
            console.log("Payment status updated successfully!");
            fetchTicketOrders();
        } catch (error) {
            console.error("Error updating payment status:", error);
        }
    };
    useEffect(() => {
        fetchTicketOrders();
    }, [searchTerm]);

    const fetchTicketOrders = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder");
            const allTicketOrders = response.data;

            const filteredTicketOrders = allTicketOrders.filter((order) =>
                order.orderNumber.toLowerCase().includes(searchTerm.toLowerCase()))

            setTicketOrders(filteredTicketOrders);

        } catch (error) {
            console.error("Error fetching ticketOrders:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showDetailForm ? (
                <div className="mt-4">
                    <TicketOrderDetailForm ticketOrderId={selectedTicketOrderId} />
                </div>
            ) : (
                <Card>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3 flex justify-between">
                        <Typography variant="h6" color="white">
                            Ticket Orders Table
                        </Typography>
                        <SearchInput placeholder="Search by Order Number" searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "OrderNumber", "UserId", "OrderDate", "TotalPrice", "PaymentStatus", ""].map((el) => (
                                        <th
                                            key={el}
                                            className="border-b border-blue-gray-50 py-3 px-5 text-left"
                                        >
                                            <Typography
                                                variant="small"
                                                className="text-[11px] font-bold uppercase text-blue-gray-400"
                                            >
                                                {el}
                                            </Typography>
                                        </th>
                                    ))}
                                </tr>
                            </thead>
                            <tbody>
                                {ticketOrders.map(({ id, orderNumber, appUserId, orderDate, totalPrice, paymentStatus }, index) => {
                                    const uniqueKey = id || index;
                                    const className = `py-3 px-5 text-left border-b border-blue-gray-50`;
                                    return (
                                        <tr key={uniqueKey}>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {id}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {orderNumber}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {appUserId}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {new Date(orderDate).toLocaleString('en-GB', {
                                                        day: '2-digit',
                                                        month: '2-digit',
                                                        year: 'numeric',
                                                        hour: '2-digit',
                                                        minute: '2-digit'
                                                    })}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {totalPrice}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                        <select
                            value={paymentStatus}
                            onChange={(e) => handlePaymentStatusChange(e, id)}
                            className="text-xs font-semibold text-blue-gray-600"
                        >
                            {paymentStatusOptions.map((option) => (
                                <option key={option.value} value={option.value}>
                                    {option.label}
                                </option>
                            ))}
                        </select>
                    </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600 mr-2"
                                                    onClick={() => handleEditTicketOrderClick(id)}
                                                >
                                                    Edit
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-red-600 mr-2"
                                                    onClick={() => handleDeleteTicketOrderClick(id)}
                                                >
                                                    Delete
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600"
                                                    onClick={() => handleDetailTicketOrderClick(id)}
                                                >
                                                    Detail
                                                </Typography>
                                            </td>
                                        </tr>
                                    );
                                })}
                            </tbody>
                        </table>
                    </CardBody>
                </Card>
            )}
        </div>
    );
}

export default TicketOrder;
