import axios from 'axios';

const sendSubscriptionMessages = async (event) => {
  try {
    const subscribersResponse = await axios.get('https://arzugoyushova-001-site1.htempurl.com/api/Subscription'); 
    const subscribers = subscribersResponse.data;

    const subject = 'New Event Alert';
    const body = `Get ready and join "${event.title}" on ${new Date(event.eventDate).toLocaleString()}`;

    await Promise.all(
      subscribers.map(async (subscriber) => {
        const messageData = {
          to: subscriber.email,
          subject: subject,
          body: body,
        };
        await axios.post("https://arzugoyushova-001-site1.htempurl.com/api/Subscription/send-subscription-message", messageData);
      })
    );
    console.log("Subscription messages sent successfully.");
  } catch (error) {
    console.error('Error sending subscription messages:', error);
  }
};

export default sendSubscriptionMessages;