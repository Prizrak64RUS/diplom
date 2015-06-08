package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;
import java.util.List;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class Event implements Serializable{
    private String name;
    private int isActiv;
    private String description;
    private String date;
    private int id;
    private int isDelete;
   // private List<Maps> maps;

    public Event(String name, int isActiv, String description, String date, int id, int isDelete){
        this.name=name;
        this.isActiv=isActiv;
        this.description=description;
        this.date=date;
        this.id=id;
        this.isDelete=isDelete;
    }

    public Event(String name, int isActiv, String description, String date, int id){
        this.name=name;
        this.isActiv=isActiv;
        this.description=description;
        this.date=date;
        this.id=id;
        this.isDelete=0;
    }

 /*   public Event(String name, int isActiv, String description, String date, int id, List<Maps> maps){
        this.name=name;
        this.isActiv=isActiv;
        this.description=description;
        this.date=date;
        this.id=id;
        this.maps=maps;
    }

     public List<Maps> getMaps() {
        return maps;
    }
    public void setMaps(List<Maps> maps) {
        this.maps = maps;
    }
    */

    public Event(){}



    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public int getIsActiv() {
        return isActiv;
    }
    public void setIsActiv(int isActiv) {
        this.isActiv = isActiv;
    }

    public int getIsDelete() {
        return isDelete;
    }
    public void setIsDelete(int isDelete) {
        this.isDelete = isDelete;
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
        Event other = (Event) obj;
        if (id!=((Event) obj).id||!name.equals(((Event) obj).name))
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
