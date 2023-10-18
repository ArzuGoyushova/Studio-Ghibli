import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";


export function Subscriptions() {
    const [subscriptions, setSubscriptions] = useState([]);

    const handleDeleteSubscriptionClick = async (subscriptionId) => {
        try {
            const response = await axios.delete(
                `https://arzugoyushova-001-site1.htempurl.com/api/Subscription/${subscriptionId}`
            );
            console.log("Subscription deleted successfully!");
            fetchSubscriptions();
        } catch (error) {
            console.error(error);
        }
    };
    useEffect(() => {
        fetchSubscriptions();
    }, []);

    const fetchSubscriptions = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Subscription");
            setSubscriptions(response.data);
            console.log(response.data);
        } catch (error) {
            console.error("Error fetching subscriptions:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            <Card>
                <CardHeader variant="gradient" color="blue" className="mb-8 p-3">
                    <Typography variant="h6" color="white">
                        Subscriptions Table
                    </Typography>
                </CardHeader>
                <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                    <table className="w-full min-w-[800px] table-auto">
                        <thead>
                            <tr>
                                {["Id", "Email", ""].map((el) => (
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
                            {subscriptions.map(({ id, email }, index) => {
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
                                                {email}
                                            </Typography>
                                        </td>
                                        <td className={className}>
                                            <Typography
                                                as="a"
                                                className="text-xs cursor-pointer font-semibold text-red-600"
                                                onClick={() => handleDeleteSubscriptionClick(id)}
                                            >
                                                Delete
                                            </Typography>
                                        </td>
                                    </tr>
                                );
                            })}
                        </tbody>
                    </table>
                </CardBody>
            </Card>
        </div>
    );
}

export default Subscriptions;
