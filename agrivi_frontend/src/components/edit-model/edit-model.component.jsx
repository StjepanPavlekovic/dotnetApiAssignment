import React, { Component } from "react";
import { Input, Dropdown } from "semantic-ui-react";
import "./edit-model.style.scss";

class EditModel extends Component {
  constructor(props) {
    super(props);

    this.state = {
      manufacturers: [],
      manufacturerId: null,
      modelName: "",
      currentManufacturer: null,
    };
  }

  dropDownOptions = [];

  componentDidMount() {
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
        this.setState({
          manufacturers: data.items.map((x) => ({
            key: x.name,
            text: x.name,
            value: x.id,
          })),
          currentManufacturer: this.props.model.manufacturerId,
          modelName: this.props.model.name,
        });
      });
  }

  handleDropdown = (event, { value }) => {
    this.setState({
      manufacturerId: value,
    });
  };

  handleInput = (e, { value }) => {
    console.log(value);
    this.setState({
      modelName: value,
      manufacturers: this.state.manufacturers,
    });
  };

  doneEditing = () => {
    if (
      this.state.modelName !== "" ||
      this.state.modelName != null ||
      this.state.currentManufacturer !== this.state.manufacturerId
    ) {
      this.props.doneEditing(this.state.modelName, this.state.manufacturerId);
    }
  };

  render() {
    return (
      <div className="background">
        <div className="form-wrap">
          <div className="edit-form">
            <span className="labels">Edit name</span>
            <Input
              placeholder={this.props.model.name}
              onChange={this.handleInput}
            />
            <span className="labels">Edit manufacturer</span>
            <Dropdown
              placeholder={
                this.state.manufacturers.length > 0
                  ? this.state.manufacturers.filter(
                      (x) => x.value === this.state.currentManufacturer
                    )[0].text
                  : "Loading data..."
              }
              fluid
              selection
              options={this.state.manufacturers}
              onChange={this.handleDropdown}
            />

            <div className="option-buttons">
              <button className="my-button" onClick={this.props.stopEditing}>
                Cancle
              </button>
              <button className="my-button" onClick={this.doneEditing}>
                Submit
              </button>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default EditModel;
