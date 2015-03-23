package com.SERV.view.entity;

import java.io.Serializable;

/**
 * Created by prizrak on 21.03.2015.
 */
public class News implements Serializable {
    private int id;
    private int id_event;
    private String description;
    private String date_write;
 //   private int id_map;
 //   private String date_news;

    public News(){}
    public News(int id, int id_event, String description, String date_write){
        this.id=id;
        this.id_event=id_event;
        this.description=description;
        this.date_write=date_write;
    }

    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
    }

    public String getDate_write() {
        return date_write;
    }
    public void setDate_write(String date_write) {
        this.date_write = date_write;
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
        News other = (News) obj;
        if (id!=((News) obj).id)
            return false;
        return true;
    }

    public void setId_event(int id_event) {
        this.id_event = id_event;
    }
    public int getId_event() {
        return id_event;
    }

    public void setId(int id) {
        this.id = id;
    }
    public int getId() {
        return id;
    }
}
