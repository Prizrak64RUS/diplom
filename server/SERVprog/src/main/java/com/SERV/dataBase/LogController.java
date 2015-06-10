package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceLog;
import com.SERV.view.entity.Group;
import com.SERV.view.entity.Log;
import com.SERV.view.entity.Message;
import com.SERV.view.entity.News;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public class LogController implements InterfaceLog {
    public ArrayList<Message> getTreeLogsChat(Integer[] val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT top(20) [id]" +
                    "      ,[idUserTo]" +
                    "      ,[message]" +
                    "      ,[idUser]" +
                    "      ,[idEvent]" +
                    "      ,[Date]" +
                    "  FROM [SOPG].[dbo].[message]" +
                    "  WHERE [idEvent]=" +val[0]+
                    "  AND [id]>" +val[1]+
                    "  ORDER BY [id];");
            ArrayList<Message> ms = new ArrayList<Message>();
            while (result.next()) {
                Message m = new Message(result.getInt("id"), result.getString("message"), result.getInt("idUser"), result.getInt("idUserTo"), result.getString("Date"), result.getInt("idEvent"));
                ms.add(m);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return ms;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public ArrayList<News> getTreeLogsNews(Integer[] val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT top(20) [id]" +
                    "      ,[id_event]" +
                    "      ,[description]" +
                    "      ,[date_write]" +
                    "      ,[date_news]" +
                    "      ,[id_map]" +
                    "  FROM [SOPG].[dbo].[news]" +
                    "  WHERE [id_event]=" +val[0]+
                    "  AND [id]>" +val[1]+
                    "  ORDER BY [id];");
            ArrayList<News> ms = new ArrayList<News>();
            while (result.next()) {
                News m = new News(result.getInt("id"), result.getInt("id_event"), result.getString("description"), result.getString("date_write"));
                ms.add(m);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return ms;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public ArrayList<Log> getTreeLogsPoint(Integer[] val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT top(20) [id]" +
                    "      ,[id_user]" +
                    "      ,[log_type]" +
                    "      ,[id_events]" +
                    "      ,[description]" +
                    "      ,[id_point]" +
                    "      ,[id_map]"+
                    "      ,[date]" +
                    "  FROM [SOPG].[dbo].[log]" +
                    "  WHERE [id_events]=" +val[0]+
                    "  AND [id]>" +val[1]+
                    "  ORDER BY [id];");
            ArrayList<Log> logs = new ArrayList<Log>();
            while (result.next()) {
                Log log =new Log(result.getString("description"),result.getInt("id"),result.getInt("id_user"),result.getString("log_type"),
                        result.getInt("id_events"), result.getInt("id_point"),result.getInt("id_map"), result.getString("date"));
                logs.add(log);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return logs;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void setLog(Log log){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("INSERT INTO [dbo].[log]" +
                    "           ([id_user]" +
                    "           ,[log_type]" +
                    "           ,[id_events]" +
                    "           ,[description]" +
                    "           ,[id_point]" +
                    "           ,[id_map]" +
                    "           ,[date])" +
                    "     VALUES" +
                    "           (" +log.getId_user()+
                    "           ,'" +log.getLog_type()+"'"+
                    "           ," +log.getId_events()+
                    "           ,'" +log.getDescription()+"'"+
                    "           ," +log.getId_point()+
                    "           ," +log.getId_map()+
                    "           ,GETDATE())");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public ArrayList<Group> getTreeLogsGroup(Integer[] val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[idEvent]" +
                    "      ,[number_child]" +
                    "      ,[numberResponsible]" +
                    "      ,[numberOverall]" +
                    "      ,[responsible]" +
                    "      ,[school]" +
                    "      ,[location]" +
                    "      ,[date_start]" +
                    "      ,[date_end]" +
                    "      ,[groupExist]" +
                    "   FROM [SOPG].[dbo].[group]" +
                    "  WHERE [idEvent]=" +val[0]+
                    "  ORDER BY [location];");
            ArrayList<Group> logs = new ArrayList<Group>();
            while (result.next()) {
                Group g= new Group(result.getInt("id"),val[0],result.getInt("number_child"),result.getInt("numberResponsible"),
                        result.getInt("numberOverall"),result.getString("responsible"),result.getString("school"),result.getString("location"),
                        result.getString("date_start").substring(0, 5),result.getString("date_end").substring(0,5),result.getInt("groupExist"));
                logs.add(g);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return logs;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    /*
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
    */
}
