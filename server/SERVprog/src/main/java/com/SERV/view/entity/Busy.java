package com.SERV.view.entity;

import java.io.Serializable;

/**
 * Created by prizrak on 19.05.2015.
 */
public class Busy implements Serializable {


    private int id;
    private int idUser;
    private int idPoint;
    private int idGroup;

    public Busy(int id, int idGroup, int idPoint, int idUser) {
        this.id = id;
        this.idGroup = idGroup;
        this.idPoint = idPoint;
        this.idUser = idUser;
    }

    public Busy() {
    }

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

    public int getIdGroup() {
        return idGroup;
    }

    public void setIdGroup(int idGroup) {
        this.idGroup = idGroup;
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
