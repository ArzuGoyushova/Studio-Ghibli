import React, { useState, useEffect } from 'react';
import { FiArrowUpCircle } from 'react-icons/fi';

const ScrollUpButton = () => {
  const [isVisible, setIsVisible] = useState(false);
  const [showSprinkles, setShowSprinkles] = useState(false);

  const handleScroll = () => {
    if (window.pageYOffset > 300) {
      setIsVisible(true);
    } else {
      setIsVisible(false);
    }
  };

   const scrollToTop = () => {
    setShowSprinkles(true); 
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll);
    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  return (
    <div className={`fixed bottom-5 right-5 opacity-0 transition-opacity duration-300 ${isVisible ? 'opacity-100' : ''}`}>
      <button onClick={scrollToTop} className="bg-mainBlueColor hover:bg-blue-600 text-white rounded-full w-12 h-12 flex items-center justify-center focus:outline-none relative">
        <FiArrowUpCircle className="w-6 h-6" />
        {showSprinkles && <div className="sprinkles absolute top-0 left-0 w-full h-full" />}
      </button>
    </div>
  );
};

export default ScrollUpButton;
