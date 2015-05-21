package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceMaps;
import com.SERV.view.entity.Event;
import com.SERV.view.entity.Maps;

import java.io.*;
import java.sql.*;
import java.util.ArrayList;

/**
 * Created by prizrak on 25.11.2014.
 */
public class MapsController implements InterfaceMaps{

/*
    try {
        Connection conn =  ConnectionPool.getConnectionPool().retrieve();

        Statement statement = conn.createStatement();
        ResultSet result = statement.executeQuery("SELECT * FROM maps where id_event="+idEvent+";");
        while (result.next()) {
        }
        ConnectionPool.getConnectionPool().putback(conn);
    } catch (SQLException e) {
        e.printStackTrace();
    }
 */

    public ArrayList<Maps> getMapsFromActivEvent(){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT maps.id, maps.name, maps.id_event, maps.description  " +
                    "FROM SOPG.dbo.maps, SOPG.dbo.event WHERE maps.id_event = event.id AND event.isActiv=1;");
            ArrayList<Maps> mapsList = new ArrayList<Maps>();
            while (result.next()) {
                Maps maps = new Maps(result.getString("name"), result.getInt("id_event"), result.getString("description"), result.getInt("id"));
                mapsList.add(maps);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return mapsList;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public Maps getMap(int id){

    try {
        Connection conn =  ConnectionPool.getConnectionPool().retrieve();

        Statement statement = conn.createStatement();
        ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.maps where id="+id+";");
        Maps maps=null;
        while (result.next()) {
            maps = new Maps(result.getString("name"), result.getInt("id_event"), result.getString("description"), result.getInt("id"));
            break;
        }
        ConnectionPool.getConnectionPool().putback(conn);
        return  maps;
    } catch (SQLException e) {
        e.printStackTrace();
    }
        return null;
    }


    public ArrayList<Maps> getMaps(Event ev){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.maps where id_event="+ev.getId()+";");
            ArrayList<Maps> mapsList = new ArrayList<Maps>();
            while (result.next()) {
                Maps maps = new Maps(result.getString("name"), ev.getId(), result.getString("description"), result.getInt("id"));
                mapsList.add(maps);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return mapsList;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public ArrayList<Maps> getMaps(){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.maps;");
            ArrayList<Maps> mapsList = new ArrayList<Maps>();
            while (result.next()) {
                Maps maps = new Maps(result.getString("name"), result.getInt("id_event"), result.getString("description"), result.getInt("id"));
                mapsList.add(maps);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return mapsList;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void setMap(ArrayList<Maps> map){
        for(Maps m: map) {
            try {
                Connection conn = ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("insert into SOPG.dbo.maps (name, id_event, description) values ('" + m.getName() + "', " + m.getId_event() + ", '" +
                        m.getDescription() + "');");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
    public void sendMapIn(byte[] file, int id){
        saveFile(file,id);
       // try {
            //Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            //Statement statement = conn.createStatement();
           // statement.execute("UPDATE SOPG.dbo.maps set image="+arr+" WHERE id="+id+";");
            //ConnectionPool.getConnectionPool().putback(conn);
       //} catch (SQLException e) {
      //      e.printStackTrace();
      //  }
    }
    public byte[] sendMapOUT(int id){
        return getFile(id);
//        try {
//            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
//
//            Statement statement = conn.createStatement();
//            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.maps where id="+id+";");
//            while (result.next()) {
//                byte[] b = result.getBytes("image");
//                return b;
//            }
//            ConnectionPool.getConnectionPool().putback(conn);
//        } catch (SQLException e) {
//            e.printStackTrace();
//        }
//        return null;
    }

    public void delMap(ArrayList<Maps> map){
        for(Maps m: map){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("DELETE FROM SOPG.dbo.maps where id="+m.getId()+";");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void updMap(ArrayList<Maps> map){
        for(Maps m: map){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                statement.execute("UPDATE [SOPG].[dbo].[maps]" +
                        "   SET [name] = '"+m.getName()+"'" +
                        "      ,[id_event] = "+m.getId_event()+
                        "      ,[description] = '"+m.getDescription()+"'"+
                        " WHERE id="+m.getId()+";");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public  long mapSize(int id){
        String patch = System.getProperty("user.home");
        patch+="\\sopg\\";
        patch+=id;
        try {
            File f = new File(patch);
            long len = f.length();
            return len;
        } catch (Exception e){
            return 0;
        }
    }

    private  void saveFile(byte[] file, int id){
        String patch = System.getProperty("user.home");
        patch+="\\sopg\\";
        try {
            File myPath = new File(patch);
            myPath.mkdirs();
            patch+=id;
            FileOutputStream fos = new FileOutputStream(patch);
            fos.write(file);
            fos.close();
        } catch (Exception e){e.printStackTrace();}
    }
    private   byte[] getFile(int id){
        String patch = System.getProperty("user.home");
        patch+="\\sopg\\";
        try {
            patch+=id;
            FileInputStream fin =  new FileInputStream(patch);
            byte[] buffer = new byte[fin.available()];
            fin.read(buffer, 0, fin.available());
            fin.close();
            return buffer;
        } catch (Exception e){}
        return new byte[0];
    }
}
