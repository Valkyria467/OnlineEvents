import React, { Component } from 'react';
import { Button, Form, FormGroup, Label, Input } from 'reactstrap';
import "./NewEvent.css";
import { RotateSpinner } from "react-spinners-kit";
import DateTimePicker from 'react-datetime-picker';

export default class NewEvent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            types: [],
            photos: [],
            decors: [],
            leaders: [],
            date: new Date(),
            currentDate: new Date()
        };
    }

    onClick = () => {
        let result = {
            NameEvent:"",
            typeEvent:"",
            Amount:"",
            NamePlace:"",
            NameCity:"",
            NameStreet:"",
            NumHouse:"",
            Cost:"",
            Leader:"",
            Photo:"",
            Decor:"",
            InfoEvent: "",
            date:""
        }
        result.NameEvent = document.getElementById("NameEvent").value;
        result.typeEvent = document.getElementById("typeEvent").value;
        result.Amount = document.getElementById("Amount").value;
        result.NamePlace = document.getElementById("NamePlace").value;
        result.NameCity = document.getElementById("NameCity").value;
        result.NameStreet = document.getElementById("NameStreet").value;
        result.NumHouse = document.getElementById("NumHouse").value;
        result.Cost = document.getElementById("Cost").value;
        result.Leader = document.getElementById("Leader").value;
        result.Photo = document.getElementById("Photo").value;
        result.Decor = document.getElementById("Decor").value;
        result.InfoEvent = document.getElementById("InfoEvent").value;
        result.date = this.state.date.toISOString();
        fetch("NewEvent/InputEv", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
                "Authorization": "Bearer " + localStorage.getItem("Token")

            },
            body: JSON.stringify(result)
        }).then((c) => {
            if (c.ok) {
                alert("Успешно")
            } else {
                alert("Проверьте правильность ввода данных")
            }
        })
    }
    restype = fetch("Home/GetType", {
        method: "POST",
        headers: {
            Accept: "application/json",
        },
    })
        .then((c) => c.json())
        .then((s) => {
            this.setState({ types: s });
        });
    resphoto = fetch("Home/GetPhoto", {
        method: "POST",
        headers: {
            Accept: "application/json",
        },
    })
        .then((c) => c.json())
        .then((s) => {
            this.setState({ photos: s });
        });
    resleader = fetch("Home/GetLeader", {
        method: "POST",
        headers: {
            Accept: "application/json",
        },
    })
        .then((c) => c.json())
        .then((s) => {
            this.setState({ leaders: s });
        });
    resdec = fetch("Home/GetDecor", {
        method: "POST",
        headers: {
            Accept: "application/json",
        },
    })
        .then((c) => c.json())
        .then((s) => {
            this.setState({ decors: s });
        });
    
    render() {
        if (this.state.types.length > 0 &&  this.state.photos.length >= 0 && this.state.decors.length >= 0 && this.state.leaders.length >= 0) {
            return (
                <div>
                    <div class="four"><h1>Создай свое мероприятие</h1></div>

                    <Form>
                        <FormGroup className="FormGreen" style={{ width: "550px" }}>
                            <Label for="htwo"> <h2>Заполните необходимые поля</h2></Label>
                        </FormGroup>
                        <FormGroup style={{ width: "400px" }} className="FormEvent">
                            <Label for="nameEvent">Название мероприятия</Label>
                            <Input type="text" name="selectName" id="NameEvent" >
                            </Input>
                        </FormGroup>

                        <FormGroup style={{ width: "400px" }} className="FormEvent">
                            <Label for="typeEvent">Выберите тип мероприятия </Label>
                            <Input type="select" name="select type" id="typeEvent">  {this.state.types.map(c => <option>{c.nameType}</option>)}</Input>
                        </FormGroup>
                        <FormGroup style={{ width: "170px" }} className="FormEvent">
                            <Label for="amountEvent">Количество участников</Label>
                            <Input type="text" name="Amount" id="Amount" >
                            </Input>
                        </FormGroup>
                        <FormGroup style={{ width: "auto", maxWidth:"180px" }} className="FormEvent">
                            <Label>Дата проведения</Label>
                            <DateTimePicker minDate={this.state.currentDate} style={{ backgroundColor: "White" }} value={this.state.date} onChange={(e) => { this.setState({ date: e }) }} />
                        </FormGroup>
                        <FormGroup style={{ width: "400px" }} className="FormEvent">
                            <Label for="namePlace">Название места проведения </Label>
                            <Input type="text" name="selectPlace" id="NamePlace" >
                            </Input>
                        </FormGroup>

                        <FormGroup className="FormEvent" style={{ width: "400px " }}>
                            <Label for="Adress"><h4>Адрес места проведения</h4> </Label>
                        </FormGroup>
                        <FormGroup style={{ width: "250px " }} className="FormEvent">
                            <Label for="city" > Город </Label>
                            <Input type="text" name="city" id="NameCity" >
                            </Input>
                        </FormGroup>
                        <FormGroup style={{ width: "220px " }} className="FormEvent">
                            <Label for="Street">Улица </Label>
                            <Input type="text" name="street" id="NameStreet" >
                            </Input>
                        </FormGroup>
                        <FormGroup style={{ width: "150px " }} className="FormEvent">
                            <Label for="House">Дом</Label>
                            <Input type="text" name="house" id="NumHouse" >
                            </Input>
                        </FormGroup>
                        <FormGroup className="FormEvent" style={{ width: "400px " }}>
                            <FormGroup style={{ width: "150px " }}>
                                <Label for="Cost">Стоимость входа  </Label>

                            </FormGroup>
                            <FormGroup >
                                <Input type="text" name="cost" id="Cost" >
                                </Input>
                                <p>Если вход свободный оставьте поле пустым </p>
                            </FormGroup>
                        </FormGroup>
                        <FormGroup style={{ width: "400px" }} className="FormEvent">
                            <Label for="leader">Выберите ведущего </Label>
                            <Input type="select" name="selectLead" id="Leader">   {this.state.leaders.map(c => <option>{c.nameLeader + " " + c.surnameLeader}</option>)}</Input>
                        </FormGroup>
                        <FormGroup style={{ width: "400px" }} className="FormEvent">
                            <Label for="photo">Выберите фотографа </Label>
                            <Input type="select" name="selectPhoto" id="Photo">
                                {this.state.photos.map(c => <option>{c.namePhoto + " "+ c.surnamePhoto }</option>)}
                            </Input>
                        </FormGroup>
                        <FormGroup style={{ width: "400px" }} className="FormEvent">
                            <Label for="decor">Выберите декоратора </Label>
                            <Input type="select" name="selectDecor" id="Decor">   {this.state.decors.map(c => <option>{c.nameDecor + " " + c.surnameDecor }</option>)}</Input>
                        </FormGroup>
                        <FormGroup className="FormEvent" >
                            <Label for="infoEvent">Информацияя о мероприятии</Label>
                            <Input type="textarea" name="infoEvent" id="InfoEvent" />
                        </FormGroup>
                        <FormGroup>
                            <p align="center"> <Button className="But" onClick={this.onClick}>Сохранить</Button> </p>
                        </FormGroup>
                    </Form>
                </div >
            );
        }
        else {
            return (<RotateSpinner />)
        }
    }

}