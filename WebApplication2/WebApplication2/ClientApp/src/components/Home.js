import React, { Component } from 'react';
import { Button, Input } from 'reactstrap';
import { Breadcrumb, BreadcrumbItem } from 'reactstrap';
import { Table } from 'reactstrap';

export class Home extends Component {
    constructor() {
        super();
        this.state = {
            events:[]
        }
    }
    displayName = Home.name
    res = [];
    Click = () => { alert('Message'); }
    result = fetch("Home/GetEvent", {
        method: "POST",
        headers: {
            Accept: "application/json"
        }
    }).then(c => c.json).then(s => { this.setState({ events: s }) });
    onClickBTN = (event) => {
    }
    render() {
        console.log(this.res);
        return (
            <div>
                <Breadcrumb>
                    <BreadcrumbItem active>Мероприятия </BreadcrumbItem>
                </Breadcrumb>

                <Table striped>
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Название мероприятия</th>
                            <th>Место проведения</th>
                            <th>Тип мероприятия</th>
                            <th>Количество участников</th>
                            <th>Стоимость входа</th>
                            <th>...</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.state.events.map(c => {
                            return (
                                <tr>
                                    <th scope="row">{c.IdEvent}</th>
                                    <td>{c.nameEvent}</td>
                                    <td>{c.place}</td>
                                    <td>{c.amount} </td>
                                    <td>{c.cost}  </td>
                                    <td> <Button color="primary" onClick={this.onClickBTN}>Участвовать</Button> </td>
                                </tr>

                            )

                        })}
                    </tbody>
                </Table>
            </div>
        );
    }
}
