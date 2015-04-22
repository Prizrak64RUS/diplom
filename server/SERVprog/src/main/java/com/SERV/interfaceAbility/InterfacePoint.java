package com.SERV.interfaceAbility;

import com.SERV.view.entity.Point;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfacePoint {
    public ArrayList<Point> getPoints(int idMap);
    public void updPoint(ArrayList<Point> points);
    public void setPoints(ArrayList<Point> points);
    public void delPoints(ArrayList<Point> points);

}
