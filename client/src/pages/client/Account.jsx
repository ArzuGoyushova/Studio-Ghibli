import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Login from '@/components/client/account/Login';
import Register from '@/components/client/account/Register';
import VerifyAccount from '@/components/client/account/VerifyAccount';
import UserProfile from '@/components/client/account/UserProfile';
import NewPassword from '@/components/client/account/NewPassword';
import ResetPassword from '@/components/client/account/ResetPassword';
import UserWatchList from '@/components/client/account/UserWatchList';
import UserEvents from '@/components/client/account/UserEvents';

const Account = () => {
  return (
    <div>
     <Routes>
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="reset-password" element={<ResetPassword />} />
        <Route path="new-password" element={<NewPassword />} />
        <Route path="verify-account" element={<VerifyAccount />} />
        <Route path="user-profile" element={<UserProfile />} />
        <Route path="user-watchlist" element={<UserWatchList />} />
        <Route path="user-events" element={<UserEvents />} />
      </Routes>
    </div>
  );
}

export default Account;
