package com.SERV.view.entity;

import java.io.Serializable;

/**
 * Created by prizrak on 02.06.2015.
 */
public class Masterclass  implements Serializable {
    private int id;
    private int id_event;
    private String name;
    private String decription;
    private String lecturer1;
    private String lecturer2;
    private String lecturer3;

    public Masterclass() {
    }

    public Masterclass(int id, int id_event, String name, String decription, String lecturer1, String lecturer3, String lecturer2) {
        this.id = id;
        this.id_event = id_event;
        this.name = name;
        this.decription = decription;
        this.lecturer1 = lecturer1;
        this.lecturer3 = lecturer3;
        this.lecturer2 = lecturer2;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getId_event() {
        return id_event;
    }

    public void setId_event(int id_event) {
        this.id_event = id_event;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDecription() {
        return decription;
    }

    public void setDecription(String decription) {
        this.decription = decription;
    }

    public String getLecturer1() {
        return lecturer1;
    }

    public void setLecturer1(String lecturer1) {
        this.lecturer1 = lecturer1;
    }

    public String getLecturer2() {
        return lecturer2;
    }

    public void setLecturer2(String lecturer2) {
        this.lecturer2 = lecturer2;
    }

    public String getLecturer3() {
        return lecturer3;
    }

    public void setLecturer3(String lecturer3) {
        this.lecturer3 = lecturer3;
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
        Masterclass other = (Masterclass) obj;
        if (id!=((Masterclass) obj).id)
            return false;
        return true;
    }
}
