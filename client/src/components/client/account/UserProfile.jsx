import React from 'react';
import UserEditProfile from './UserEditProfile';
import UserSideBar from './UserSideBar';

const UserProfile = () => {
  return (
    <div className="flex">
      
      <UserSideBar/>
      <UserEditProfile/>
      
   </div>
  );
};

export default UserProfile;

