import React from 'react'
import Home from './pages/client/Home';
import Account from './pages/client/Account';
import Chat from './pages/client/Chat';
import ChatBot from './components/client/chat/ChatBot';
import Games from './pages/client/Games';
import MemoryGame from './components/client/games/MemoryGame';
import PuzzleGame from './components/client/games/PuzzleGame';
import Movies from './pages/client/Movies';
import MovieDetail from './components/client/movies/MovieDetail';
import About from './pages/client/About';
import Event from './pages/client/Event';
import EventDetail from './components/client/event/EventDetail';
import TicketConfirmation from './components/client/event/TicketConfirmation';
import Basket from './pages/client/Basket';
import TicketGenerationPage from './components/client/event/TicketGenerationPage';
import Blog from './pages/client/Blog';
import BlogDetail from './components/client/blog/BlogDetail';
import PrivacyPolicy from './constants/privacyPolicy';
import Legacies from './constants/legacies';

export const clientRoutes = [  {
    title: "client pages",
    layout: "client",
    pages: [
      {
        name: 'home',
        path: '/home',
        element: <Home />,
      },
      {
        name: 'account',
        path: '/account/*',
        element: <Account />,
      },
      {
        name: 'chat',
        path: '/chat/*',
        element: <Chat />,
      },
      {
        name: 'chatbot',
        path: '/chatbot/:characterId', 
        element: <ChatBot />,
      },
      {
        name: 'games',
        path: '/games/*', 
        element: <Games />,
      },
      {
        name: 'memorygame',
        path: '/games/memorygame', 
        element: <MemoryGame />,
      },
      {
        name: 'puzzlegame',
        path: '/games/puzzlegame', 
        element: <PuzzleGame/>,
      },
      {
        name: 'movies',
        path: '/movies', 
        element: <Movies/>,
      },
      {
        name: 'movies',
        path: '/movies/:movieId', 
        element: <MovieDetail/>,
      },
      {
        name: 'about',
        path: '/about', 
        element: <About/>,
      },
      {
        name: 'event',
        path: '/event', 
        element: <Event/>,
      },
      {
        name: 'event',
        path: '/event/:eventId', 
        element: <EventDetail/>,
      },
      {
        name: 'blog',
        path: '/blog', 
        element: <Blog/>,
      },
      {
        name: 'blog',
        path: '/blog/:blogId', 
        element: <BlogDetail/>,
      },
      {
        name: 'event',
        path: '/event/confirm-ticket/:eventId', 
        element: <TicketConfirmation/>,
      },
      {
        name: 'event',
        path: '/event/ticket-generation', 
        element: <TicketGenerationPage/>,
      },
      {
        name: 'basket',
        path: '/basket', 
        element: <Basket/>,
      },
      {
        name: 'privacy-policy',
        path: '/privacy-policy', 
        element: <PrivacyPolicy/>,
      },
      {
        name: 'legacies',
        path: '/legacies', 
        element: <Legacies/>,
      },
    ], 
  },
];

export default clientRoutes;