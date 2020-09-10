import React, { Component } from 'react';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { Button } from "reactstrap"
import { LinkContainer } from 'react-router-bootstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    displayName = NavMenu.name

    render() {
        return (
            <Navbar inverse fixedTop fluid collapseOnSelect>
                <Navbar.Header>
                    <Navbar.Brand>
                        <Link to={'/'}>Главная</Link>
                    </Navbar.Brand>
                    <Navbar.Toggle />
                </Navbar.Header>
                <Navbar.Collapse>
                    <Nav>
                        <LinkContainer to={'/'} exact>
                            <NavItem>
                                <Glyphicon glyph='home' /> Главная
              </NavItem>
                        </LinkContainer>
                        <LinkContainer to={'/input'}>
                            <NavItem>
                                <Glyphicon glyph='user' /> Пользователь
              </NavItem>
                        </LinkContainer>
                        {localStorage.getItem("Token") != null ?
                            <LinkContainer to={'/newEvent'}>
                                <NavItem>
                                    <Glyphicon glyph='tasks' /> Создай свое мероприятие
                                </NavItem>
                            </LinkContainer> : ""}
                        <NavItem onClick={() => { localStorage.removeItem("Token"); }}>
                            {localStorage.getItem("Token") != null ? <Link to="/"> <Glyphicon glyph='log-out' /> Выход</Link> : ""}
                        </NavItem>

                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        );
    }
}
