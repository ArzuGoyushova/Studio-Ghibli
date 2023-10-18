import axios from "axios";
import React, { useState, useEffect } from "react";

function CategoryDetailForm({ categoryId }) {
  const [category, setCategory] = useState(null);

  useEffect(() => {
    fetchCategoryDetails();
  }, [categoryId]);

  const fetchCategoryDetails = async () => {
    try {
      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Category/${categoryId}`);
      setCategory(response.data);
      console.log(response.data);
    } catch (error) {
      console.error("Error fetching category details:", error);
    }
  };
  
  const dataFields = [
    { label: "Id", property: "id" },
    { label: "Name", property: "name" },
    { label: "Parent Id", property: "parentId" },
    { label: "Description", property: "desc" },
  ];

  const renderListItems = (items, label) => {
    return (
      <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
        <dt className="text-sm font-medium leading-6 text-gray-900 text-left">{label}:</dt>
        <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
          {items && items.length > 0 ? (
            <ul>
              {items.map((item) => (
                <li key={item}>{item}</li>
              ))}
            </ul>
          ) : (
            "None"
          )}
        </dd>
      </div>
    );
  };

  return (
    <div>
      {category && (
        <div>
          <div className="px-4 sm:px-0">
            <h3 className="text-base font-semibold leading-7 text-gray-900">Category Details</h3>
          </div>
          <div className="mt-6 border-t border-gray-100">
            <dl className="divide-y divide-gray-500">
            {dataFields.map((field) => (
                <div key={field.label} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                  <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                    {field.label}:
                  </dt>
                  <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                    {category[field.property]}
                  </dd>
                </div>
              ))}
              {renderListItems(category.subCategoryNames, "Subcategories")}
              {renderListItems(category.productNames, "Products")}
              {renderListItems(category.movieTitles, "Movies")}
              {renderListItems(category.blogTitles, "Blogs")}
            </dl>
          </div>
        </div>
      )}
    </div>
  );
}

export default CategoryDetailForm;
