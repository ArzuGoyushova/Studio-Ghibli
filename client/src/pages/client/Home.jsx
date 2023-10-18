import React from 'react';
import ParallaxBanner from '@/components/client/home/ParallaxBanner';
import HomeMovies from '@/components/client/home/HomeMovies';
import HomeChat from '@/components/client/home/HomeChat';
import HomeEvent from '@/components/client/home/HomeEvent';
import HomeBlog from '@/components/client/home/HomeBlog';
import HomeGames from '@/components/client/home/HomeGames';

const Home = () => {
  return (
    <div>
      <ParallaxBanner />
      <HomeMovies />
      <HomeChat />
      <HomeEvent />
      <HomeBlog />
      <HomeGames />
    </div>
  );
};

export default Home;

