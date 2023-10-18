import React, { useState } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import * as Yup from 'yup';
import axios from 'axios';
import { toast, ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useLocation, useNavigate } from 'react-router-dom';

const VerifyAccount = () => {
  const location = useLocation();
  const email = location.state.email;
  const phoneNumber = location.state.phoneNumber;
  const userId = location.state.userId;

  const [selectedVerificationMethod, setSelectedVerificationMethod] = useState('email');

  const initialValues = {
    otp: '',
    email: email,
    phoneNumber: phoneNumber,
    userId: userId
  };

  const navigate = useNavigate();

  const validationSchema = Yup.object({
    otp: Yup.string().required('Please enter the OTP'),
  });

  const handleSubmit = async (values, { setSubmitting }) => {
    try {
      const response = await axios.post('https://arzugoyushova-001-site1.htempurl.com/api/account/verify', values);

      if (response.data.success) {
        toast.success(response.data.message);
        setSelectedVerificationMethod('phone');
      } else {
        toast.error(response.data.message);
      }
    } catch (error) {
      toast.error('An error occurred. Please try again later.');
    } finally {
      setSubmitting(false);
    }
  };

  const handleSubmitNumber = async (values, { setSubmitting }) => {
    try {
      const response = await axios.post('https://arzugoyushova-001-site1.htempurl.com/api/account/verify-sms', values);

      if (response.data.success) {
        toast.success(response.data.message, {
          onClose: () => {
            navigate('/account/login');
          }});
      } else {
        toast.error(response.data.message);
      }
    } catch (error) {
      toast.error('An error occurred. Please try again later.');
    } finally {
      setSubmitting(false);
    }
  };

  const handleResendOTP = async () => {
    try {
      const response = await axios.post(
        'https://arzugoyushova-001-site1.htempurl.com/api/account/resend-otp',
        { email: email }
      );

      if (response.data.success) {
        toast.success(response.data.message);
      } else {
        toast.error('Failed to resend OTP. Please try again later.');
      }
    } catch (error) {
      console.log(error);
      toast.error('Failed to resend OTP. Please try again later.');
    }
  };

  const handleResendNumberOTP = async () => {
    try {
      const response = await axios.post(
        'https://arzugoyushova-001-site1.htempurl.com/api/account/resend-sms-otp',
        { phoneNumber: phoneNumber }
      );

      if (response.data.success) {
        toast.success(response.data.message);
      } else {
        toast.error('Failed to resend OTP. Please try again later.');
      }
    } catch (error) {
      console.log(error);
      toast.error('Failed to resend OTP. Please try again later.');
    }
  };

  return (
    <div className="flex justify-center items-center min-h-screen bg-gray-100">
      <div
        className={`${
          selectedVerificationMethod === 'email' ? 'block' : 'hidden'
        } w-full max-w-md p-6 bg-white rounded shadow-lg`}
      >
        <h2 className="text-2xl font-semibold mb-4">Verify Email</h2>
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          onSubmit={handleSubmit}
        >
          <Form>
            <div className="mb-4">
              <label htmlFor="otp" className="block text-gray-600">
                Enter OTP:
              </label>
              <Field
                type="text"
                id="otp"
                name="otp"
                className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
              />
              <ErrorMessage name="otp" component="div" className="text-red-500" />
            </div>
            <div>
              <button
                type="submit"
                className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 focus:outline-none"
              >
                Verify
              </button>
            </div>
            <div className="text-center">
              <button
                type="button"
                onClick={handleResendOTP}
                className="text-blue-500 hover:underline focus:outline-none"
              >
                Resend OTP
              </button>
            </div>
          </Form>
        </Formik>
        <ToastContainer />
      </div>

      <div
        className={`${
          selectedVerificationMethod === 'phone' ? 'block' : 'hidden'
        } w-full max-w-md p-6 bg-white rounded shadow-lg`}
      >
        <h2 className="text-2xl font-semibold mb-4">Verify Phone Number</h2>
        <Formik
          initialValues={initialValues}
          validationSchema={validationSchema}
          onSubmit={handleSubmitNumber}
        >
          <Form>
            <div className="mb-4">
              <label htmlFor="otp" className="block text-gray-600">
                Enter OTP:
              </label>
              <Field
                type="text"
                id="otp"
                name="otp"
                className="w-full p-2 border rounded focus:outline-none focus:border-blue-400"
              />
              <ErrorMessage name="otp" component="div" className="text-red-500" />
            </div>
            <div>
              <button
                type="submit"
                className="w-full bg-blue-500 text-white py-2 rounded hover:bg-blue-600 focus:outline-none"
              >
                Verify
              </button>
            </div>
            <div className="text-center">
              <button
                type="button"
                onClick={handleResendNumberOTP}
                className="text-blue-500 hover:underline focus:outline-none"
              >
                Resend OTP
              </button>
            </div>
          </Form>
        </Formik>
        <ToastContainer />
      </div>
    </div>
  );
};

export default VerifyAccount;
