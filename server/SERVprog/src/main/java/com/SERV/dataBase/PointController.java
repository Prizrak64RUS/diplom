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
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.point where id_map="+idMap+";");
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
    public void updPoint(ArrayList<Point> points){
        for(Point point:points){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                ResultSet result = statement.executeQuery("UPDATE SOPG.[dbo].[point]" +
                        "   SET [name] = " +"'"+point.getName()+"'"+
                        "      ,[type] = " +"'"+point.getType()+"'"+
                        "      ,[x] = " + point.getX() +
                        "      ,[y] = " + point.getY() +
                        "      ,[size_w] = " + point.getSize_w() +
                        "      ,[size_h] = " + point.getSize_h() +
                        "      ,[description] = " +"'"+point.getDescription()+"'"+
                        "      ,[id_map] = " + point.getId_map() +
                        "      ,[isBusy] = " + point.getBusy() +
                        "      ,[id_user_Busy] = " + point.getId_user_Busy() +
                        " WHERE id="+point.getId());
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
    public void setPoints(ArrayList<Point> points){
        for(Point point:points){
        try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                ResultSet result = statement.executeQuery("insert into SOPG.dbo.point values ('"+point.getName()+"', '"+
                        point.getType()+"', "+point.getX()+", "+point.getY()+", "+point.getSize_w()+", "+
                        point.getSize_h()+", '"+point.getDescription()+"', "+point.getId_map()+", "+
                        point.getBusy()+", "+point.getId_user_Busy()+");");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void delPoints(Integer[] ids){
        for(Integer id: ids){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();

                Statement statement = conn.createStatement();
                ResultSet result = statement.executeQuery("DELETE FROM SOPG.dbo.point where id="+id+";");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
}
