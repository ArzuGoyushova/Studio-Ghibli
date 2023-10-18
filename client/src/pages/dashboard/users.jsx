import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import UserDetailForm from "@/components/admin/UserDetailForm";
import SearchInput from "@/components/admin/SearchInput";

const mapRoleEnumToString = (roleEnum) => {
    switch (roleEnum) {
        case "Admin":
            return "Admin";
        case "SuperAdmin":
            return "Super Admin";
        case "SalesManager":
            return "Sales Manager";
        case "Member":
            return "Member";
        default:
            return "";
    }
};
const roleEnums = ["Admin", "SuperAdmin", "SalesManager", "Member"];

export function Users() {
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [users, setUsers] = useState([]);
    const [selectedUserId, setSelectedUserId] = useState(null);
    const [selectedRoles, setSelectedRoles] = useState({});
    const [userBlockedStatus, setUserBlockedStatus] = useState({});
    const [searchTerm, setSearchTerm] = useState("");


    const handleBlockUserClick = async (userId) => {
        try {
            const response = await axios.put(
                `https://arzugoyushova-001-site1.htempurl.com/api/User/block/${userId}`, {
                id: userId
            }
            );
            console.log(response);
            console.log("Block status is updated");

            setUserBlockedStatus((prevStatus) => ({
                ...prevStatus,
                [userId]: !prevStatus[userId]
            }));

            fetchUsers();
        } catch (error) {
            console.error(error);
        }
    };


    const handleDeleteUserClick = async (userId) => {
        try {
            const response = await axios.delete(
                `https://arzugoyushova-001-site1.htempurl.com/api/User/${userId}`
            );
            console.log(response);
            console.log("User is deleted successfully!");
            fetchUsers();
        } catch (error) {
            console.error(error);
        }
    };


    const handleRolesChange = (userId, selectedRoleValues) => {
        setSelectedRoles((prevSelectedRoles) => ({
            ...prevSelectedRoles,
            [userId]: selectedRoleValues,
        }));
    };


    const handleUpdateRolesClick = async (userId, selectedRoles) => {
        try {
            const response = await axios.put(
                `https://arzugoyushova-001-site1.htempurl.com/api/User/${userId}`,
                {
                    id: userId,
                    changeRolesDTO: {
                        roles: selectedRoles
                    }
                }
            );

            console.log(response);
            console.log("User roles are updated successfully!");

            fetchUsers();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDetailUserClick = (userId) => {
        setShowDetailForm(true);
        setSelectedUserId(userId);
    };

    useEffect(() => {
        fetchUsers();
    }, [searchTerm]);

    const fetchUsers = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/User");
            const allUsers = response.data.filter((e) => !e.isDeleted);

            const selectedRolesMap = {};
            allUsers.forEach((user) => {
                selectedRolesMap[user.id] = user.roles;
            });

            setSelectedRoles(selectedRolesMap);
            const filteredUsers = allUsers.filter((user) =>
                user.userName.toLowerCase().includes(searchTerm.toLowerCase())
            );

            setUsers(filteredUsers);
        } catch (error) {
            console.error("Error fetching Users:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showDetailForm ? (
                <div className="mt-4">
                    <UserDetailForm userId={selectedUserId} />
                </div>
            ) : (
                <Card>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3 flex justify-between">
                        <Typography variant="h6" color="white">
                            Users Table
                        </Typography>
                        <SearchInput placeholder="Search by username..." searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "Image", "Username", "Fullname", "Email", "Phone Number", "Role", ""].map((el) => (
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
                                {users.map(({ id, imageUrl, userName, fullName, email, phoneNumber, roles }, index) => {
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
                                                {imageUrl ? (
                                                    <img
                                                        src={`./images/users/${imageUrl}`}
                                                        alt={`${userName}`}
                                                        className="h-20 w-20 object-cover rounded"
                                                    />
                                                ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Image
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {userName}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {fullName}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {email}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {phoneNumber}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <select
                                                    multiple
                                                    value={selectedRoles[id] || []}
                                                    onChange={(e) =>
                                                        handleRolesChange(
                                                            id,
                                                            Array.from(e.target.selectedOptions, (option) => option.value)
                                                        )
                                                    }
                                                    className="block w-32 bg-white border border-gray-300 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500 sm:text-sm"
                                                >
                                                    {roleEnums.map((roleEnum) => (
                                                        <option
                                                            key={roleEnum}
                                                            value={roleEnum}
                                                            className={selectedRoles[id]?.includes(roleEnum) ? "selected-role" : ""}
                                                        >
                                                            {mapRoleEnumToString(roleEnum)}
                                                        </option>
                                                    ))}
                                                </select>

                                                <button
                                                    className="text-xs font-semibold text-green-600"
                                                    onClick={() => handleUpdateRolesClick(id, selectedRoles[id])}
                                                >
                                                    Update Roles
                                                </button>
                                            </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-orange-600 mr-2"
                                                    onClick={() => handleBlockUserClick(id)}
                                                >
                                                    {userBlockedStatus[id] ? (<span>Unblock</span>) : (<span>Block</span>)}
                                                </Typography>

                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-red-600 mr-2"
                                                    onClick={() => handleDeleteUserClick(id)}
                                                >
                                                    Delete
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600"
                                                    onClick={() => handleDetailUserClick(id)}
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

export default Users;
