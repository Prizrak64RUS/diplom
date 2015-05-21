package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfacePoint;
import com.SERV.view.entity.Point;
import com.SERV.view.entity.UserRole;

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

     static String ACTION = "ACTIV";
     static String NOT_ACTION = "NOT_ACTIV";
     static String NEXT = "NEXT";
     static String INFO = "INFO";
     static String SELECTED = "SELECTED";
     static String GROUP = "GROUP";
     static String PORTER_POSITION = "PORTER_POSITION";

    public ArrayList<Point> getPoints(Object[] val){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            String query = "SELECT * FROM SOPG.dbo.point where id_map="+(Integer)val[1];
            switch (UserRole.valueOf((String)val[0])){
                case ADMIN:
                case WATCHING:
                    query+=" AND type in ('"+ACTION+"', '"+NOT_ACTION+"', '"+NEXT+"', '"+INFO+"');";
                    break;
                case GUIDES:
                    query+=" AND type in ('"+ACTION+"', '"+ GROUP +"', '"+NOT_ACTION+"', '"+NEXT+"', '"+INFO+"');";
                    break;
                case HEAD:
                case PORTER:
                    query+=";";
                    break;
            }
            ResultSet result = statement.executeQuery(query);
            ArrayList<Point> pointList = new ArrayList<Point>();
            while (result.next()) {
                Point point = new Point(result.getString("name"), result.getString("type"), result.getFloat("x"), result.getFloat("y"),
                        result.getFloat("size_w"), result.getFloat("size_h"),  result.getString("description"),
                        result.getInt("id_map"), result.getInt("isBusy"), result.getInt("id_user_Busy"), result.getInt("id"));
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
                statement.execute("UPDATE SOPG.[dbo].[point]" +
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
                statement.execute("insert into SOPG.dbo.point values ('"+point.getName()+"', '"+
                        point.getType()+"', "+point.getX()+", "+point.getY()+", "+point.getSize_w()+", "+
                        point.getSize_h()+", '"+point.getDescription()+"', "+point.getId_map()+", "+
                        point.getBusy()+", "+point.getId_user_Busy()+");");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }

    public void delPoints(ArrayList<Point> points){
        for(Point p: points){
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();

                Statement statement = conn.createStatement();
                statement.execute("DELETE FROM SOPG.dbo.point where id="+p.getId()+";");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
}
