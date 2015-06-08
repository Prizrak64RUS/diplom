package com.SERV.dataBase;

import com.SERV.dataBase.ConnectionPool;
import com.SERV.interfaceAbility.InterfaceGroup;
import com.SERV.view.entity.Busy;
import com.SERV.view.entity.Group;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

/**
 * Created by prizrak on 29.05.2015.
 */
public class GroupController implements InterfaceGroup {
    @Override
    public int setGroup(Group g) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            String loc = g.getLocation();
            loc=loc.toLowerCase();
            loc = loc.substring(0, 1).toUpperCase() + loc.substring(1);

            statement.execute("INSERT INTO [SOPG].[dbo].[group]" +
                    "           ([idEvent]" +
                    "           ,[number_child]" +
                    "           ,[numberResponsible]" +
                    "           ,[numberOverall]" +
                    "           ,[responsible]" +
                    "           ,[school]" +
                    "           ,[location]" +
                    "           ,[date_start]"+
                    "           ,[groupExist])" +
                    "     VALUES" +
                    "           (" +g.getIdEvent() +
                    "           ," +g.getNumber_child()+
                    "           ," +g.getNumberResponsible()+
                    "           ," +g.getNumberOverall()+
                    "           ,'" +g.getResponsible()+"'"+
                    "           ,'" +g.getSchool()+"'"+
                    "           ,'" +loc+"'"+
                    "           ,GETDATE()" +
                    "           ,"+g.getGroupExist()+");");

            statement = conn.createStatement();
            ResultSet rs = statement.executeQuery("SELECT  max(id) id FROM [SOPG].[dbo].[group]");
            ConnectionPool.getConnectionPool().putback(conn);
            if(rs.next())
                return rs.getInt(1);

        } catch (SQLException e) {
            e.printStackTrace();
            return 0;
        }
        return  0;
    }

    @Override
    public boolean updGroup(Group g) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "  FROM [SOPG].[dbo].[group]" +
                    "  WHERE idEvent=" +g.getIdEvent()+
                    "  AND groupExist="+g.getGroupExist()+";");
            int id=0;
            if(result.next())
            {
                id = result.getInt("id");
            }
            if(id!=0){
                setGroup(new Group(0,g.getIdEvent(),0,0,0,"","","","",0));
                updGroup(g);
                return true;
            }
            statement = conn.createStatement();
            statement.execute("UPDATE [dbo].[group]" +
                    "   SET " +
                    "   [number_child]=[number_child]+1"+
                    "  WHERE idEvent=" +g.getIdEvent()+
                    "  AND groupExist=0;");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
        return  true;
    }

    @Override
    public Group getGroup(Integer val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[idEvent]" +
                    "      ,[number_child]" +
                    "      ,[numberResponsible]" +
                    "      ,[numberOverall]" +
                    "      ,[responsible]" +
                    "      ,[school]" +
                    "      ,[location]" +
                    "      ,[date_start]" +
                    "      ,[groupExist]" +
                    "   FROM [SOPG].[dbo].[group]" +
                    "  WHERE [id]=" +val);
            if (result.next()) {
                Group g= new Group(result.getInt("id"),result.getInt("idEvent"),result.getInt("number_child"),result.getInt("numberResponsible"),
                        result.getInt("numberOverall"),result.getString("responsible"),result.getString("school"),result.getString("location"),
                        result.getString("date"),result.getInt("groupExist"));
                ConnectionPool.getConnectionPool().putback(conn);
                return g;
            }
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public boolean endGroup(Integer val) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("UPDATE [dbo].[group]" +
                    "   SET " +
                    "   [date_end]=GETDATE()"+
                    "  WHERE id=" +val+";");
            System.out.println(val);
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
            return false;
        }
        return  true;
    }
}
