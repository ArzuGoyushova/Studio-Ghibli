import axios from "axios";

export const totalSales = async () => {
  try {
    const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/TicketOrder");
    const filteredTicketOrders = response.data;
    const totalSales = filteredTicketOrders.reduce((total, order) => total + order.totalPrice, 0);
    return totalSales.toFixed(2);
  } catch (error) {
    console.error("Error fetching ticket Orders:", error);
    return "N/A";
  }
};
