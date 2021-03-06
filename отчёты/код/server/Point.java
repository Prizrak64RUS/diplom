package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class Point implements Serializable{
    private String name;
    private String type;
    private double x;
    private double y;
    private double size_w;
    private double size_h;
    private String description;
    private int id_map;
    private int busy;
    private int id_user_Busy;
    private int id;
    private int all_space;
    private int free_space;

    public Point(String name, String type, double x, double y, double size_w, double size_h, String description, int id_map, int busy, int id_user_Busy, int all_space, int id, int free_space) {
        this.name = name;
        this.type = type;
        this.x = x;
        this.y = y;
        this.size_w = size_w;
        this.size_h = size_h;
        this.description = description;
        this.id_map = id_map;
        this.busy = busy;
        this.id_user_Busy = id_user_Busy;
        this.all_space = all_space;
        this.id = id;
        this.free_space = free_space;
    }

    public Point(String name, String type, double x, double y, double size_w, double size_h, String description, int id_map, int busy, int id_user_Busy, int all_space, int id) {
        this.name = name;
        this.type = type;
        this.x = x;
        this.y = y;
        this.size_w = size_w;
        this.size_h = size_h;
        this.description = description;
        this.id_map = id_map;
        this.busy = busy;
        this.id_user_Busy = id_user_Busy;
        this.all_space = all_space;
        this.id = id;
        this.free_space = 0;
    }

    public Point(){}

    public int getAll_space() {
        return all_space;
    }

    public void setAll_space(int all_space) {
        this.all_space = all_space;
    }

    public int getFree_space() {
        return free_space;
    }

    public void setFree_space(int free_space) {
        this.free_space = free_space;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }
    public void setDescription(String description) {
        this.description = description;
    }

    public String getType() {
        return type;
    }
    public void setType(String type) {
        this.type = type;
    }

    public double getX() {
        return x;
    }
    public void setX(double x) {
        this.x = x;
    }

    public int getId_map() {
        return id_map;
    }
    public void setId_map(int id_map) {
        this.id_map = id_map;
    }

    public double getY() {
        return y;
    }
    public void setY(double y) {
        this.y = y;
    }

    public double getSize_w() {
        return size_w;
    }
    public void setSize_w(double size_w) {
        this.size_w = size_w;
    }

    public double getSize_h() {
        return size_h;
    }
    public void setSize_h(double size_h) {
        this.size_h = size_h;
    }

    public int getBusy() {return busy;}
    public void setIsBusy(int busy) {
        this.busy=busy;
    }

    public void setBusy(int busy) {
        this.busy = busy;
    }

    public int getId_user_Busy() {
        return id_user_Busy;
    }
    public void setId_user_Busy(int id_user_Busy) {
        this.id_user_Busy = id_user_Busy;
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
        Point other = (Point) obj;
        if (id!=((Point) obj).id)
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
