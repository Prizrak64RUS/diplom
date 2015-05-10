package com.SERV.interfaceAbility;

import com.SERV.view.entity.Event;
import com.SERV.view.entity.Maps;

import java.io.File;
import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceMaps {
    public Maps getMap(int id);
    public ArrayList<Maps> getMaps(Event ev);
    public ArrayList<Maps> getMapsFromActivEvent();
    public ArrayList<Maps> getMaps();
    public void setMap(ArrayList<Maps> map);
    public void sendMapIn(byte[] file, int id);
    public byte[] sendMapOUT(int id);
    public void delMap(ArrayList<Maps> map);
    public void updMap(ArrayList<Maps> map);

}
