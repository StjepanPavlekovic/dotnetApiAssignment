import React, { Component } from "react";
import Header from "../header/header.component";
import Content from "../content/content.component";
import "./container.style.scss";

class Container extends Component {
  constructor(props) {
    super(props);

    this.state = {
      search: "",
      orderBy: "",
      manufacturers: [],
    };
  }
  componentDidMount() {
    var context = this;
    fetch("https://localhost:5001/api/manufacturers")
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
  }

  render() {
    return (
      <div className="container">
        <Header />
        <Content manufacturers={this.state.manufacturers} />
      </div>
    );
  }
}

export default Container;
