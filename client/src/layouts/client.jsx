import React, {useState, useEffect} from 'react';
import { Routes, Route, Navigate } from 'react-router-dom';
import Header from '../components/client/Header';
import Footer from '@/components/client/Footer';
import clientRoutes from '@/clientRoutes';
import Loading from '@/components/client/Loading';
import ScrollUpButton from '@/components/client/ScrollUpButton';
import logoutAndRedirect from '@/components/client/logoutAndRedirect';

const Layout = () => {
  const [loading, setLoading] = useState(true);
  const authTokenExpiration = localStorage.getItem('authTokenExpiration');
  let interval;



  useEffect(() => {
    setTimeout(() => {
      setLoading(false);
    }, 1500);
  }, []);

  useEffect(() => {
    const checkTokenExpiration = () => {
      const currentTime = Date.now();
      if (authTokenExpiration && currentTime > parseInt(authTokenExpiration, 40)) {
        clearInterval(interval);
        logoutAndRedirect();
        localStorage.removeItem('basketItems');
      }
    };

    const interval = setInterval(checkTokenExpiration, 1000);

    return () => {
      clearInterval(interval);
    };
  }, [authTokenExpiration]);

  return (
    <div>
      
      <Header/>
      <main>
      {loading ? (
        <Loading />
      ) : (
        <Routes>
          <Route path="/" element={<Navigate to="/home" />} />
          {clientRoutes.map((routeGroup, index) => (
            routeGroup.pages.map((page, pageIndex) => (
              <Route
                key={`route-${index}-${pageIndex}`}
                path={page.path}
                element={page.element}
              />
            ))
          ))}
        </Routes>
      )}
      </main>
      <Footer/>
      <ScrollUpButton />
    </div>
  )
}

export default Layout;
