package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;
import java.util.List;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class Maps implements Serializable{
    private String name;
    private int id_event;
    private String description;
    private int id;
    //private List<Point> points;

    public Maps(String name, int id_event, String description,/* String path,*/ int id){
        this.name=name;
        this.id_event=id_event;
        this.description=description;
        //this.path=path;
        this.id=id;
    }

    public Maps(String name, int id_event, String description /*String path,*/ ){//int id, List<Point> points){
        this.name=name;
        this.id_event=id_event;
        this.description=description;
        //this.path=path;
        this.id=id;
        //this.points=points;
    }

    public Maps(){}

   // public List<Point> getPoints() {
   //     return points;
   // }
   // public void setPoints(List<Point> name) {
   ///     this.points = points;
   // }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public int getId_event() {
        return id_event;
    }
    public void setId_event(int id_event) {
        this.id_event = id_event;
    }

    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
    }

    /*public String getPath() {
        return path;
    }
    public void setPath(String path) {
        this.path = path;
    }*/

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
        Maps other = (Maps) obj;
        if (id!=((Maps) obj).id)
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
