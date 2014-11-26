package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class Log_type implements Serializable{
    private String description;
    private int id;

    public Log_type(String description, int id){
        this.description=description;
        this.id=id;
    }

    public Log_type(){}

    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
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
        Log_type other = (Log_type) obj;
        if (id!=((Log_type) obj).id)
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
