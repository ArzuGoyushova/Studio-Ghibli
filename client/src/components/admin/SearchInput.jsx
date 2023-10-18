import React from "react";
import PropTypes from "prop-types";


function SearchInput({ placeholder, searchTerm, setSearchTerm }) {
  return (
    <input
      type="text"
      placeholder={placeholder}
      value={searchTerm}
      onChange={(e) => setSearchTerm(e.target.value)}
      className="border border-gray-300 rounded-md px-2 py-1 text-gray-900 focus:outline-none focus:border-blue-500"
    />
  );
}

SearchInput.propTypes = {
  searchTerm: PropTypes.string.isRequired,
  setSearchTerm: PropTypes.func.isRequired,
};

export default SearchInput;
