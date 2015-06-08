package com.SERV.view.entity;

import java.io.Serializable;

/**
 * Created by prizrak on 02.06.2015.
 */
public class Schedulepoint  implements Serializable {
    private int id;
    private int id_masterclass;
    private int id_point;
    private String date_start;
    private String time_start;
    private String time_end;

    public Schedulepoint(int id, int id_masterclass, int id_point, String date_start, String time_start, String time_end) {
        this.id = id;
        this.id_masterclass = id_masterclass;
        this.date_start = date_start;
        this.id_point = id_point;
        this.time_start = time_start;
        this.time_end = time_end;
    }

    public Schedulepoint() {
    }

    public String getTime_start() {
        return time_start;
    }

    public void setTime_start(String time_start) {
        this.time_start = time_start;
    }

    public String getTime_end() {
        return time_end;
    }

    public void setTime_end(String time_end) {
        this.time_end = time_end;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getDate_start() {
        return date_start;
    }

    public void setDate_start(String date_start) {
        this.date_start = date_start;
    }

    public int getId_point() {
        return id_point;
    }

    public void setId_point(int id_point) {
        this.id_point = id_point;
    }

    public int getId_masterclass() {
        return id_masterclass;
    }

    public void setId_masterclass(int id_masterclass) {
        this.id_masterclass = id_masterclass;
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
        Schedulepoint other = (Schedulepoint) obj;
        if (id!=((Schedulepoint) obj).id)
            return false;
        return true;
    }
}

