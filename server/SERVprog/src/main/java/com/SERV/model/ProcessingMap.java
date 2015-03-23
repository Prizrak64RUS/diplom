package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceMaps;
import com.SERV.view.entity.*;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by prizrak on 25.11.2014.
 */
public class ProcessingMap implements InterfaceMaps{

    public ArrayList<Maps> getMaps(int idEvent){return ControllerConnections.getMapsController().getMaps(idEvent);}

    public void setMap(Maps map){ControllerConnections.getMapsController().setMap(map);}

    public void sendMapIn(byte[] file, String name){ControllerConnections.getMapsController().sendMapIn(file, name);}

    public byte[] sendMapOUT(int id){return ControllerConnections.getMapsController().sendMapOUT(id);}

    public void delMap(int id){ControllerConnections.getMapsController().delMap(id);}
}
