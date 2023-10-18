import React from 'react';
import { ChevronLeftIcon, ChevronRightIcon } from '@heroicons/react/20/solid';

const Pagination = ({ pageCount, currentPage, onPageChange }) => {
  const pageNumbers = Array.from({ length: pageCount }, (_, index) => index + 1);

  const renderPageNumbers = () => {
    if (pageCount <= 7) {
      return pageNumbers.map(pageNumber => (
        <button
          key={pageNumber}
          onClick={() => onPageChange(pageNumber)}
          className={`relative z-10 inline-flex items-center px-4 py-2 text-sm font-semibold ${
            currentPage === pageNumber
              ? 'bg-indigo-600 text-white focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600'
              : 'text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:outline-offset-0'
          }`}
        >
          {pageNumber}
        </button>
      ));
    }

    const visiblePageNumbers = [];
    if (currentPage <= 4) {
      visiblePageNumbers.push(...pageNumbers.slice(0, 5), '...');
    } else if (currentPage >= pageCount - 3) {
      visiblePageNumbers.push(1, '...', ...pageNumbers.slice(pageCount - 5));
    } else {
      visiblePageNumbers.push(1, '...', currentPage - 1, currentPage, currentPage + 1, '...', pageCount);
    }

    return visiblePageNumbers.map((item, index) => (
      <button
        key={index}
        onClick={() => {
          if (item !== '...') {
            onPageChange(item);
          }
        }}
        className={`relative z-10 inline-flex items-center px-4 py-2 text-sm font-semibold ${
          item === currentPage
            ? 'bg-indigo-600 text-white focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600'
            : 'text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus:outline-offset-0'
        }`}
      >
        {item}
      </button>
    ));
  };

  return (
    <div className="flex items-center justify-between border-t border-gray-200 bg-white px-4 py-3 sm:px-6">
      <div className="flex flex-1 justify-between sm:hidden">
        <button
          onClick={() => onPageChange(currentPage - 1)}
          disabled={currentPage === 1}
          className={`relative inline-flex items-center rounded-md border ${
            currentPage === 1 ? 'border-gray-300' : 'border-indigo-500'
          } bg-white px-4 py-2 text-sm font-medium text-gray-700 ${
            currentPage === 1 ? 'cursor-not-allowed' : 'hover:bg-gray-50'
          }`}
        >
          Previous
        </button>
        <button
          onClick={() => onPageChange(currentPage + 1)}
          disabled={currentPage === pageCount}
          className={`relative ml-3 inline-flex items-center rounded-md border ${
            currentPage === pageCount ? 'border-gray-300' : 'border-indigo-500'
          } bg-white px-4 py-2 text-sm font-medium text-gray-700 ${
            currentPage === pageCount ? 'cursor-not-allowed' : 'hover:bg-gray-50'
          }`}
        >
          Next
        </button>
      </div>
      <div className="hidden sm:flex sm:flex-1 sm:items-center sm:justify-between">
        <div>
          <p className="text-sm text-gray-700">
            Showing <span className="font-medium">{(currentPage - 1) * 10 + 1}</span> to{' '}
            <span className="font-medium">
              {Math.min(currentPage * 10, pageCount * 10)}{' '}
            </span>
            of <span className="font-medium">{pageCount * 10}</span> results
          </p>
        </div>
        <div>
          <nav className="isolate inline-flex -space-x-px rounded-md shadow-sm" aria-label="Pagination">
            <button
              onClick={() => onPageChange(currentPage - 1)}
              disabled={currentPage === 1}
              className={`relative inline-flex items-center rounded-l-md px-2 py-2 text-gray-400 ${
                currentPage === 1 ? 'ring-1 ring-inset ring-gray-300' : 'ring-1 ring-inset ring-indigo-500 hover:bg-gray-50 focus:z-20 focus:outline-offset-0'
              }`}
            >
              <span className="sr-only">Previous</span>
              <ChevronLeftIcon className="h-5 w-5" aria-hidden="true" />
            </button>
            {renderPageNumbers()}
            <button
              onClick={() => onPageChange(currentPage + 1)}
              disabled={currentPage === pageCount}
              className={`relative inline-flex items-center rounded-r-md px-2 py-2 text-gray-400 ${
                currentPage === pageCount ? 'ring-1 ring-inset ring-gray-300' : 'ring-1 ring-inset ring-indigo-500 hover:bg-gray-50 focus:z-20 focus:outline-offset-0'
              }`}
            >
              <span className="sr-only">Next</span>
              <ChevronRightIcon className="h-5 w-5" aria-hidden="true" />
            </button>
          </nav>
        </div>
      </div>
    </div>
  );
};

export default Pagination;
