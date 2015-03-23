package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfacePoint;
import com.SERV.view.entity.Point;

import java.util.ArrayList;

/**
 * Created by prizrak on 16.03.2015.
 */
public class ProcessingPoint implements InterfacePoint{

    public ArrayList<Point> getPoints(int idMap){return ControllerConnections.getPointController().getPoints(idMap);}

    public void updPoint(ArrayList<Point> points){ControllerConnections.getPointController().updPoint(points);}

    public void setPoints(ArrayList<Point> points){ControllerConnections.getPointController().setPoints(points);}

    public void delPoints(Integer[] ids){ControllerConnections.getPointController().delPoints(ids);}
}
