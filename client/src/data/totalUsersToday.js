import axios from "axios";

export const totalUsersToday = async () => {
  try {
    const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/User");
    const users = response.data;

    const twentyFourHoursAgo = new Date();
    twentyFourHoursAgo.setHours(twentyFourHoursAgo.getHours() - 24);

    const usersToday = users.filter(user => new Date(user.signupTimestamp) > twentyFourHoursAgo);

    const totalUsersToday = usersToday.length;
    return totalUsersToday;
  } catch (error) {
    console.error("Error fetching users:", error);
    return "N/A";
  }
};

