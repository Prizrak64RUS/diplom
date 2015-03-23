package com.SERV.interfaceAbility;

import com.SERV.view.entity.Maps;

import java.io.File;
import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceMaps {
    public ArrayList<Maps> getMaps(int idEvent);
    public void setMap(Maps map);
    public void sendMapIn(byte[] file, String name);
    public byte[] sendMapOUT(int id);
    public void delMap(int id);

}
