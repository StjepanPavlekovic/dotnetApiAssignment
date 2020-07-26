import React from "react";
import "./car-card.style.scss";

const CarCard = (props) => {
  const handleClick = () => {
    if (props.manufacturer) {
      props.toggle(props.data.id);
      return;
    } else {
      props.toggleEditing(props.data);
      return;
    }
  };

  return (
    <div className="card" onClick={handleClick}>
      <div className="card-image"></div>
      <div className="card-content">
        <h2>{props.data.name}</h2>
        {props.manufacturer ? (
          <h3>{props.data.website}</h3>
        ) : (
          <h3>{props.data.year}</h3>
        )}
      </div>
    </div>
  );
};

export default CarCard;
