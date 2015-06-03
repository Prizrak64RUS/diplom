package com.SERV.interfaceAbility;

import com.SERV.view.entity.Schedulepoint;

import java.util.ArrayList;

/**
 * Created by prizrak on 02.06.2015.
 */
public interface InterfaceSchedulepoint {

    public ArrayList<Schedulepoint> getSchedulepoint(Integer val);
    public ArrayList<Schedulepoint> getSchedulepoint();
    public void updSchedulepoint(ArrayList<Schedulepoint> arr);
    public void setSchedulepoint(ArrayList<Schedulepoint> arr);
    public void delSchedulepoint(ArrayList<Schedulepoint> arr);

    public Schedulepoint getSP(Integer id);
}
