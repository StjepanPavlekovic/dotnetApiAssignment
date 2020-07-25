import React from "react";
import "./manufacturer-card.style.scss";

const ManufacturerCard = (props) => {
  return (
    <div className="card">
      <div className="card-image"></div>
      <div className="card-content">
        <h2>{props.data.name}</h2>
        <h3>{props.data.website}</h3>
      </div>
    </div>
  );
};

export default ManufacturerCard;
