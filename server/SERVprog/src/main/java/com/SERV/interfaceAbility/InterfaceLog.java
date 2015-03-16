package com.SERV.interfaceAbility;

import com.SERV.view.entity.Log;
import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceLog {
    public void setLog(Log log);
    public ArrayList<Log> getTreeLogs(int idEvent);
    public ArrayList<Log> getTreeLogs(int idEvent, int type);
}
