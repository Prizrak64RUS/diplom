package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceBusy;
import com.SERV.interfaceAbility.InterfacePoint;
import com.SERV.view.entity.Log;
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
     static String NEXT = "NEXT";
     static String INFO = "INFO";
     static String PORTER_POSITION = "PORTER_POSITION";

    public ArrayList<Point> getPoints(Object[] val){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            String query = "SELECT * FROM SOPG.dbo.point where id_map="+val[1]+" ";
            switch (UserRole.valueOf((String)val[0])){
                case ADMIN:
                case WATCHING:
                case GUIDES:
                    query+="AND type <> '"+PORTER_POSITION+"';";
                    break;
                case HEAD:
                    query+=";";
                    break;
            }
            ResultSet result = statement.executeQuery(query);
            ArrayList<Point> pointList = new ArrayList<Point>();
            while (result.next()) {
                Point point = new Point(result.getString("name"), result.getString("type"), result.getFloat("x"), result.getFloat("y"),
                        result.getFloat("size_w"), result.getFloat("size_h"),  result.getString("description"),
                        result.getInt("id_map"), result.getInt("isBusy"), result.getInt("id_user_Busy"), result.getInt("all_space"), result.getInt("id"), result.getInt("free_space"));
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
                        "      ,[all_space]=" + point.getAll_space()+
                        "      ,[free_space]="+point.getAll_space()+
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
                        point.getBusy()+", "+point.getId_user_Busy()+", "+point.getAll_space()+", "+point.getAll_space()+");");
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

    public boolean busyNotPoint(Point point) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("UPDATE SOPG.[dbo].[point]" +
                    "   SET [isBusy] = 0"+
                    "      ,[id_user_Busy] = 0"+
                    " WHERE id="+point.getId());
            ConnectionPool.getConnectionPool().putback(conn);
//
//            int id = 0;
//            int id_user = point.getId_user_Busy();
//            String log_type= "\u0414\u0435\u0437\u0430\u043a\u0442\u0438\u0432\u0430\u0446\u0438\u044f \u0442\u043e\u0447\u043a\u0438 " +point.getType();
//            int id_events = new EventController().getEventActiv().getId();
//            int id_point=point.getId();
//            int id_map=point.getId_map();
//            String description=point.getName() +" \n "+ point.getDescription();
//
//            Log log = new Log(description,id,id_user,log_type,id_events,id_point,id_map);
//            new LogController().setLog(log);
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
        return true;
    }
    public boolean busyPoint(Point point) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();

            String query = "SELECT * FROM SOPG.dbo.point where id="+point.getId();
            ResultSet result = statement.executeQuery(query);
            while (result.next()) {
                if(1==result.getInt("isBusy")) return false;
            }

            statement = conn.createStatement();
            statement.execute("UPDATE SOPG.[dbo].[point]" +
                    "   SET [isBusy] = " + point.getBusy() +
                    "      ,[id_user_Busy] = " + point.getId_user_Busy() +
                    " WHERE id="+point.getId());
            ConnectionPool.getConnectionPool().putback(conn);
//
//
//            int id = 0;
//            int id_user = point.getId_user_Busy();
//            String log_type= "\u0410\u043a\u0442\u0438\u0432\u0430\u0446\u0438\u044f \u0442\u043e\u0447\u043a\u0438 " +point.getType();
//            int id_events = new EventController().getEventActiv().getId();
//            int id_point=point.getId();
//            int id_map=point.getId_map();
//            String description=point.getName() +" \n "+ point.getDescription();
//
//            Log log = new Log(description,id,id_user,log_type,id_events,id_point,id_map);
//            new LogController().setLog(log);
            return true;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }

    }
    public boolean updateBusyPoint(Point point) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("UPDATE SOPG.[dbo].[point]" +
                    "   SET [type] = '"+point.getType()+"'"+

                    "      ,[name] = '" + point.getName() +"'"+
                    "      ,[description] = '" + point.getDescription() +"'"+

                    "      ,[x] = " + point.getX() +
                    "      ,[y] = " + point.getY() +
                    "      ,[size_w] = " + point.getSize_w() +
                    "      ,[size_h] = " + point.getSize_h() +
                    " WHERE id="+point.getId());
            ConnectionPool.getConnectionPool().putback(conn);
//
//            String description="";
//            int id = 0;
//            int id_user = point.getId_user_Busy();
//            String log_type= "\u0418\u0437\u043c\u0435\u043d\u0435\u043d\u0438\u0435 \u0442\u043e\u0447\u043a\u0438 " +point.getType();
//            int id_events = new EventController().getEventActiv().getId();
//            int id_point=point.getId();
//            int id_map=point.getId_map();
//
//            if (point.getType().equals(GROUP)) {
//                description=point.getName() +" \n "+ point.getDescription();
//            } else {
//            }
//            Log log = new Log(description,id,id_user,log_type,id_events,id_point,id_map);
//            new LogController().setLog(log);
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
        return true;
    }
    public boolean delBusyPoint(Point point) {
        try {
            Connection conn = ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            statement.execute("DELETE FROM SOPG.dbo.point where id=" + point.getId() + ";");
            statement = conn.createStatement();
            statement.execute("DELETE FROM [SOPG].[dbo].[busy]" +
                    "      WHERE idPoint=" + point.getId() + ";");
            ConnectionPool.getConnectionPool().putback(conn);

//            String description;
//            int id = 0;
//            int id_user = point.getId_user_Busy();
//            String log_type;
//            int id_events = new EventController().getEventActiv().getId();
//            int id_point=point.getId();
//            int id_map=point.getId_map();
//
//            if (point.getType().equals(GROUP)&&point.getBusy()==1) {
//                log_type= "\u041f\u0440\u0438\u043d\u044f\u0442\u0438\u0435 \u0433\u0440\u0443\u043f\u043f\u044b " +point.getName();
//                description=point.getDescription();
//            } else {
//                log_type= "\u0423\u0434\u0430\u043b\u0435\u043d\u0438\u0435 \u0442\u043e\u0447\u043a\u0438 " +point.getType();
//                description=point.getName()+" \n "+point.getDescription();
//            }
//            Log log = new Log(description,id,id_user,log_type,id_events,id_point,id_map);
//            new LogController().setLog(log);

            }catch(SQLException e){
                e.printStackTrace();
                return false;
            }
        return true;
    }
    public boolean setBusyPoint(Point point) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            statement.execute(("insert into SOPG.dbo.point values ('"+point.getName()+"', '"+
                    point.getType()+"', "+point.getX()+", "+point.getY()+", "+point.getSize_w()+", "+
                    point.getSize_h()+", '"+point.getDescription()+"', "+point.getId_map()+", "+
                    point.getBusy()+", "+point.getId_user_Busy()+",0,0);"));
            ConnectionPool.getConnectionPool().putback(conn);

//            String description="";
//            int id = 0;
//            int id_user = point.getId_user_Busy();
//            String log_type= "\u0421\u043e\u0437\u0434\u0430\u043d\u0438\u0435 \u0442\u043e\u0447\u043a\u0438 " +point.getType();
//            int id_events = new EventController().getEventActiv().getId();
//            int id_point=point.getId();
//            int id_map=point.getId_map();
//
//            if (point.getType().equals(GROUP)) {
//                description=point.getName() +" \n "+ point.getDescription();
//            } else {
//            }
//            Log log = new Log(description,id,id_user,log_type,id_events,id_point,id_map);
//            new LogController().setLog(log);
        } catch (SQLException e) {
            e.printStackTrace();
            return  false;
        }
        return true;
    }

    public Point getPoint(int id) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.point where id="+id+";");
            ArrayList<Point> pointList = new ArrayList<Point>();
            if (result.next()) {
                Point point = new Point(result.getString("name"), result.getString("type"), result.getFloat("x"), result.getFloat("y"),
                        result.getFloat("size_w"), result.getFloat("size_h"),  result.getString("description"),
                        result.getInt("id_map"), result.getInt("isBusy"), result.getInt("id_user_Busy"), result.getInt("all_space"), result.getInt("id"), result.getInt("free_space"));
                ConnectionPool.getConnectionPool().putback(conn);
                return point;
            }
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public Point setPoints(Point point){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("insert into SOPG.dbo.point values ('"+point.getName()+"', '"+
                    point.getType()+"', "+point.getX()+", "+point.getY()+", "+point.getSize_w()+", "+
                    point.getSize_h()+", '"+point.getDescription()+"', "+point.getId_map()+", "+
                    point.getBusy()+", "+point.getId_user_Busy()+", "+point.getAll_space()+", "+point.getAll_space()+");");

            statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT max(id) id FROM SOPG.dbo.point;");
            if (result.next()) {
                point.setId(result.getInt(1));
                ConnectionPool.getConnectionPool().putback(conn);
                return point;
            }
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
    public boolean delPoints(Point point) {
        try {
            Connection conn = ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            statement.execute("DELETE FROM SOPG.dbo.point where id=" + point.getId() + ";");
            ConnectionPool.getConnectionPool().putback(conn);
            return  true;
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
    }

    public boolean updFree_space(Object[] val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("UPDATE SOPG.[dbo].[point]" +
                    "   SET [free_space] = "+val[1]+
                    " WHERE id="+val[0]);
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
        return true;
    }
}
