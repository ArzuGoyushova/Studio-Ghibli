import React, {useState, useEffect} from 'react'
import Board from './Board'

const imageUrls = [
    './images/games/puzzle/puzzle1.jpg',
    './images/games/puzzle/puzzle2.jpg',
    './images/games/puzzle/puzzle3.jpg',
    './images/games/puzzle/puzzle4.jpg',
    './images/games/puzzle/puzzle5.jpg',
  ];
  
  const getRandomImageUrl = () => {
    const randomIndex = Math.floor(Math.random() * imageUrls.length);
    return imageUrls[randomIndex];
  };

const PuzzleGame = () => {
    const [imgUrl, setImgUrl] = useState("./images/games/puzzle/puzzle1.jpg")

    useEffect(() => {
        const urlParams = new URLSearchParams(window.location.search);
        if (urlParams.has("img")) {
          setImgUrl(urlParams.get("img"));
        } else {
          const randomImageUrl = getRandomImageUrl();
          setImgUrl(randomImageUrl);
        }
      }, []);
  
      const handleImageChange = (e) => {
        setImgUrl(e.target.value);
        window.history.replaceState("", "", updateURLParameter(window.location.href, "img", e.target.value));
      };
  
    return (
      <div className="container mx-auto">
        <section className='flex flex-col items-center'>
        <h2 className='m-10 p-4 rounded text-3xl md:text-4xl lg:text-5xl bg-mainBlueColor text-white'>
         Ghibli Sliding Puzzle</h2>
        <Board imgUrl={imgUrl} />
        <input hidden value={imgUrl} onChange={handleImageChange} />
        </section>
      </div>
    );
  }


export default PuzzleGame
