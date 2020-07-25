import React from "react";
import ManufacturerCard from "../manufacturer-card/manufacturer-card.component";
import "./content.style.scss";

const Content = (props) => {
  return (
    <div className="content">
      <div className="content-display">
        {props.manufacturers.map((x) => (
          <ManufacturerCard manufacturer={x} key={x.id} />
        ))}
      </div>
    </div>
  );
};

export default Content;
