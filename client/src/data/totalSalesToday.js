import axios from "axios";

export const totalSalesToday = async () => {
  try {
    const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder");
    const allTicketOrders = response.data;

    const today = new Date();
    today.setHours(0, 0, 0, 0);

    const ticketOrdersToday = allTicketOrders.filter(order => new Date(order.timestamp) >= today);

    const totalSalesToday = ticketOrdersToday.reduce((total, order) => total + order.totalPrice, 0);
    return totalSalesToday.toFixed(2);
  } catch (error) {
    console.error("Error fetching ticket orders:", error);
    return "N/A";
  }
};
