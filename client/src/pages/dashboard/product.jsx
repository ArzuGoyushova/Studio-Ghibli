import React, { useState, useEffect } from "react";
import axios from "axios";
import {
    Card,
    CardHeader,
    CardBody,
    Typography
} from "@material-tailwind/react";

import ProductCreateForm from "@/components/admin/ProductCreateForm";
import ProductUpdateForm from "@/components/admin/ProductUpdateForm";
import ProductDetailForm from "@/components/admin/ProductDetailForm";

export function Product() {
    const [showForm, setShowForm] = useState(false);
    const [showUpdateForm, setShowUpdateForm] = useState(false);
    const [showDetailForm, setShowDetailForm] = useState(false);
    const [products, setProducts] = useState([]);
    const [selectedProductId, setSelectedProductId] = useState(null);

    const handleAddProductClick = () => {
        setShowForm(true);
        setShowUpdateForm(false);
        setSelectedProductId(null);
    };

    const handleEditProductClick = (productId) => {
        setShowForm(true);
        setShowUpdateForm(true);
        setSelectedProductId(productId);
    };

    const handleDeleteProductClick = async (productId) => {
        try {
            const response = await axios.post(
                `https://arzugoyushova-001-site1.htempurl.com/api/Product/${productId}`
            );
            console.log("Product deleted successfully!");
            fetchProducts();
        } catch (error) {
            console.error(error);
        }
    };

    const handleDetailProductClick = (productId) => {
        setShowForm(false);
        setShowUpdateForm(false);
        setShowDetailForm(true);
        setSelectedProductId(productId);
    };

    useEffect(() => {
        fetchProducts();
    }, [showForm]);

    const fetchProducts = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Product");
            const filteredProducts = response.data.filter((product) => !product.isDeleted);
            setProducts(filteredProducts);
        } catch (error) {
            console.error("Error fetching products:", error);
        }
    };

    return (
        <div className="mt-8 mb-8 flex flex-col gap-12">
            {showForm ? (
                <div className="mt-4">
                    {showUpdateForm ? (
                        <ProductUpdateForm productId={selectedProductId} />
                    ) : (
                        <ProductCreateForm />
                    )}
                </div>
            ) : showDetailForm ? (
                <div className="mt-4">
                    <ProductDetailForm productId={selectedProductId} />
                </div>
            ) : (
                <Card>
                    <button
                        onClick={handleAddProductClick}
                        className="w-48 mx-4 mt-4 mb-16 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
                    >
                        Add a product
                    </button>
                    <CardHeader variant="gradient" color="blue" className="mb-8 p-3">
                        <Typography variant="h6" color="white">
                            Products Table
                        </Typography>
                    </CardHeader>
                    <CardBody className="overflow-x-scroll px-0 pt-0 pb-2">
                        <table className="w-full min-w-[800px] table-auto">
                            <thead>
                                <tr>
                                    {["Id", "Image", "Name", "Regular Price", "Count", ""].map((el) => (
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
                                {products.map(({ id, imageUrls, name, regularPrice, count, discount }, index) => {
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
                                            {imageUrls && imageUrls.length > 0 ? (
        <img
            src={`./images/products/${imageUrls[0]}`} 
            alt={`Product ${name}`}
            className="h-20 w-20 object-cover rounded"
        />
    ) : (
                                                    <Typography className="text-xs font-semibold text-blue-gray-600">
                                                        No Images
                                                    </Typography>
                                                )}
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {name}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {regularPrice}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {count}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography className="text-xs font-semibold text-blue-gray-600">
                                                    {discount || "-"}
                                                </Typography>
                                            </td>
                                            <td className={className}>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600 mr-2"
                                                    onClick={() => handleEditProductClick(id)}
                                                >
                                                    Edit
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-red-600 mr-2"
                                                    onClick={() => handleDeleteProductClick(id)}
                                                >
                                                    Delete
                                                </Typography>
                                                <Typography
                                                    as="a"
                                                    className="text-xs cursor-pointer font-semibold text-blue-600"
                                                    onClick={() => handleDetailProductClick(id)}
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

export default Product;
