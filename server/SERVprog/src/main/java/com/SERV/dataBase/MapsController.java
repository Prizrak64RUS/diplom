package com.SERV.dataBase;

import com.SERV.view.entity.Maps;
import com.SERV.view.entity.Point;
import com.SERV.view.entity.User;
import com.SERV.view.entity.UserRole;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by prizrak on 25.11.2014.
 */
public class MapsController {
    public List<Point> getPoint(int idMap){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM point where id_map="+idMap+";");
            List<Point> pointList = new ArrayList<Point>();
            while (result.next()) {
                Point point = new Point(result.getString("name"), result.getString("type"), result.getInt("x"), result.getInt("y"),
                        result.getInt("size_w"), result.getInt("size_h"),  result.getString("description"),
                        idMap, result.getInt("isBusy"), result.getInt("id_user_Busy"), result.getInt("id"));
                pointList.add(point);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return pointList;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public List<Maps> getAllMaps(int idEvent){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM maps where id_event="+idEvent+";");
            List<Maps> mapsList = new ArrayList<Maps>();
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
}
