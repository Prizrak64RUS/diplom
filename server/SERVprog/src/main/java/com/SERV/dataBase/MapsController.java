package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceMaps;
import com.SERV.view.entity.Maps;
import com.SERV.view.entity.Point;

import java.io.File;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

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


    public ArrayList<Maps> getMaps(int idEvent){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.maps where id_event="+idEvent+";");
            ArrayList<Maps> mapsList = new ArrayList<Maps>();
            while (result.next()) {
                Maps maps = new Maps(result.getString("name"), idEvent, result.getString("description"), result.getInt("id"));
                mapsList.add(maps);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return mapsList;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public void setMap(Maps map){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("insert into SOPG.dbo.maps values ('"+map.getName()+"', "+map.getId_event()+", '"+
                    map.getDescription()+"');");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public void sendMapIn(byte[] file, String name){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("UPDATE SOPG.dbo.maps set image="+file+" WHERE name='"+name+"'");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public byte[] sendMapOUT(int id){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.maps where id="+id+";");
            while (result.next()) {
                byte[] b = result.getBytes("image");
                return b;
            }
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void delMap(int id){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("DELETE FROM SOPG.dbo.maps where id="+id+";");
            ArrayList<Maps> mapsList = new ArrayList<Maps>();
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
