import React from 'react'
import { useNavigate } from 'react-router-dom';

const HomeChat = () => {
  const navigate = useNavigate();

  const goToChat = async () => {
    navigate('/chat');
  }
  
  return (
    <div className='chat-background' >
        <section id="chat-section" className='container mx-auto mt-4 flex flex-col justify-between md:flex-row'>
      <div className='chat-header my-4 flex items-center w-full md:w-1/2 md:my-0'>
      
        <h1 className="mt-5 text-3xl text-center leading-none tracking-tight md:text-5xl lg:text-6xl ">
  Chat with your favorite Ghibli Character <button onClick={goToChat} className="animate-bounce text-red-500 pointer">Here</button>
</h1>
      </div>
      <div className='chat-image w-full md:w-1/2  flex flex-col items-end me-5'>
        <div className='flex space-x-14 md:space-x-10'>
            <img src='./images/home/bubble1.png' className='w-40 md:w-54'/>
            <img src='./images/home/jiji.png' className='w-40 md:w-54'/>
        </div>
        <div className='flex space-x-16 md:space-x-10 '>
        <img src='./images/home/totoro.png' className='w-40 md:w-54'/>
        <img src='./images/home/bubble2.png' className='w-40 md:w-54'/>
           
        </div>
     </div>
     </section>
    </div>
  )
}

export default HomeChat
