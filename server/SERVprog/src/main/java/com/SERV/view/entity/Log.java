package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class Log implements Serializable{
    private String description;
    private int id;
    private int id_user;
    private int id_log_type;
    private int id_events;
    private int id_point;
    private String date;

   // private List<Maps> maps;

    public Log(String description, int id, int id_user, int id_log_type, int id_events, int id_point, String date){
        this.description=description;
        this.id=id;
        this.id_user=id_user;
        this.id_log_type=id_log_type;
        this.id_events=id_events;
        this.id_point=id_point;
        this.date=date;

    }

    public Log(){}

    public int getId_user() {
        return id_user;
    }
    public void setId_user(int id_user) {
        this.id_user = id_user;
    }

    public int getId_log_type() {
        return id_log_type;
    }
    public void setId_log_type(int id_log_type) {
        this.id_log_type = id_log_type;
    }

    public int getId_point() {
        return id_point;
    }
    public void setId_point(int id_point) {
        this.id_point = id_point;
    }

    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
    }

    public String getDate() {
        return date;
    }
    public void setDate(String date) {
        this.date = date;
    }

    public int getId_event() {
        return id_events;
    }
    public void setId_event(int id_events) {
        this.id_events = id_events;
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
        Log other = (Log) obj;
        if (id!=((Log) obj).id)
            return false;
        return true;
    }

    public void setId(int id) {
        this.id = id;
    }
    public int getId() {
        return id;
    }
}
