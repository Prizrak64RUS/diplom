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
    private boolean isBusy;
    private int id_user_Busy;
    private int id;

    public Point(String name,String type, double x, double y, double size_w, double size_h, String description, int id_map, boolean isBusy, int id_user_Busy, int id){
        this.name=name;
        this.type=type;
        this.description=description;
        this.x=x;
        this.id_map=id_map;
        this.id=id;
        this.y=y;
        this.isBusy=isBusy;
        this.id_user_Busy=id_user_Busy;
        this.size_w=size_w;
        this.size_h=size_h;

    }

    public Point(String name,String type, double x, double y, double size_w, double size_h, String description, int id_map, int isBusy, int id_user_Busy, int id){
        this.name=name;
        this.type=type;
        this.description=description;
        this.x=x;
        this.id_map=id_map;
        this.id=id;
        this.y=y;
        this.isBusy=(isBusy==0)? false: true;
        this.id_user_Busy=id_user_Busy;
        this.size_w=size_w;
        this.size_h=size_h;

    }

    public Point(){}


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

    public boolean getIsBusy() {
        return isBusy;
    }
    public void setIsBusy(int isBusy) {
        this.isBusy=(isBusy==0)? false: true;
    }
    public void setIsBusy(boolean isBusy) {
        this.isBusy=isBusy;
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
