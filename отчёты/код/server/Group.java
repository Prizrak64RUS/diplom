package com.SERV.view.entity;

import java.io.Serializable;

/**
 * Created by prizrak on 29.05.2015.
 */
public class Group implements Serializable {
    private int id;
    private int idEvent;
    private int number_child;
    private int numberResponsible;
    private int numberOverall;
    private String responsible;
    private String school;
    private String location;
    private String date;
    private int groupExist;


    public Group(int id, int idEvent, int number_child, int numberResponsible, int numberOverall, String responsible, String school, String location, String date, int groupExist) {
        this.id = id;
        this.idEvent = idEvent;
        this.number_child = number_child;
        this.numberResponsible = numberResponsible;
        this.numberOverall = numberOverall;
        this.responsible = responsible;
        this.school = school;
        this.location = location;
        this.date = date;
        this.groupExist=groupExist;
    }

    public Group() {
    }

    public int getGroupExist() {
        return groupExist;
    }

    public void setGroupExist(int groupExist) {
        this.groupExist = groupExist;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getLocation() {
        return location;
    }

    public void setLocation(String location) {
        this.location = location;
    }

    public String getSchool() {
        return school;
    }

    public void setSchool(String school) {
        this.school = school;
    }

    public String getResponsible() {
        return responsible;
    }

    public void setResponsible(String responsible) {
        this.responsible = responsible;
    }

    public int getNumberOverall() {
        return numberOverall;
    }

    public void setNumberOverall(int numberOverall) {
        this.numberOverall = numberOverall;
    }

    public int getNumberResponsible() {
        return numberResponsible;
    }

    public void setNumberResponsible(int numberResponsible) {
        this.numberResponsible = numberResponsible;
    }

    public int getNumber_child() {
        return number_child;
    }

    public void setNumber_child(int number_child) {
        this.number_child = number_child;
    }

    public int getIdEvent() {
        return idEvent;
    }

    public void setIdEvent(int idEvent) {
        this.idEvent = idEvent;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
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
        Group other = (Group) obj;
        if (id!=((Group) obj).id)
            return false;
        return true;
    }
}
