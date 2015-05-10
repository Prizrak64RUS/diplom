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

    public ArrayList<Maps> getMaps(Event ev){return ControllerConnections.getMapsController().getMaps(ev);}
    public ArrayList<Maps> getMaps(){return ControllerConnections.getMapsController().getMaps();}
    public ArrayList<Maps> getMapsFromActivEvent(){
        return ControllerConnections.getMapsController().getMapsFromActivEvent();
    }

    public Maps getMap(int id){ return ControllerConnections.getMapsController().getMap(id);}

    public void setMap(ArrayList<Maps> map){ControllerConnections.getMapsController().setMap(map);}

    public void sendMapIn(byte[] file, int id){ControllerConnections.getMapsController().sendMapIn(file, id);}

    public byte[] sendMapOUT(int id){return ControllerConnections.getMapsController().sendMapOUT(id);}

    public void delMap(ArrayList<Maps> map){ControllerConnections.getMapsController().delMap(map);}
    public void updMap(ArrayList<Maps> map){ControllerConnections.getMapsController().updMap(map);}

}
