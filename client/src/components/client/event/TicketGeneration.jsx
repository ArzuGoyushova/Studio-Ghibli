import React, { useState, useEffect } from 'react';
import jsPDF from 'jspdf';
import axios from 'axios';
import QRCode from 'qrcode';
import setAuthToken from '../account/setAuthToken';
import { useNavigate } from 'react-router-dom';

const TicketGeneration = ({ existingBasketItems }) => {
  const navigate = useNavigate();

  const fetchUserData = async () => {
    try {
      const token = localStorage.getItem('authToken');
      setAuthToken(token);

      const response = await axios.get(`https://arzugoyushova-001-site1.htempurl.com/api/account/user-data`, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });

      const userData = response.data;
      const fullName = userData.fullName;
      const email = userData.email;

      return { email, fullName };
    } catch (error) {
      console.error("Error fetching user data:", error);
      throw error;
    }
  };

  const generateAndSendTicket = async (email, fullName) => {
    const pdf = new jsPDF();


    const lineHeight = 10;
    let startY = 30;
    const ticketWidth = 140;
    const ticketHeight = 180;
    const borderWidth = 2;
  
    for (const [index, item] of existingBasketItems.entries()) {
      if (index > 0) {
        pdf.addPage();
        startY = 20;
      }
  
      pdf.setDrawColor(0, 0, 0);
      pdf.setFillColor(0, 0, 0);
      pdf.rect(20, startY, ticketWidth, ticketHeight, 'FD');
  
      pdf.setFillColor(0, 102, 204);
      pdf.rect(20, startY, ticketWidth, lineHeight * 2, 'F');
  
      pdf.setFont('helvetica', 'bolditalic');
      pdf.setFontSize(18);
      pdf.setTextColor(255, 255, 255);
      const text = 'Event Ticket';
      const textWidth = pdf.getStringUnitWidth(text) * 18 / pdf.internal.scaleFactor;
      const textX = 20 + (ticketWidth - textWidth) / 2;
      const textY = startY + lineHeight * 1.5;
      pdf.text(text, textX, textY);
  
      startY += lineHeight * 2;
  
      pdf.setFillColor(0, 102, 204);
      pdf.rect(20, startY, ticketWidth, ticketHeight - (lineHeight * 4), 'F');
  
      pdf.setFont('helvetica', 'italic');
      pdf.setFontSize(12);
      pdf.setTextColor(255, 255, 255);
  
      const contentX = 25;
  
      pdf.text(`Event: ${item.event.title}`, contentX, startY + lineHeight);
      startY += lineHeight;
  
      pdf.text(`Event Time: ${new Date(item.event.eventDate).toLocaleString()}`, contentX, startY + lineHeight);
      startY += lineHeight;
  
      pdf.text(`Address: ${item.event.address}`, contentX, startY + lineHeight);
      startY += lineHeight;
  
      if (item.seatNumber !== null) {
        pdf.text(`Price: $${item.event.price.toFixed(2)}`, contentX, startY + lineHeight);
        startY += lineHeight;
      
        pdf.text('', contentX, startY + lineHeight);
        startY += lineHeight;
      
        pdf.text(`Seat Number: ${item.seatNumber}`, contentX, startY + lineHeight);
        startY += lineHeight;
      } else {
        pdf.text(`Price: $${item.event.price.toFixed(2)}`, contentX, startY + lineHeight);
        startY += lineHeight;
      }
  
      const qrCodeCanvas = document.createElement('canvas');
      await QRCode.toCanvas(qrCodeCanvas, item.ticketCode, { width: 80, height: 80 });
      const qrCodeX = 20 + (ticketWidth - 40) / 2;
      const qrCodeY = startY + (ticketHeight - (lineHeight * 4) - 40) / 2;
      pdf.addImage(qrCodeCanvas.toDataURL('image/png'), 'PNG', qrCodeX, qrCodeY, 40, 40);
  
      startY += ticketHeight;
    }

    const pdfDataUrl = pdf.output('datauristring');

    const response = await axios.post('https://arzugoyushova-001-site1.htempurl.com/api/Ticket/send-ticket-pdf', {
      to: email,
      subject: 'Ghibli Studio Event Tickets',
      body: `Dear ${fullName}, Here are your tickets:`,
      pdfDataUrl: pdfDataUrl,
    });
    localStorage.removeItem('basketItems');
    navigate('/home');
  };

  useEffect(() => {
    fetchUserData()
      .then(({ email, fullName }) => {
        generateAndSendTicket(email, fullName);
      })
      .catch((error) => {
        console.error("Error:", error);
      });
  }, []);

  return null;
};

export default TicketGeneration;