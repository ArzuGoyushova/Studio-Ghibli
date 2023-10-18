import axios from "axios";

export const totalUsers = async () => {
  try {
    const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/User");
    const users = response.data;
    const totalUsers = users.length;
    return totalUsers;
  } catch (error) {
    console.error("Error fetching users:", error);
    return "N/A";
  }
};
