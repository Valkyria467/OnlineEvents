import React, { Component } from "react";
import { Table, Spinner, Button } from "reactstrap";
import { Badge } from 'reactstrap';
import { Redirect } from 'react-router-dom'
import "./InfoEvent.css"
import { RotateSpinner } from "react-spinners-kit";

export default class InfoEvent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            events: [],
            places: [],
            photos: [],
            decors: [],
            leaders: [],
            adminFlag:false
        };
    }
    id = this.props.match.params.ID;

    componentDidMount() {
        fetch("Home/GetEventFromID", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-type": "application/json"
            },
            body: JSON.stringify(this.id)
        }).then(c => c.json()).then(s => this.setState({ events:s }))

        fetch("Account/Check", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке

            },
            body: JSON.stringify(this.id)
        })
            .then((c) => {
                if (c.ok) {
                    this.setState({ adminFlag: true })
                }
            })
        fetch("Home/GetPlaces", {
            method: "POST",
            headers: {
                Accept: "application/json",
            },
        })
            .then((c) => c.json())
            .then((s) => {
                this.setState({ places: s });
            });

       fetch("Home/GetPhoto", {
            method: "POST",
            headers: {
                Accept: "application/json",
            },
        })
            .then((c) => c.json())
            .then((s) => {
                this.setState({ photos: s });
            });
        fetch("Home/GetLeader", {
            method: "POST",
            headers: {
                Accept: "application/json",
            },
        })
            .then((c) => c.json())
            .then((s) => {
                this.setState({ leaders: s });
            });
        fetch("Home/GetDecor", {
            method: "POST",
            headers: {
                Accept: "application/json",
            },
        })
            .then((c) => c.json())
            .then((s) => {
                this.setState({ decors: s });
            });
    }
    onClick = (id) => {
        fetch("Home/OnEvents", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке

            },
            body: JSON.stringify(id)
        })
            .then((c) => {
                if (c.ok) { alert("Вы записались!") }
                else { alert("Мест больше нет") }
                    });
    }
    removeEvent = (id) => {
        fetch("Home/DeclineEvent", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке

            },
            body: JSON.stringify(id)
        })
            .then((c) => {
                if (c.ok) { alert("Удалено!") }
                else { alert("Ошибка!") }
            });
    }
    
    render() {

        console.log(this.state.events, this.state.places, this.state.photos, this.state.decors, this.state.leaders)
        if (this.state.events.length > 0 && this.state.places.length > 0 && this.state.photos.length >= 0 && this.state.decors.length > 0 && this.state.leaders.length >0) {
            var flag = false;
            var flagDec = false;
            var flagLead = false;
            //Фотограф
            if (this.state.events[0].photo != null) {
                var phot = this.state.photos.find(j => j.idPhoto === this.state.events[0].photo)
            }
            else { flag = true; }
            //Декоратор
            if (this.state.events[0].decor != null) {
                var dec = this.state.decors.find(j => j.idDecor === this.state.events[0].decor)
                }
            else { flagDec = true; }
            //Ведущий
            if (this.state.events[0].leader != null) {
                var lead = this.state.leaders.find(j => j.idLeader === this.state.events[0].leader)
            }
            else { flagLead = true; }
           // console.log(this.state.leaders[0] ,this.state.decors[0]) 
                return (
                    <div> 
                        <Table striped className="mainTable">
                            <thead>

                                <tr>
                                    <th>Название</th><th>{this.state.events[0].nameEvent}</th>
                                </tr>
                                <tr>
                                    <th>Место проведения</th><th>{this.state.places.find(j => j.idPlace === this.state.events[0].place).namePlace}</th>
                                </tr>
                                <tr>
                                    <th>Дата проведения </th><th>{this.state.events[0].dateEvent.replace("T", " ")}</th>
                                </tr>
                                <tr>
                                    <th>Адрес</th><th>{this.state.events[0].city + ', ул.' + this.state.events[0].sreet + ' ' + this.state.events[0].house}</th>
                                </tr>
                                <tr>
                                    <th>Количество участников</th><th>{this.state.events[0].amount}</th>
                                </tr>
                                <tr>
                                    <th>Стоимость входного билета</th><th>{this.state.events[0].cost == null ? 'Свободный' : this.state.events[0].cost}</th>
                                </tr>
                                {flagLead == true ? <tr><th>Ведущий</th><th>Отсутствует</th></tr> : <tr><th>Ведущий</th> <th>{lead.nameLeader + ' ' + lead.surnameLeader}</th></tr>}
                                {flag == true ? <tr><th>Фотограф</th><th>Отсутствует</th></tr> : <tr><th>Фотограф</th> <th>{phot.namePhoto + ' ' + phot.surnamePhoto}</th></tr>}
                                {flagDec == true ? <tr><th>Декоратор</th><th>Отсутствует</th></tr> : <tr><th>Декоратор</th> <th>{dec.nameDecor + ' ' + dec.surnameDecor}</th></tr>}
                            </thead>
                        </Table>
                        <p className="InfoOfEvent">
                            <Badge className="info" color="info">ИНФОРМАЦИЯ О МЕРОПРИЯТИИ</Badge>
                            <p>{this.state.events[0].infoEvent != null ? this.state.events[0].infoEvent : "Информация отсуствует."}</p>
                        </p>
                        <Button color="primary" onClick={() => this.onClick(this.id)} >Участвовать</Button>
                        {this.state.adminFlag==true?<Button color="primary" onClick={() => this.removeEvent(this.id)} >Удалить</Button>:""}
                    </div>
                )
            } else {
                return (<RotateSpinner />)
            }
        }
    }