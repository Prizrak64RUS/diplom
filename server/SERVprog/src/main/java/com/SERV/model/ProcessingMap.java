package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.view.entity.*;

import java.util.List;

/**
 * Created by prizrak on 25.11.2014.
 */
public class ProcessingMap {
    public List<Point> getPoint(int id){
        return ControllerConnections.getMapsController().getPoint(id);
    }

    public List<Maps> getAllMaps(int idEvent){
        return ControllerConnections.getMapsController().getAllMaps(idEvent);
    }
}
