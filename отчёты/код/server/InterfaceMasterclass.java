package com.SERV.interfaceAbility;

import com.SERV.view.entity.Masterclass;

import java.util.ArrayList;

/**
 * Created by prizrak on 02.06.2015.
 */
public interface InterfaceMasterclass {
    public ArrayList<Masterclass> getMasterclass(Integer val);
    public ArrayList<Masterclass> getMasterclass();
    public void updMasterclass(ArrayList<Masterclass> arr);
    public void setMasterclass(ArrayList<Masterclass> arr);
    public void delMasterclass(ArrayList<Masterclass> arr);

    public Masterclass getMC(Integer id);
}
