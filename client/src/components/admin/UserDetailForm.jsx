import axios from "axios";
import React, { useState, useEffect } from "react";

const UserDetailForm = ({ userId }) => {
  const [user, setUser] = useState("");

  useEffect(() => {
    fetchUserDetails();
  }, [userId]);

  const fetchUserDetails = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/User/${userId}`);
      setUser(response.data);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching user details:", error);
    }
  };

  function refreshPage() {
    window.location.reload(false);
  }

  const dataFields = [
    { label: "Id", property: "id" },
    { label: "User Name", property: "userName" },
    { label: "Full Name", property: "fullName" },
    { label: "Email", property: "email" },
    { label: "Phone Number", property: "phoneNumber" },
    { label: "Roles", property: "roles" },
    { label: "Birthday", property: "birthday" },
    { label: "Image Url", property: "imageUrl" },
    { label: "Country", property: "country" },
    { label: "City", property: "city" },
    { label: "Address", property: "address" },
    { label: "Zip Code", property: "zipCode" },
  ];


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
      {user && (
        <div>
          <div className="px-4 sm:px-0">
            <h3 className="text-base font-semibold leading-7 text-gray-900">User Details</h3>
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
                    {user[field.property]}
                  </dd>
                </div>
              ))}
            </dl>
          </div>
        </div>
      )}
    </div>

  )
}

export default UserDetailForm
