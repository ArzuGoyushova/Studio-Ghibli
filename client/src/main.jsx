import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import 'tailwindcss/tailwind.css';
import { HashRouter } from 'react-router-dom';
import { ThemeProvider } from "@material-tailwind/react";
import { MaterialTailwindControllerProvider } from "@/context";
import "../public/css/tailwind.css";
import { GoogleOAuthProvider } from '@react-oauth/google';
import secrets from '../secret';
import { Elements } from '@stripe/react-stripe-js';
import { loadStripe } from '@stripe/stripe-js';
const stripePromise = loadStripe(secrets.stripeKey);

ReactDOM.createRoot(document.getElementById('root')).render(
      <HashRouter>
      <ThemeProvider>
        <MaterialTailwindControllerProvider>
        <Elements stripe={stripePromise}>
        <GoogleOAuthProvider clientId={secrets.googleClientId}>
          <App />
          </GoogleOAuthProvider>
          </Elements>
        </MaterialTailwindControllerProvider>
      </ThemeProvider>
    </HashRouter>,
)
