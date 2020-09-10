import React, { Component } from "react";
import { Container, Col, Row, Table, Button } from "reactstrap";
import ProfileImg from "./Images/профиль.jpg";
import CheckUser from "./UserCheck"
import { RotateSpinner } from "react-spinners-kit";
import { Redirect } from "react-router-dom"
import "./ProfileUser.css"

export default class ProfileUser extends Component {
    constructor() {
        super();
        this.state = {
            flag: true,
            events: [],
            places: [],
            events4check: [],
            flagAdmin: false,
            redit: false,
            redir: true,
            user: "",
        }
    }
    componentDidMount() {
        fetch("Account/GetFio",
            {
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                    "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке
                }
            }).then(c => {
                if (c.ok) c.json().then(j => {
                    this.setState({ user: j, redir: true })
                    this.setState({ flag: true })
                })
            });
        fetch("Account/Check", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                Accept: "application/json",
                "Content-Type": "application/json",

                "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке
            },
        }).then(c => {
            c.json().then(c => { if (c == "Admin") this.setState({ flagAdmin: true }) });
            if (!c.ok) {
                this.setState({ redir: true })
            }
        })
        fetch("Account/GetEvents",
            {
                headers: {
                    "Content-Type": "application/json",
                    Accept: "application/json",
                    "Content-Type": "application/json",

                    "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке
                }
            }).then(c => {
                if (c.ok) c.json().then(j => {
                    this.setState({ flag: true, events: j })

                })
            });

        fetch("Home/GetPlaces", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
        })
            .then((c) => c.json())
            .then((s) => {
                this.setState({ places: s });
            });
        fetch("Home/GetNAEvent", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
        })
            .then((c) => c.json().then(s => this.setState({ events4check: s })));
    }

    accept = (id) => {
        var eva01 = this.state.events4check.map(c => c.idEvent != id);
        this.setState({ events4check: eva01 })
        fetch("Home/AcceptEvent", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(id)
        })

    }

    decline = (id) => {
        var eva01 = this.state.events4check.map(c => c.idEvent != id);
        this.setState({ events4check: eva01 })
        fetch("Home/DeclineEvent", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
            },
            body: JSON.stringify(id)
        })
            .then((c) => c.json().then(s => this.setState({ events: s })));
    }
    onClick = (id) => {
        var eva01 = this.state.events.map(c => c.idEvent != id);
        this.setState({ events: eva01 })
        fetch("Home/OnRemoveEvents", {
            method: "POST",
            headers: {
                Accept: "application/json",
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem("Token")  // передача токена в заголовке

            },
            body: JSON.stringify(id)
        }).then((c) => c.json().then(s => this.setState({ events: s })));
    }
    render() {

        if (this.state.user !== undefined && this.state.places !== undefined && this.state.events !== undefined && this.state.events4check !== undefined) {
            console.log(this.state.places)

            return (
                <div>
                    <CheckUser />
                    <Table>
                        <tr>
                            <td ><img src={ProfileImg} className="UserPhoto" height="200" width="200" />  </td>
                            <div className="userModul">
                                <td className="UserName">
                                    <tr><h1>Имя:</h1>
                                    </tr>
                                    <tr><h1>Фамилия: </h1>
                                    </tr>
                                </td>
                                <td>
                                    <tr><h1>{this.state.user.nameUser}</h1>
                                    </tr>
                                    <tr><h1> {this.state.user.surname}</h1>
                                    </tr>
                                </td>
                            </div>
                        </tr>
                    </Table>
                    <h2 className="Bread">История посещенных мероприятий</h2>
                    <Table className="EventTable" striped>
                        <thead>
                            <tr>
                                <th> # </th>
                                <th> Название мероприятия </th>
                                <th> Место проведения </th>

                                <th> Количество участников </th>
                                <th> Стоимость входа </th>
                                <th> Дата проведения</th>
                                <th> ... </th>
                            </tr>
                        </thead>
                        <tbody>

                            {this.state.events.length > 0 ?
                                (
                                    this.state.events.map(c =>
                                        <tr>
                                            <th />
                                            <th>{c.nameEvent}</th>
                                            <td>{this.state.places.map(j => j.idPlace == c.place).namePlace}</td>

                                            <td>{c.amount}</td>
                                            <td>{c.cost == null ? "Свободный вход" : c.cost}</td>
                                            <td>{c.dateEvent}</td>
                                            <Button onClick={() => this.onClick(c.idEvent)} color="warning">🗑</Button>

                                        </tr>
                                    )
                                ) : ""
                            }


                        </tbody>
                    </Table>
                    {this.state.flagAdmin ? (
                        <div>
                            <h2 className="Bread">Мероприятия требующие подтверждения</h2>
                            <Table className="EventTable" striped>
                                <thead>
                                    <tr>
                                        <th> # </th>
                                        <th> Название мероприятия </th>
                                        <th> Место проведения </th>

                                        <th> Количество участников </th>
                                        <th> Стоимость входа </th>
                                        <th> Дата проведения</th>
                                        <th> ... </th>
                                        <th> ... </th>
                                    </tr>
                                </thead>
                                <tbody>

                                    {this.state.events4check.length > 0 ? (
                                        this.state.events4check.map(c =>
                                            < tr >
                                                <td />
                                                <td>{c.nameEvent}</td>
                                                <td>{this.state.places.map(j => j.idPlace === c.place).namePlace}</td>
                                                <td>{c.amount}</td>
                                                <td>{c.cost}</td>
                                                <td>{c.dateEvent}</td>
                                                <td></td>
                                                <td> <Button color="primary" onClick={() => { this.accept(c.idEvent) }} > Одобрить</Button></td>
                                                <td><Button color="warning" onClick={() => { this.decline(c.idEvent) }}>Отклонить</Button></td>
                                            </tr>
                                        )
                                    ) : ""}


                                </tbody>
                            </Table></div>) : null
                    }
                </div>
            )
        } else {
            return (<div>
                {this.state.redit ? <Redirect to="/input" /> : null}
                <RotateSpinner /></div>)
        }
    }
}