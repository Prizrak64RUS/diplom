package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceMasterclass;
import com.SERV.view.entity.Masterclass;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 02.06.2015.
 */
public class MasterclassController implements InterfaceMasterclass{

    public ArrayList<Masterclass> getMasterclass(Integer val) {
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();

                Statement statement = conn.createStatement();
                ResultSet result = statement.executeQuery("SELECT [id]" +
                        "      ,[id_event]" +
                        "      ,[name]" +
                        "      ,[decription]" +
                        "      ,[lecturer1]" +
                        "      ,[lecturer2]" +
                        "      ,[lecturer3]" +
                        "  FROM [SOPG].[dbo].[masterclass]" +
                        "   WHERE id_event="+val);
                ArrayList<Masterclass> list = new ArrayList<Masterclass>();
                while (result.next()) {
                    Masterclass obj = new Masterclass(result.getInt("id"),result.getInt("id_event"),result.getString("name"),
                            result.getString("decription"),result.getString("lecturer1"),result.getString("lecturer2"),result.getString("lecturer3"));
                    list.add(obj);
                }
                ConnectionPool.getConnectionPool().putback(conn);
                return list;
            } catch (SQLException e) {
                e.printStackTrace();
            }
            return null;
    }

    public ArrayList<Masterclass> getMasterclass() {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();

            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[id_event]" +
                    "      ,[name]" +
                    "      ,[decription]" +
                    "      ,[lecturer1]" +
                    "      ,[lecturer2]" +
                    "      ,[lecturer3]" +
                    "  FROM [SOPG].[dbo].[masterclass]");
            ArrayList<Masterclass> list = new ArrayList<Masterclass>();
            while (result.next()) {
                Masterclass obj = new Masterclass(result.getInt("id"),result.getInt("id_event"),result.getString("name"),
                        result.getString("decription"),result.getString("lecturer1"),result.getString("lecturer2"),result.getString("lecturer3"));
                list.add(obj);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return list;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void updMasterclass(ArrayList<Masterclass> arr) {
        for(Masterclass obj:arr){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("UPDATE [SOPG].[dbo].[masterclass]" +
                        "   SET [name] ='" + obj.getName()+"'"+
                        "      ,[decription] ='" +obj.getDecription()+"'"+
                        "      ,[lecturer1] = '" +obj.getLecturer1()+"'"+
                        "      ,[lecturer2] = '" +obj.getLecturer2()+"'"+
                        "      ,[lecturer3] ='" +obj.getLecturer3()+"'"+
                        " WHERE id="+obj.getId());
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void setMasterclass(ArrayList<Masterclass> arr) {
        for(Masterclass obj:arr){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("INSERT INTO [SOPG].[dbo].[masterclass]" +
                        "           ([id_event]" +
                        "           ,[name]" +
                        "           ,[decription]" +
                        "           ,[lecturer1]" +
                        "           ,[lecturer2]" +
                        "           ,[lecturer3])" +
                        "     VALUES(" + obj.getId_event()+
                        "   ,'" + obj.getName()+"'"+
                        "   ,'" +obj.getDecription()+"'"+
                        "   ,'" +obj.getLecturer1()+"'"+
                        "   ,'" +obj.getLecturer2()+"'"+
                        "   ,'" +obj.getLecturer3()+"')");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void delMasterclass(ArrayList<Masterclass> arr) {
        for(Masterclass obj:arr){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("DELETE FROM [SOPG].[dbo].[masterclass]"+
                        " WHERE id="+obj.getId());
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public Masterclass getMC(Integer id) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();

            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[id_event]" +
                    "      ,[name]" +
                    "      ,[decription]" +
                    "      ,[lecturer1]" +
                    "      ,[lecturer2]" +
                    "      ,[lecturer3]" +
                    "  FROM [SOPG].[dbo].[masterclass]" +
                    "   WHERE id="+id);
            if (result.next()) {
                Masterclass obj = new Masterclass(result.getInt("id"),result.getInt("id_event"),result.getString("name"),
                        result.getString("decription"),result.getString("lecturer1"),result.getString("lecturer2"),result.getString("lecturer3"));
                ConnectionPool.getConnectionPool().putback(conn);
                return  obj;
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return null;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}
