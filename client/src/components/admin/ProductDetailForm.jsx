import axios from "axios";
import React, { useState, useEffect } from "react";

function ProductDetailForm({ productId }) {
    const [product, setProduct] = useState(null);
    const [categoryId, setCategoryId] = useState(null);
    const [colorIds, setColorIds] = useState(null);
    const [sizeIds, setSizeIds] = useState(null);
    const [colors, setColors] = useState(null);
    const [sizes, setSizes] = useState(null);
    const [categories, setCategories] = useState(null);

    useEffect(() => {
        fetchProductDetails();
        fetchCategories();
        fetchColors();
        fetchSizes();
    }, [productId]);

    const fetchProductDetails = async () => {
        try {
            const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/Product/${productId}`);
            setCategoryId(response.data.categoryId);
            setColorIds(response.data.colorIds);
            setSizeIds(response.data.sizeIds);
            setProduct(response.data);
        } catch (error) {
            console.error("Error fetching product details:", error);
        }
    };
    const fetchCategories = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Category");
            setCategories(response.data);
        } catch (error) {
            console.error("Error fetching categories:", error);
        }
    };

    const fetchColors = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Color");
            setColors(response.data);
        } catch (error) {
            console.error("Error fetching colors:", error);
        }
    };

    const fetchSizes = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Size");
            setSizes(response.data);
        } catch (error) {
            console.error("Error fetching sizes:", error);
        }
    };

    function refreshPage() {
        window.location.reload(false);
      }

    const getCategoryNameById = (categories, categoryId) => {
        const categoryKeys = Object.keys(categories ?? {});
    for (const key of categoryKeys) {
      if (categories[key].id === categoryId) {
        return categories[key].name;
      }
    }
    return 'Category Not Found';
      };

      const categoryName = getCategoryNameById(categories, categoryId);

      const getColorNamesByIds = (colors, colorIds) => {
        if (!colorIds) return [];

        const colorNames = colorIds.map((colorId) => {
          const foundColor = colors.find((color) => color.id === colorId);
          return foundColor ? foundColor.name : 'Color Not Found';
        });
        return colorNames;
      };
    
      const getSizeNamesByIds = (sizes, sizeIds) => {
        if (!sizeIds) return []; 
        const sizeNames = sizeIds.map((sizeId) => {
          const foundSize = sizes.find((size) => size.id === sizeId);
          return foundSize ? foundSize.name : 'Size Not Found';
        });
        return sizeNames;
      };
    
      const colorsList = colors || [];
      const sizesList = sizes || [];
      const colorNames = getColorNamesByIds(colorsList, colorIds);
      const sizeNames = getSizeNamesByIds(sizesList, sizeIds);



    const dataFields = [
        { label: "Id", property: "id" },
        { label: "Name", property: "name" },
        { label: "Old Price", property: "oldPrice" },
        { label: "Regular Price", property: "regularPrice" },
        { label: "Discount", property: "discount" },
        { label: "Count", property: "count" },
        { label: "Availability", property: "availability" },
        { label: "Code", property: "code" },
        { label: "Brand", property: "brand" },
        { label: "Tax", property: "tax" },
        { label: "Description", property: "desc" },
    ];

    const renderListItems = (items, label) => {
        return (
            <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                <dt className="text-sm font-medium leading-6 text-gray-900 text-left">{label}:</dt>
                <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                    {items && items.length > 0 ? (
                        <ul>
                            {items.map((item, index) => (
                                <li key={index}>{item}</li>
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
           <div className="flex justify-end">
        <button
          onClick={refreshPage}
          className="text-left bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
        >
          Go Back
        </button>
      </div>
            {product && (
                <div>
                    <div className="px-4 sm:px-0">
                        <h3 className="text-base font-semibold leading-7 text-gray-900">Product Details</h3>
                    </div>
                    <div className="mt-6 border-t border-gray-100">
                        <dl className="divide-y divide-gray-500">
                            {dataFields.map((field) => (
                                <div key={field.label} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        {field.label}:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {product[field.property]}
                                    </dd>
                                </div>
                            ))}
                            <div className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                    <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                        Category:
                                    </dt>
                                    <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                        {categoryName}
                                    </dd>
                                </div>

                            {renderListItems(colorNames, "Colors")}
                            {renderListItems(sizeNames, "Sizes")}


                            <div key={product.imageUrls} className="px-4 py-6 sm:grid sm:grid-cols-3 sm:gap-4 sm:px-0">
                                <dt className="text-sm font-medium leading-6 text-gray-900 text-left">
                                    Pictures:
                                </dt>
                                <dd className="mt-1 text-sm leading-6 text-gray-700 sm:col-span-2 sm:mt-0 text-left">
                                    {product.imageUrls && product.imageUrls.length > 0 ? (
                                        product.imageUrls.map((imageUrl, idx) => (

                                            <img
                                                key={idx}
                                                src={`./images/products/${imageUrl}`}
                                                alt={`Product ${product.name}`}
                                                className="h-16 w-16 object-cover rounded"
                                            />
                                        ))
                                    ) : (
                                        <Typography className="text-xs font-semibold text-blue-gray-600">
                                            No Images
                                        </Typography>
                                    )}
                                </dd>
                            </div>

                        </dl>
                    </div>
                </div>
            )}
        </div>
        
    );
}

export default ProductDetailForm;
