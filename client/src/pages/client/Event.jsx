import React from 'react'
import { useEffect } from 'react';
import { useState } from 'react';
import axios from 'axios';
import EventCard from '@/components/client/event/EventCard';
import SearchResultsModal from '@/components/client/event/SearchResultModal';
import EventSidebar from '@/components/client/event/EventSidebar';

const Event = () => {
    const [events, setEvents] = useState([]);
    const [showSearchModal, setShowSearchModal] = useState(false);
  const [searchResults, setSearchResults] = useState([]);
  const [selectedCategoryId, setSelectedCategoryId] = useState(null);
  const [categoryEvents, setCategoryEvents] = useState([]);

  const handleCategoryClick = (categoryId) => {
    const categoryEvents = events.filter(event => event.categoryId === categoryId && !event.isDeleted);

    setSelectedCategoryId(categoryId);
    setCategoryEvents(categoryEvents);
  }; 
    useEffect(() => {
        fetchEvents();
    }, []);

    const fetchEvents = async () => {
        try {
            const response = await axios.get("https://arzugoyushova-001-site1.htempurl.com/api/Event");
            const filteredEvents = response.data.filter((e) => !e.isDeleted);
            setEvents(filteredEvents);
        } catch (error) {
            console.error("Error fetching events:", error);
        }
    };

    const handleGoBack = () => {
        setSelectedCategoryId(null);
        setCategoryEvents([]);
      };

      const handleSearch = async (searchTerm) => {
        const filteredResults = events.filter(event =>
          event.title.toLowerCase().includes(searchTerm.toLowerCase())
        );
    
        setSearchResults(filteredResults);
        setShowSearchModal(true);
      };

  return (
    <div className="container mx-auto rounded-lg mt-5 mb-10 pb-5 md:pe-5 border flex flex-col md:flex-row">
      <div className=" w-full md:w-1/4">
        <EventSidebar events={events} onSearch={handleSearch} onCategoryClick={handleCategoryClick} />
      </div>
      <div className="w-full md:w-3/4">
      {selectedCategoryId !== null ? (
          <div>
            <button
              className="mt-2 mb-4 px-4 py-2 bg-gray-300 text-gray-700 rounded hover:bg-gray-400"
              onClick={handleGoBack}
            >
              Go Back
            </button>
            <div className="space-y-2">
              {categoryEvents.map((event, index) => (
              <EventCard key={event.id} event={event} /> 
            ))}
          </div>
          </div>
          ) : (
            <div>
      {events.map((event) => (
                <EventCard key={event.id} event={event} /> 
            ))}
            </div>)}

            </div>
            {showSearchModal && (
        <SearchResultsModal
          searchResults={searchResults}
          onClose={() => setShowSearchModal(false)}
        />
      )}
    </div>
  )
}

export default Event
