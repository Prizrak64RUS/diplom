package com.SERV.interfaceAbility;

import com.SERV.view.entity.Group;
import com.SERV.view.entity.Log;
import com.SERV.view.entity.Message;
import com.SERV.view.entity.News;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceLog {
/*

    public ArrayList<Log> getTreeLogs(int idEvent);
    public ArrayList<Log> getTreeLogs(int idEvent, int type);
    */
    public void setLog(Log log);

    public ArrayList<Message> getTreeLogsChat(Integer[] val);
    public ArrayList<News> getTreeLogsNews(Integer[] val);
    public ArrayList<Log> getTreeLogsPoint(Integer[] val);
    public ArrayList<Group> getTreeLogsGroup(Integer[] val);
}
