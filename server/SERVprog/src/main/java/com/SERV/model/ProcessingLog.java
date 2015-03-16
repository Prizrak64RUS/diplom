package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceLog;
import com.SERV.view.entity.Log;

import java.util.ArrayList;

/**
 * Created by prizrak on 16.03.2015.
 */
public class ProcessingLog implements InterfaceLog {
    public void setLog(Log log){
        ControllerConnections.getLogController().setLog(log);
    }
    public ArrayList<Log> getTreeLogs(int idEvent){
        return ControllerConnections.getLogController().getTreeLogs(idEvent);
    }
    public ArrayList<Log> getTreeLogs(int idEvent, int type){
        return ControllerConnections.getLogController().getTreeLogs(idEvent, type);
    }
}
