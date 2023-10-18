import React from 'react'
import { useState, useEffect } from 'react'
import SingleCard from './SingleCard'
import { toast, ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'

const gameModes = [
    { name: 'Easy', turns: 22 },
    { name: 'Normal', turns: 16 },
    { name: 'Hard', turns: 10 },
];


const cardImages = [
    { "src": "./images/games/memory/memory1.jpg", matched: false },
    { "src": "./images/games/memory/memory2.jpg", matched: false },
    { "src": "./images/games/memory/memory3.jpg", matched: false },
    { "src": "./images/games/memory/memory4.jpg", matched: false },
    { "src": "./images/games/memory/memory5.jpg", matched: false },
    { "src": "./images/games/memory/memory6.jpg", matched: false },
]

const MemoryGame = () => {

    const [cards, setCards] = useState([]);
    const [turns, setTurns] = useState(0);
    const [choiceOne, setChoiceOne] = useState(null);
    const [choiceTwo, setChoiceTwo] = useState(null);
    const [disabled, setDisabled] = useState(false);
    const [currentMode, setCurrentMode] = useState(gameModes[0]);
    const [gameWon, setGameWon] = useState(false);
    const [gameLost, setGameLost] = useState(false);


    useEffect(() => {
        shuffleCards();
    }, []);

    const shuffleCards = () => {
        setGameWon(false);
        setGameLost(false);
        const shuffledCards = [...cardImages, ...cardImages]
            .sort(() => Math.random() - 0.5)
            .map((card) => ({ ...card, id: Math.random() }));

        setChoiceOne(null);
        setChoiceTwo(null);
        setCards(shuffledCards);
        setTurns(0);
    };


    const handleChoice = (card) => {
        if (turns < currentMode.turns && (!choiceOne || !choiceTwo)) {
            if (!disabled) {
                if (!choiceOne) {
                    setChoiceOne(card);
                } else if (!choiceTwo) {
                    setChoiceTwo(card);
                }
            }
        }
        if (turns >= currentMode.turns) {
            setDisabled(true);
        }
    };

    
    useEffect(() => {
        if (choiceOne && choiceTwo) {
            setDisabled(true);
    
            if (choiceOne.src === choiceTwo.src) {
                setCards(prevCards => {
                    return prevCards.map(card => {
                        if (card.src === choiceOne.src) {
                            return { ...card, matched: true }
                        } else {
                            return card;
                        }
                    })
                })
                resetTurn();
            } else {
                setTimeout(() => resetTurn(), 1000);
            }
        }
    
        const allPairsMatched = cards.every((card) => card.matched);
        if (allPairsMatched && turns>=2) {
            toast.success('You won! 🎉', { autoClose: 3000 });
        } else if (turns >= currentMode.turns) {
            toast.error('Sorry you lost', { autoClose: 3000});
        }
    }, [choiceOne, choiceTwo]);


    const resetTurn = () => {
        setChoiceOne(null);
        setChoiceTwo(null);
        setTurns(prev => prev + 1);
        setDisabled(false);
    }



    return (
        <div className='conatiner mx-auto'>
            <section id="gameSection" className='pb-16'>
                <div id="gameHeader" className='flex flex-col items-center text-center'>
                    <h2 className='m-10 p-4 rounded text-3xl md:text-4xl lg:text-5xl bg-mainBlueColor text-white'>
                        Match the Cards!
                    </h2>
                    <div className='flex'> 
                    <button className="px-2 py-2 m-1 bg-black rounded text-white w-24 md:w-12 text-m md:w-48 md:text-lg" onClick={shuffleCards}>New Game</button>
                    <select
                        className="px-2 py-2 m-1 bg-black rounded text-white w-32 text-md md:w-32 md:text-lg"
                        value={currentMode.name}
                        onChange={(event) => {
                            const selectedMode = gameModes.find((mode) => mode.name === event.target.value);
                            setCurrentMode(selectedMode);
                            shuffleCards();
                        }}
                    >
                        {gameModes.map((mode) => (
                            <option key={mode.name} value={mode.name}>
                                {mode.name}
                            </option>
                        ))}
                    </select>

                    </div>
                    
                </div>
                <div id="gameContent" className='flex justify-center'>
                    <div className='memory-card-grid'>
                        {cards.map(card => (
                            <SingleCard
                                key={card.id}
                                card={card}
                                handleChoice={handleChoice}
                                flipped={card === choiceOne || card === choiceTwo || card.matched}
                                disabled={disabled}
                            />
                        ))}
                    </div>
                </div>
                <div className='flex flex-col items-center'>
                <p className="my-4 p-2 rounded text-lg md:text-1xl lg:text-2xl bg-mainBlueColor text-white text-center w-64">Max Turn Count is {currentMode.turns}</p>
                <p className=" p-2 rounded text-lg md:text-1xl lg:text-2xl bg-mainBlueColor text-white text-center w-64">Turns: {turns}</p>
              
                </div>
                 <ToastContainer className="mb-200"
               position='bottom-center'
               theme='dark'/>
            </section>
        </div>
    )
}

export default MemoryGame