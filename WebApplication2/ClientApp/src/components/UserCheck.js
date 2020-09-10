import React from "react"
import { Redirect } from "react-router-dom"
import "./Home.css"



export default class CheckUser extends React.Component {
    constructor() {
        super();
        this.state = {
            flag: false,
            user: ""
        }

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
                    c.json().then(j => this.setState({ user: j, flag: true }))
                } else {
                }

            })
    }
    render() {
    
        if (this.state.user.length > 0) {
            console.log(this.state.flag)
            return (
                !this.flag ? <p align="right" >Привет, {this.state.user}</p> : <p align ="right">Привет незнакомец,зарегистрируйся</p>)
        }
        else {
            return (<p> </p>)
        }
    }

}


