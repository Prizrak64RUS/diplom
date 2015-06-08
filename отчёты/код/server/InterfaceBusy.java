package com.SERV.interfaceAbility;

import com.SERV.view.entity.Busy;

import java.util.ArrayList;

/**
 * Created by prizrak on 19.05.2015.
 */
public interface InterfaceBusy {
    public void setBusy(Busy b);
    public Busy isBusy(Busy b);

    public ArrayList<Busy> getBusys(Busy b);
    public void delBusy(Busy b);
}
