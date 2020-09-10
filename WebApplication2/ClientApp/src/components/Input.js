import React, { Component } from "react";
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';
import { Link } from "react-router-dom";
import "./InputU.css" 
import { Redirect } from "react-router-dom"



export default class InputU extends Component {
    constructor() {
        super();
        this.state = {
            log: "",
            pass: "",
            reder: false,
        }
    }
    onClick = (event) => {
        let logpas = this.state.log + ";" + this.state.pass;
        fetch("Account/Login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
            },
            body: JSON.stringify(logpas)
        })
            .then((c) => {
                if (c.ok) {
                    c.json().then(j => localStorage.setItem("Token", j));
                    this.setState({ reder:true })
                } else {
                     alert("Проверьте логин и пароль")
                }
                
            });
    }
    componentDidMount() {
        fetch("Account/Check", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
                "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке
            },
        }).then(c => {
            if (c.ok) {
                c.json().then(j => { this.setState({ reder:true }) })
            } else {
            }

        })
    }
    render() {
        return (
            <div className="LoginContainer">
                <h2><p align="center" >Введите логин и пароль</p></h2>
               
                <Form style={{ width: "250px" }}>
                    <FormGroup >
                        <Label for="Login">Логин</Label>
                        <Input type="login" name="login" id="Login" value={this.state.log} onChange={(e) => { this.setState({ log: e.target.value }) }} placeholder="Введите логин" />
                    </FormGroup>
                    <FormGroup>
                        <Label for="Password">Пароль</Label>
                        <Input type="password" name="password" id="Password" value={this.state.pass} onChange={(e) => { this.setState({ pass: e.target.value }); }} placeholder="Введите пароль" />
                    </FormGroup>
                    <FormGroup>
                        <p align="center"> <Button color="primary" onClick={this.onClick}>Войти</Button> </p>
                        {this.state.reder == true ? <Redirect to="/profile" /> : null}
                        <p align="center"><Link to="/registration">Зарегистрироваться</Link></p>
                    </FormGroup>
                    </Form>
                
            </div>
        )
    }
}