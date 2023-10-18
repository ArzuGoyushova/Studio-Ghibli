import React, { useState } from 'react';
import BasketItem from './BasketItem';

const HoverBasket = () => {
    const basketItems = JSON.parse(localStorage.getItem('basketItems')) || [];
    const totalItems = basketItems.length;
    const totalPrice = basketItems.reduce((total, item) => total + item.event.price, 0);

    const handleDeleteItem = (ticketCode) => {
        const updatedBasketItems = basketItems.filter(item => item.ticketCode !== ticketCode);
        localStorage.setItem('basketItems', JSON.stringify(updatedBasketItems));
        window.location.reload();
    };


    return (
        <div className=" absolute top-0 right-0 z-30 mt-6 px-2 bg-white w-64 h-auto rounded-xl">

            <div className="flex flex-col justify-between">
                {basketItems.length === 0 ? (
                    <div className="w-full h-64 flex flex-col justify-center items-center md:flex-row">
                        <h2 className="text-2xl">You have no items in the basket.</h2>
                        <img src="./images/noFaceBasket.gif" className="w-24" alt="No Items in Basket" />
                    </div>
                ) : (
                    <><div className="w-54 h-54 p-4 rounded-lg">
                        <div className='flex justify-between'>
                            <h2 className="text-m font-semibold">Basket Items</h2>
                            <p className="text-m text-red-900 font-semibold w-28 text-center">Total Items: {totalItems}</p>
                        </div>
                        <div className='flex flex-col'>
                            {basketItems.map((item) => (
                                <BasketItem key={item.ticketCode} item={item} onDelete={handleDeleteItem} style={{"width":"20px !important"}} />
                            ))}
                        </div>
                    </div></>
                )}
            </div>

        </div>
    );
};

export default HoverBasket;
