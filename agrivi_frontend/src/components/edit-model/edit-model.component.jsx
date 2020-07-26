import React, { useState, useEffect } from "react";
import { Input, Dropdown } from "semantic-ui-react";
import "./edit-model.style.scss";

const EditModel = (props) => {
  const [manufacturers, setManufacturers] = useState([]);

  var dropDownOptions = [];

  useEffect(() => {
    fetch("https://localhost:5001/api/manufacturers?pageSize=16")
      .then((response) => {
        return response.json();
      })
      .then((jsonData) => {
        return JSON.stringify(jsonData);
      })
      .then((jsonString) => {
        return JSON.parse(jsonString);
      })
      .then((data) => {
        setManufacturers(data.items);
      });
  }, []);

  dropDownOptions = manufacturers.map((x) => ({
    key: x.name,
    text: x.name,
    value: x.id,
  }));

  console.log(dropDownOptions);

  var currentManufacturer = dropDownOptions.filter(
    (x) => x.value === props.model.manufacturerId
  );

  return (
    <div className="background">
      <div className="form-wrap">
        <div className="edit-form">
          <span className="labels">Edit name</span>
          <Input placeholder={props.model.name} />
          <span className="labels">Edit manufacturer</span>
          <Dropdown
            placeholder={
              currentManufacturer.length > 0
                ? currentManufacturer[0].text
                : "Loading data..."
            }
            fluid
            selection
            options={dropDownOptions}
          />

          <div className="option-buttons">
            <button className="my-button" onClick={props.endEditing}>
              Cancle
            </button>
            <button className="my-button">Submit</button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditModel;
