import React, { Component } from "react";
import CarCard from "../car-card/car-card.component";
import EditModel from "../edit-model/edit-model.component";
import "./content.style.scss";

class Content extends Component {
  constructor(props) {
    super(props);

    this.state = {
      toggleModels: false,
      orderBy: "",
      search: "",
      carModels: [],
      editing: false,
      carModel: null,
    };
  }

  toggle = (id) => {
    this.setState(
      {
        toggleModels: !this.state.toggleModels,
      },
      () => {
        if (id) {
          this.loadCars(id);
        }
      }
    );
  };

  toggleEmpty = () => {
    this.setState({
      toggleModels: !this.state.toggleModels,
    });
  };

  toggleEditing = (carModel) => {
    this.setState({
      editing: !this.state.editing,
      carModel: carModel,
    });
  };

  endEditing = () => {
    this.setState({
      editing: !this.state.editing,
    });
  };

  loadCars = (id) => {
    if (id) {
      fetch(
        `https://localhost:5001/api/models?orderBy=${this.state.orderBy}&name=${
          this.state.search
        }${id ? `&manufacturerId=${id}` : ``}`
      )
        .then((response) => {
          console.log(response);
          return response.json();
        })
        .then((jsonData) => {
          return JSON.stringify(jsonData);
        })
        .then((jsonString) => {
          return JSON.parse(jsonString);
        })
        .then((data) => {
          this.setState({ carModels: data.items });
        });
    }
  };

  render() {
    return (
      <div className="content-container">
        <div className={this.state.toggleModels ? " display-none" : ""}>
          <div className="content-display">
            {this.props.items.map((x) => (
              <CarCard
                manufacturer={true}
                toggle={this.toggle}
                data={x}
                key={x.id}
              />
            ))}
          </div>
        </div>
        {this.state.editing ? (
          <EditModel endEditing={this.endEditing} model={this.state.carModel} />
        ) : null}
        <div className={this.state.toggleModels ? "" : " display-none"}>
          <button className="my-button" onClick={this.toggleEmpty}>
            Back
          </button>
          {this.state.toggleModels ? (
            <div className="content-display">
              {this.state.carModels.map((x) => (
                <CarCard
                  manufacturer={false}
                  toggle={this.toggle}
                  toggleEditing={this.toggleEditing}
                  data={x}
                  key={x.id}
                  loadModels={this.loadCars}
                />
              ))}
            </div>
          ) : null}
        </div>
      </div>
    );
  }
}

export default Content;
