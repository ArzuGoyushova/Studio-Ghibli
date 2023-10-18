import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  Card,
  CardHeader,
  CardBody,
  Typography
} from "@material-tailwind/react";

import SizeCreateForm from "@/components/admin/SizeCreateForm";
import SizeUpdateForm from "@/components/admin/SizeUpdateForm";

export function Sizes() {
  const [showForm, setShowForm] = useState(false);
  const [showUpdateForm, setShowUpdateForm] = useState(false);
  const [sizes, setSizes] = useState([]);
  const [selectedSizeId, setSelectedSizeId] = useState(null); 

  const handleAddSizeClick = () => {
    setShowForm(true);
    setShowUpdateForm(false);
    setSelectedSizeId(null); 
  };

  const handleEditSizeClick = (sizeId) => {
    setShowForm(true);
    setShowUpdateForm(true);
    setSelectedSizeId(sizeId); 
  };
  const handleDeleteSizeClick = async (sizeId) => {
    try {
      const response = await axios.delete(
        `https://arzugoyushova-001-site1.htempurl.com/api/Size/${sizeId}`
      );
      console.log("Size deleted successfully!");
      fetchSizes(); 
    } catch (error) {
      console.error(error);
    }
  };
  useEffect(() => {
    fetchSizes();
  }, [showForm]);

  const fetchSizes = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Size");
      setSizes(response.data);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching sizes:", error);
    }
  };

  return (
    <div className="mt-8 mb-8 flex flex-col gap-12">
      {showForm ? (
        <div className="mt-4">
          {showUpdateForm ? (
            <SizeUpdateForm sizeId={selectedSizeId} />
          ) : (
            <SizeCreateForm />
          )}
        </div>
      ) : (
        <Card>
          <button
            onClick={handleAddSizeClick}
            className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
          >
            Add a size
          </button>
          <CardHeader variant="gradient" color="blue" className="mb-8 p-3">
            <Typography variant="h6" color="white">
              Sizes Table
            </Typography>
          </CardHeader>
          <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
            <table className="w-full min-w-[800px] table-auto">
              <thead>
                <tr>
                  {["Id", "Name", ""].map((el) => (
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
                {sizes.map(({ id, name }, index) => {
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
                          {name}
                        </Typography>
                      </td>
                      <td className={className}>
                        <Typography
                          as="a"
                          className="text-xs cursor-pointer font-semibold text-blue-gray-600"
                          onClick={() => handleEditSizeClick(id)}
                        >
                          Edit
                        </Typography>
                        <Typography
              as="a"
              className="text-xs cursor-pointer font-semibold text-red-600"
              onClick={() => handleDeleteSizeClick(id)}
            >
              Delete
            </Typography>
                        <Typography
                          as="a"
                          className="text-xs cursor-pointer font-semibold text-blue-gray-600"
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

export default Sizes;
