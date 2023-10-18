import React from 'react';

const SingleCard = ({ card, handleChoice, flipped, disabled }) => {

    const handleClick = () =>{
        if(!disabled){
        handleChoice(card);
        }
    }


    return (
        <div className="memory-card">
            <div className={flipped ? "flipped" : ""}>
                <img className="memory-front" src={card.src} alt="card front" />
                <img 
                className="memory-cover" 
                onClick={handleClick} 
                src="./images/games/memory/cover.png" 
                alt="card back" />
            </div>
        </div>
    );
};

export default SingleCard;
