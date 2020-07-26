import React, { Component } from "react";
import { Form, Checkbox, Input, Button, Icon } from "semantic-ui-react";
import "./header.style.scss";

class Header extends Component {
  constructor(props) {
    super(props);

    this.state = {
      orderBy: "name",
    };
  }

  handleChange = (e, { value }) => {
    this.setState({ orderBy: value });
    this.props.handleOrderingChange(value);
  };

  handleInputChange = (e, { value }) => {
    this.props.handleInputChange(value);
  };

  render() {
    return (
      <div className="header">
        <div className="title-container">
          <div className="title">
            <Icon name="paper plane outline" />
            Agrivi Cars
          </div>
        </div>
        <div className="filters-wrap">
          <div className="filters-title">
            <h2>Filter manufacturers:</h2>
            <div className="filters">
              <Form>
                <Form.Field>Order by:</Form.Field>
                <Form.Field>
                  <Checkbox
                    radio
                    name="checkboxRadioGroup"
                    value="name"
                    checked={this.state.orderBy === "name"}
                    onChange={this.handleChange}
                  />
                  <span className="radio-text">Name asc.</span>
                </Form.Field>
                <Form.Field>
                  <Checkbox
                    radio
                    name="checkboxRadioGroup"
                    value="-name"
                    checked={this.state.orderBy === "-name"}
                    onChange={this.handleChange}
                  />
                  <span className="radio-text">Name desc.</span>
                </Form.Field>
              </Form>
              <Input
                className="input-txt"
                placeholder="Search..."
                onChange={this.handleInputChange}
              />
              <Button
                icon
                labelPosition="right"
                className="button-filter"
                onClick={this.props.loadItems}
              >
                Apply Filters
                <Icon name="right arrow" />
              </Button>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
export default Header;
