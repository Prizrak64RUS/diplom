package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;

/**
 * Created by prizrak on 20.01.2015.
 */
@JsonAutoDetect
public class Message implements Serializable{
    int id;
    String message;
    int idUser;
    int idUserTo;
    String date;

    public Message(){}

    public Message(int id, String message, int idUser, int idUserTo, String date){
        this.id=id;
        this.message=message;
        this.idUser=idUser;
        this.idUserTo=idUserTo;
        this.date=date;
    }

    public int getId() {
        return id;
    }
    public void setId(int id) {
        this.id = id;
    }

    public String getMessage() {
        return message;
    }
    public void setMessage(String message) {
        this.message = message;
    }

    public int getIdUser() {
        return idUser;
    }
    public void setIdUser(int idUser) {
        this.idUser = idUser;
    }

    public int getIdUserTo() {
        return idUserTo;
    }
    public void setIdUserTo(int idUserTo) {
        this.idUserTo = idUserTo;
    }

    public String getDate() {
        return date;
    }
    public void setDate(String date) {
        this.date = date;
    }

    @Override
    public int hashCode(){
        return id;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        Message other = (Message) obj;
        if (id!=((Message) obj).id)
            return false;
        return true;
    }
}
