package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfacePoint;
import com.SERV.view.entity.Point;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

/**
 * Created by prizrak on 20.01.2015.
 */
public class PointController implements InterfacePoint {
    public ArrayList<Point> getPoints(int idMap){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM point where id_map="+idMap+";");
            ArrayList<Point> pointList = new ArrayList<Point>();
            while (result.next()) {
                Point point = new Point(result.getString("name"), result.getString("type"), result.getFloat("x"), result.getFloat("y"),
                        result.getFloat("size_w"), result.getFloat("size_h"),  result.getString("description"),
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
    public void setPoint(Point point){}
    public void setPoints(ArrayList<Point> points){}
    public void delPoints(Integer[] ids){}
}
