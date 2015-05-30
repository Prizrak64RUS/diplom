package com.SERV.interfaceAbility;

import com.SERV.view.entity.Point;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfacePoint {
    public ArrayList<Point> getPoints(Object[] val);
    public void updPoint(ArrayList<Point> points);
    public void setPoints(ArrayList<Point> points);
    public void delPoints(ArrayList<Point> points);

    public boolean busyPoint(Point point);
    public boolean busyNotPoint(Point point);
    public boolean updateBusyPoint(Point point);
    public boolean delBusyPoint(Point point);
    public boolean setBusyPoint(Point point);

    public Point getPoint(int id);

}
