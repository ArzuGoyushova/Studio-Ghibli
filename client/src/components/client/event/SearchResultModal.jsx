import React from 'react';
import { Link } from 'react-router-dom';

const SearchResultsModal = ({ searchResults, onClose }) => {
  return (
    <div className="fixed inset-0 flex justify-center items-center bg-black bg-opacity-50 z-50">
      <div className="bg-white p-4 rounded-lg w-96">
        <h2 className="text-2xl font-semibold mb-4">Search Results</h2>
        <div className="space-y-4">
          {searchResults.map((event, index) => (
            <div key={index} className="flex space-x-4">
              <img
                src={`./images/event/${event.imageUrl}`}
                alt={`Event ${index + 1}`}
                className="w-20 h-28 object-cover"
              />
              <div>
                <h3 className="font-semibold">{event.title}</h3>
                <p className="text-gray-500 text-sm mb-2">{event.description}</p>
                <Link to={`/event/${event.id}`} className="px-3 py-1 bg-mainBlueColor text-white rounded hover:bg-blue-700">
                  View Details
                </Link>
              </div>
            </div>
          ))}
        </div>
        <button
          className="mt-4 px-3 py-1 bg-gray-300 text-gray-700 rounded hover:bg-gray-400"
          onClick={onClose}
        >
          Close
        </button>
      </div>
    </div>
  );
};

export default SearchResultsModal;
