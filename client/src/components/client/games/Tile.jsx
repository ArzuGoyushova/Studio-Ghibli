import React from "react";
import { motion } from "framer-motion";
import { getMatrixPosition, getVisualPosition } from "./helpers";
import { TILE_COUNT, GRID_SIZE, BOARD_SIZE } from "@/constants/constant";

function Tile(props) {
  const { tile, index, width, height, handleTileClick, imgUrl } = props;
  
  const { row, col } = getMatrixPosition(index);
  const visualPos = getVisualPosition(row, col, width, height);
  const tileStyle = {
    width: `calc(100% / ${GRID_SIZE})`,
    height: `calc(100% / ${GRID_SIZE})`,
    translateX: visualPos.x,
    translateY: visualPos.y,
    backgroundImage: `url(${imgUrl})`,
    backgroundSize: `${BOARD_SIZE}px`,
    backgroundPosition: `${(100 / (GRID_SIZE - 1)) * (tile % GRID_SIZE)}% ${(100 / (GRID_SIZE - 1)) * (Math.floor(tile / GRID_SIZE))}%`,
  };
  
  return (
    <motion.li 
      initial={{ translateX: visualPos.x, translateY: visualPos.y }} 
      animate={{ translateX: visualPos.x, translateY: visualPos.y }}
      style={{
        ...tileStyle,
        transform: `translate3d(${visualPos.x}px, ${visualPos.y}px, 0)`,
        opacity: tile === TILE_COUNT - 1 ? 0 : 1,
      }}
      className="tile"
      onClick={() => handleTileClick(index)}
    >
      {!imgUrl && `${tile + 1}`}
    </motion.li>
  );
}

export default Tile;
