import React, { useState, useEffect } from "react";
import axios from "axios";
import {
  Card,
  CardHeader,
  CardBody,
  Typography
} from "@material-tailwind/react";

import CategoryCreateForm from "@/components/admin/CategoryCreateForm";
import CategoryUpdateForm from "@/components/admin/CategoryUpdateForm";
import CategoryDetailForm from "@/components/admin/CategoryDetailForm";
import SearchInput from "@/components/admin/SearchInput";
import Pagination from "@/components/admin/Pagination";

export function Category() {
  const [showForm, setShowForm] = useState(false);
  const [showUpdateForm, setShowUpdateForm] = useState(false);
  const [showDetailForm, setShowDetailForm] = useState(false);
  const [categories, setCategories] = useState([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);
  const [searchTerm, setSearchTerm] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const [pageCount, setPageCount] = useState(null);
  const itemsPerPage = 10;

  const handleAddCategoryClick = () => {
    setShowForm(true);
    setShowUpdateForm(false);
    setSelectedCategoryId(null);
  };

  const handleEditCategoryClick = (categoryId) => {
    setShowForm(true);
    setShowUpdateForm(true);
    setSelectedCategoryId(categoryId);
  };
  const handleDeleteCategoryClick = async (categoryId) => {
    try {
      const response = await axios.delete(
        `https://arzugoyushova-001-site1.htempurl.com/api/Category/${categoryId}`
      );
      console.log("Category deleted successfully!");
      fetchCategories();
    } catch (error) {
      console.error(error);
    }
  };

  const handleDetailClick = (categoryId) => {
    setShowForm(false);
    setShowUpdateForm(false);
    setShowDetailForm(true);
    setSelectedCategoryId(categoryId);
  };

   const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  useEffect(() => {
    fetchCategories();
  }, [searchTerm, currentPage]);

  const fetchCategories = async () => {
    try {
      const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
      const allCategories = response.data;
  
      const filteredCategories = allCategories.filter((category) =>
        category.name.toLowerCase().includes(searchTerm.toLowerCase())
      );
  
      const startIndex = (currentPage - 1) * itemsPerPage;
      const endIndex = startIndex + itemsPerPage;
      const pageCount = Math.ceil(filteredCategories.length / 10);
      setPageCount(pageCount);
      setCategories(filteredCategories.slice(startIndex, endIndex));

    } catch (error) {
      console.error("Error fetching categories:", error);
    }
  };
  

  return (
    <div className="mt-8 mb-8 flex flex-col gap-12">
      {showForm ? (
        <div className="mt-4">
          {showUpdateForm ? (
            <CategoryUpdateForm categoryId={selectedCategoryId} />
          ) : (
            <CategoryCreateForm />
          )}
        </div>
      ) : showDetailForm ? (
        <div className="mt-4">
          <CategoryDetailForm categoryId={selectedCategoryId} />
        </div>
      ) : (
        <Card>
          <button
            onClick={handleAddCategoryClick}
            className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
          >
            Add a category
          </button>
          <CardHeader variant="gradient" color="blue" className="mb-8 p-3 flex justify-between">
            <Typography variant="h6" color="white">
              Categories Table
            </Typography>
            <SearchInput placeholder="Search by category name" searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
          </CardHeader>
          <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
            <table className="w-full min-w-[800px] table-auto">
              <thead>
                <tr>
                  {["Id", "Name", "ParentId", "Description", ""].map((el) => (
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
                {categories.map(({ id, name, parentId, desc }, index) => {
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
                        <Typography className="text-xs font-semibold text-blue-gray-600">
                          {parentId}
                        </Typography>
                      </td>
                      <td className={className}>
                        <Typography className="text-xs font-semibold text-blue-gray-600">
                          {desc}
                        </Typography>
                      </td>
                      <td className={className}>
                        <Typography
                          as="a"
                          className="text-xs cursor-pointer font-semibold text-blue-gray-600"
                          onClick={() => handleEditCategoryClick(id)}
                        >
                          Edit
                        </Typography>
                        <Typography
                          as="a"
                          className="text-xs cursor-pointer font-semibold text-red-600"
                          onClick={() => handleDeleteCategoryClick(id)}
                        >
                          Delete
                        </Typography>
                        <Typography
                          as="a"
                          className="text-xs cursor-pointer font-semibold text-blue-gray-600"
                          onClick={() => handleDetailClick(id)}
                        >
                          Detail
                        </Typography>
                      </td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
            <Pagination pageCount={pageCount} currentPage={currentPage} onPageChange={handlePageChange} />
          </CardBody>
        </Card>
      )}
    </div>
  );
}

export default Category;
