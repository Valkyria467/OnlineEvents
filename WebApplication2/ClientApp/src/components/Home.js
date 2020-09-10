import React, { Component } from "react";
import { Button, Input, Spinner } from "reactstrap";
import { Breadcrumb, BreadcrumbItem } from "reactstrap";
import { Table } from "reactstrap";
import { Link } from "react-router-dom";
import { RotateSpinner } from "react-spinners-kit";
import CheckUser  from "./UserCheck"


export class Home extends Component {
  
    constructor(props) {
        super(props);
        this.state = {
            events: [],
            places: [],
        };
    }
    displayName = Home.name;
    result = fetch("Home/GetEvent", {
        method: "POST",
        headers: {
            Accept: "application/json",
        },
    })
        .then((c) => c.json())
        .then((s) => {
            this.setState({ events: s });
        });
    res = fetch("Home/GetPlaces", {
        method: "POST",
        headers: {
            Accept: "application/json",
        },
    })
        .then((c) => c.json())
        .then((s) => {
            this.setState({ places: s });
        });
  
    render() {
        if (this.state.events.length > 0 && this.state.places.length > 0) {
            
            return (
                <div>
                    <Breadcrumb>
                        <CheckUser/>
                        <div class="four"><h1>Предстоящие мероприятия</h1></div>
                    </Breadcrumb>

                    <Table striped style={{ backgroundColor:"white" }}>
                        <thead>
                            <tr>
                                <th> # </th>
                                <th> Название мероприятия </th>
                                <th> Место проведения </th>
                                <th> Дата проведения </th>
                                <th> Количество участников </th>
                                <th> Стоимость входа </th>
                                <th> ... </th>
                            </tr>
                        </thead>
                        <tbody>
                            {this.state.events.length==0 ? "Событий нет" : this.state.events.map((c) => {
                                return (
                                    <tr>
                                        <th scope="row"> {c.idEvent} </th>
                                        <td>{c.nameEvent}</td>
                                        <td> {this.state.places.map(j => j.idPlace === c.place).namePlace} </td>
                                        <td> {c.dateEvent} </td>
                                        <td> {c.amount} </td>
                                        <td> {c.cost==null? "Свободный": c.cost} </td>
                                        <td>
                                            {" "}
                                            <Link to={'/infoevent/' + c.idEvent}> <Button color="primary" >
                                                Подробнее
                    </Button>{" "}
                                            </Link>
                                        </td>
                                    </tr>
                                );
                            })}
                        </tbody>
                    </Table>
                </div>
            );
        }
        else

            return (
                <div>
                    <RotateSpinner />
                    <p>Идет загрузка. Если загрузка идет очень долго то возможно у вас нет созданных событий</p>
                </div>
            );
    }
}
