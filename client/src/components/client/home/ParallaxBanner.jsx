import React, { useEffect } from 'react';

const ParallaxBanner = () => {
  useEffect(() => {
    const clouds = document.querySelectorAll('.clouds');
    
    const handleScroll = () => {
      const scrollPosition = window.scrollY;

      clouds.forEach((cloud, index) => {
        const speed = 0.2 * (index + 1); 
        cloud.style.transform = `translateY(-${scrollPosition * speed}px)`;
      });
    };

    window.addEventListener('scroll', handleScroll);

    return () => {
      window.removeEventListener('scroll', handleScroll);
    };
  }, []);

  return (
    <div className="relative">
      <img src="./images/home/banner.jpg" alt="" className="w-full" />
      <img src="./images/home/clouds1.png" alt="" className="clouds cloud1" />
      <img src="./images/home/clouds2.png" alt="" className="clouds cloud2" />
      <img src="./images/home/clouds3.png" alt="" className="clouds cloud3" />
    </div>
  );
};

export default ParallaxBanner;
