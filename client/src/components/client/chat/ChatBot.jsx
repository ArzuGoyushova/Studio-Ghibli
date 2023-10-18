import React, { useState, useEffect } from 'react';
import { chatCharacters } from '@/constants/constant';
import '@chatscope/chat-ui-kit-styles/dist/default/styles.min.css'
import { MainContainer, ChatContainer, MessageList, Message, MessageInput, TypingIndicator } from '@chatscope/chat-ui-kit-react'
import secrets from '../../../../secret';


const API_KEY = secrets.aiKey;

const ChatBot = ({ characterId }) => {
const selectedCharacter = chatCharacters.find((char) => char.id == characterId);

 const [typing, setTyping] = useState(false);
 const [messages, setMessages] = useState([
  {
    message: selectedCharacter
        ? "Hello, I am " + selectedCharacter.name
        : "Hello, I am an Unknown Character",
    sender: "ChatGPT",
  }
 ]);

const handleSend = async (message) =>{
  const newMessage = {
    message: message,
    sender: "user",
    direction: "outgoing"
  }
    const newMessages = [...messages, newMessage];
    setMessages(newMessages);
    setTyping(true);

    await processMessageToChatGPT(newMessages);
}


async function processMessageToChatGPT(chatMessages){
    let apiMessages = chatMessages.map((messsageObject)=>{
      let role = "";
      if(messsageObject.sender === "ChatGPT"){
        role = "assistant";
      } else {
        role = "user"
      }
      return { role: role, content: messsageObject.message }
    });

    const systemMessage = {
        role: "system",
        content: `Imagine you're ${selectedCharacter.name}, ${selectedCharacter.personality} character from Studio Ghibli. Talk like them, use their unique style.`

    }

    const apiRequestBody = {
      "model": "gpt-3.5-turbo",
      "messages" : [
        systemMessage,
        ...apiMessages
      ]
    }

    await fetch("https://api.openai.com/v1/chat/completions", {
      method: "POST",
      headers: {
        "Authorization" : "Bearer " + API_KEY,
        "Content-Type" : "application/json"
      },
      body : JSON.stringify(apiRequestBody)
    }).then((data)=>{
      return data.json();
    }).then((data)=>{
      console.log(data);
      setMessages([
        ...chatMessages, {
          message : data.choices[0].message.content,
          sender : "ChatGPT"
        }
      ]);
      setTyping(false);
    })
}

  return (
    <div className="md:mx-36"style={{position:'relative', height: '400px'}}>
        <MainContainer>
          <ChatContainer>
            <MessageList
            scrollBehavior='smooth'
            typingIndicator={typing ? <TypingIndicator content={`${selectedCharacter.name} is typing`}/> : null}
            >
              {messages.map((message, index)=>{
                return <Message key={index} model={message}/>
              })}
            </MessageList>
            <MessageInput placeholder='Type message here' onSend={handleSend}/>
          </ChatContainer>
        </MainContainer>
    </div>
  )
}

export default ChatBot
