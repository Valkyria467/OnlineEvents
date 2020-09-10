import React, { Component } from "react";
import { Button, Form, FormGroup, Label, Input, FormText } from 'reactstrap';

export default class Registration extends Component {

    onClick = (event) => {

        
        if (document.getElementById("Password").value === document.getElementById("Password2").value) {
            let logpas = document.getElementById("Login").value + ";" + document.getElementById("Password").value + ";" + document.getElementById("NameUser").value + ";" + document.getElementById("SurnameUser").value;
            fetch("Account/RegisterUser", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                },
                body: JSON.stringify(logpas)
            })
                .then((c) => {
                    if (c.ok) {
                         alert("Успешно")
                    } else {
                        alert("Проверьте правильность ввода данных")
                    }

                });
        }
        else {
            alert("Пароли не совпадают");
        }
    }
    render() {
        return (
            <div>
                <h2><p align="center">Регистрация</p></h2>
                <h3><p align="center">Введите данные</p></h3>
                <Form style={{ width: "250px" }}>
                    <FormGroup >
                        <Label for="NameUser">Имя</Label>
                        <Input type="text" name="NameUser" id="NameUser" placeholder="Введите имя" />
                    </FormGroup>
                    <FormGroup >
                        <Label for="SurnameUser">Фамилия</Label>
                        <Input type="text" name="SurnameUser" id="SurnameUser" placeholder="Введите фамилию" />
                    </FormGroup>
                    <FormGroup >
                        <Label for="Login">Логин</Label>
                        <Input type="login" name="login" id="Login" placeholder="Введите логин" />
                    </FormGroup>
                    <FormGroup>
                        <Label for="Password">Пароль</Label>
                        <Input type="password" name="password" id="Password" placeholder="Введите пароль" />
                    </FormGroup>
                    <FormGroup>
                        <Label for="Password2">Повторите пароль</Label>
                        <Input type="password" name="password2" id="Password2" placeholder="Введите пароль еще раз" />
                    </FormGroup>
                    <FormGroup>
                        <p align="center"> <Button color="primary" onClick={this.onClick}>Сохранить</Button> </p>
                    </FormGroup>
                </Form>
            </div>
            )
    }
}