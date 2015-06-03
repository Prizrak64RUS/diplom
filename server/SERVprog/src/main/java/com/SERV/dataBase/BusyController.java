package com.SERV.dataBase;

import com.SERV.dataBase.ConnectionPool;
import com.SERV.interfaceAbility.InterfaceBusy;
import com.SERV.view.entity.Busy;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 19.05.2015.
 */
public class BusyController implements InterfaceBusy {
    @Override
    public void setBusy(Busy b) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            statement.execute("INSERT INTO [SOPG].[dbo].[busy]" +
                    "           ([idUser]" +
                    "           ,[idPoint]" +
                    "           ,[idGroup])" +
                    "     VALUES" +
                    "           (" +b.getIdUser()+
                    "           ," +b.getIdPoint()+
                    "           ,"+b.getIdGroup()+")");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public Busy[] isBusy(Busy b) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            String query ="SELECT [id]" +
                    "      ,[idUser]" +
                    "      ,[idPoint]" +
                    "      ,[idGroup]" +
                    "  FROM [SOPG].[dbo].[busy] ";
            if(b.getIdUser()==0){
                query+=" WHERE idGroup="+b.getIdGroup()+";";
            }else {
                query+=" WHERE idUser="+b.getIdUser()+";";
            }
            ResultSet result = statement.executeQuery(query);
            ArrayList<Busy> arr= new ArrayList<Busy>();
            while (result.next()) {
                Busy busy = new Busy(result.getInt("id"), result.getInt("idUser"), result.getInt("idPoint"), result.getInt("idGroup"));
                arr.add(busy);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return ((Busy[])arr.toArray());
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void delBusy(Busy b) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            String query = "DELETE FROM [SOPG].[dbo].[busy]";
            if(b.getIdPoint()==0){
                query+=" WHERE idGroup="+b.getIdGroup()+";";
            }else {
                query+=" WHERE idPoint="+b.getIdPoint()+";";
            }
            Statement statement = conn.createStatement();
            statement.execute(query);
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
