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

    public ArrayList<Maps> getMaps(int idEvent){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM maps where id_event="+idEvent+";");
            ArrayList<Maps> mapsList = new ArrayList<Maps>();
            while (result.next()) {
                Maps maps = new Maps(result.getString("name"), idEvent, result.getString("description"),
                        result.getString("path"), result.getInt("id"));
                mapsList.add(maps);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return mapsList;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public void setMap(Maps map){}
    public void sendMapIn(File file){}
    public File sendMapOUT(){return  null;}
    public void delMap(int id){}
}
