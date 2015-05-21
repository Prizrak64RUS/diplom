package com.SERV.view.entity;

/**
 * Created by prizrak on 19.05.2015.
 */
public class Busy {
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getIdUser() {
        return idUser;
    }

    public void setIdUser(int idUser) {
        this.idUser = idUser;
    }

    public int getIdPoint() {
        return idPoint;
    }

    public void setIdPoint(int idPoint) {
        this.idPoint = idPoint;
    }

    public int getIdEvent() {
        return idEvent;
    }

    public void setIdEvent(int idEvent) {
        this.idEvent = idEvent;
    }

    private int id;
    private int idUser;
    private int idPoint;
    private int idEvent;

    public Busy(int id, int idUser, int idPoint, int idEvent) {
        this.id = id;
        this.idUser = idUser;
        this.idPoint = idPoint;
        this.idEvent = idEvent;
    }

    public Busy() {
        this.id = 0;
        this.idUser = 0;
        this.idPoint = 0;
        this.idEvent = 0;
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
        Busy other = (Busy) obj;
        if (id!=((Busy) obj).id)
            return false;
        return true;
    }
}
