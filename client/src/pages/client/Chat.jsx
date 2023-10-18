import React, {useState} from 'react';
import { Link } from 'react-router-dom';
import { chatCharacters } from '@/constants/constant';
import ChatBot from '@/components/client/chat/ChatBot';

const Chat = () => {

  const [selectedCharacterId, setSelectedCharacterId] = useState(null);
  const [showChatBot, setChatBot] = useState(false);

  const handleCharacterIdClick = (characterId) => {
    setChatBot(true);
    setSelectedCharacterId(characterId);
  };

  return (
    <div className='container mx-auto'>
      {showChatBot ? (
                <div className="mt-4 mx-5">
                    <ChatBot characterId={selectedCharacterId} />
                </div>
            ) : (
      <section id='chatSection' className='mb-30'>
        <div id='chatHeader' className='text-center'>
          <h1 className='m-10 text-3xl md:text-5xl lg:text-6xl dark:text-white'>
            Choose a Ghibli Character to Chat
          </h1>
          <h3 className='mb-10 text-xl md:text-2xl lg:text-3xl text-red-500'>
            Don't hesitate to ask your questions! They're all friendly and nice!
          </h3>
          <div
            id='chatLinks'
            className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8 my-10'
          >
            {chatCharacters.map((char) => (
              <div
                key={char.id}
                className='flex flex-col items-center p-4 border border-gray-300 rounded-lg shadow-md transition duration-300 transform hover:scale-105'
              >
                <Link onClick={() => handleCharacterIdClick(char.id)}>
                  <img src={char.imageUrl} alt={char.id} className='w-64 h-64 rounded-full mb-4' />
                </Link>
                <h4 className='text-xl font-semibold mb-2'>{char.title}</h4>
                <p className='text-sm text-gray-600'>{char.desc}</p>
              </div>
            ))}
          </div>
        </div>
      </section>
)}
    </div>
  )};

export default Chat
