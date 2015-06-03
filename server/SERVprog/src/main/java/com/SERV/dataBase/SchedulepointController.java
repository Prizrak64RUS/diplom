package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceSchedulepoint;
import com.SERV.view.entity.Schedulepoint;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 02.06.2015.
 */
public class SchedulepointController implements  InterfaceSchedulepoint{
    public ArrayList<Schedulepoint> getSchedulepoint(Integer val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();

            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[id_masterclass]" +
                    "      ,[id_point]" +
                    "      ,[date_start]" +
                    "      ,[time_start]" +
                    "      ,[time_end]" +
                    "  FROM [SOPG].[dbo].[schedulepoint]" +
                    "   WHERE id_point="+val);
            ArrayList<Schedulepoint> list = new ArrayList<Schedulepoint>();
            while (result.next()) {
                Schedulepoint obj = new Schedulepoint(result.getInt("id"),result.getInt("id_masterclass"),result.getInt("id_point"),
                        result.getString("date_start"),result.getString("time_start").substring(0,5),result.getString("time_end").substring(0, 5));
                list.add(obj);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return list;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public ArrayList<Schedulepoint> getSchedulepoint() {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();

            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[id_masterclass]" +
                    "      ,[id_point]" +
                    "      ,[date_start]" +
                    "      ,[time_start]" +
                    "      ,[time_end]" +
                    "  FROM [SOPG].[dbo].[schedulepoint]");
            ArrayList<Schedulepoint> list = new ArrayList<Schedulepoint>();
            while (result.next()) {
                Schedulepoint obj = new Schedulepoint(result.getInt("id"),result.getInt("id_masterclass"),result.getInt("id_point"),
                        result.getString("date_start"),result.getString("time_start").substring(0,5),result.getString("time_end").substring(0,5));
                list.add(obj);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return list;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void setSchedulepoint(ArrayList<Schedulepoint> arr) {
        for(Schedulepoint obj:arr){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("INSERT INTO [SOPG].[dbo].[schedulepoint]" +
                        "           ([id_masterclass]" +
                        "           ,[id_point]" +
                        "      ,[date_start]" +
                        "      ,[time_start]" +
                        "      ,[time_end])" +
                        "     VALUES(" +obj.getId_masterclass()+
                        "           ," +obj.getId_point()+
                        "           ,'" +obj.getDate_start()+"'"+
                        "           ,'"+obj.getTime_start()+"'"+
                        "           ,'"+obj.getTime_end()+"')");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void updSchedulepoint(ArrayList<Schedulepoint> arr) {
        for(Schedulepoint obj:arr){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("UPDATE [SOPG].[dbo].[schedulepoint]" +
                        "   SET [id_masterclass] =" +obj.getId_masterclass()+
                        "      ,[id_point] =" +obj.getId_point()+
                        "      ,[date_start] ='" +obj.getDate_start()+"'"+
                        "      ,[time_start]='" +obj.getTime_start()+"'"+
                        "      ,[time_end]='" +obj.getTime_end()+"'"+
                        " WHERE id="+obj.getId());
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void delSchedulepoint(ArrayList<Schedulepoint> arr) {
        for(Schedulepoint obj:arr){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("DELETE FROM  [SOPG].[dbo].[schedulepoint]" +
                        " WHERE id="+obj.getId());
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public Schedulepoint getSP(Integer id) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();

            ResultSet result = statement.executeQuery("SELECT [id]\n" +
                    "      ,[id_masterclass]" +
                    "      ,[id_point]" +
                    "      ,[date_start]" +
                    "      ,[time_start]" +
                    "      ,[time_end]" +
                    "  FROM [SOPG].[dbo].[schedulepoint]" +
                    "   WHERE id="+id);
            if (result.next()) {
                Schedulepoint obj = new Schedulepoint(result.getInt("id"),result.getInt("id_masterclass"),result.getInt("id_point"),
                        result.getString("date_start"),result.getString("time_start"),result.getString("time_end"));
                ConnectionPool.getConnectionPool().putback(conn);
                return obj;
            }
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}
