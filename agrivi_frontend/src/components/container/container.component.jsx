import React, { Component } from "react";
import Header from "../header/header.component";
import Content from "../content/content.component";
import "./container.style.scss";

class Container extends Component {
  constructor(props) {
    super(props);

    this.state = {
      search: "",
      orderBy: "name",
      manufacturers: [],
    };
  }

  handleOrderingChange = (value) => {
    console.log("Invoked with", value);
    this.setState({
      orderBy: value,
    });
  };

  handleInputChange = (value) => {
    this.setState({
      search: value,
    });
  };

  loadItems = () => {
    var context = this;
    fetch(
      `https://localhost:5001/api/manufacturers?orderBy=${this.state.orderBy}&name=${this.state.search}`
    )
      .then(function (response) {
        return response.json();
      })
      .then(function (jsonData) {
        return JSON.stringify(jsonData);
      })
      .then(function (jsonString) {
        return JSON.parse(jsonString);
      })
      .then(function (data) {
        context.setState({ manufacturers: data.items });
      });
  };

  componentDidMount() {
    this.loadItems();
  }

  render() {
    return (
      <div className="container">
        <Header
          handleOrderingChange={this.handleOrderingChange}
          loadItems={this.loadItems}
          handleInputChange={this.handleInputChange}
        />
        <Content items={this.state.manufacturers} />
      </div>
    );
  }
}

export default Container;
