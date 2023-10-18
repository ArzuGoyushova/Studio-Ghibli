import { toast } from 'react-toastify';

const logoutAndRedirect = () => {
  localStorage.removeItem('authToken');
  toast.success('Logged out due to session expiration.', { autoClose: 2000 });  
};

export default logoutAndRedirect;