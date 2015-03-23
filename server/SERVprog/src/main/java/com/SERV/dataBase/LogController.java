package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceLog;
import com.SERV.view.entity.Log;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public class LogController implements InterfaceLog {
    public void setLog(Log log){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("insert into SOPG.dbo.event values ("+log.getId_user()+", "+log.getId_log_type()+", "+
                    log.getId_event()+", '"+log.getDescription()+"', "+log.getId_point()+", '"+log.getDate()+"');");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public ArrayList<Log> getTreeLogs(int idEvent){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.log;");
            ArrayList<Log> logs = new ArrayList<Log>();
            while (result.next()) {
                Log log =new Log(result.getString("description"),result.getInt("id"),result.getInt("id_user"),result.getInt("id_log_type"),
                        result.getInt("id_events"), result.getInt("id_point"), result.getString("date"));
                logs.add(log);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return logs;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public ArrayList<Log> getTreeLogs(int idEvent, int type){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.log WHERE type="+type+";");
            ArrayList<Log> logs = new ArrayList<Log>();
            while (result.next()) {
                Log log =new Log(result.getString("description"),result.getInt("id"),result.getInt("id_user"),result.getInt("id_log_type"),
                        result.getInt("id_events"), result.getInt("id_point"), result.getString("date"));
                logs.add(log);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return logs;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}
