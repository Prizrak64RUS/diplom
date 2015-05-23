package com.SERV.dataBase;

import com.SERV.dataBase.ConnectionPool;
import com.SERV.interfaceAbility.InterfaceBusy;
import com.SERV.view.entity.Busy;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

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
                    "           ,[idEvent])" +
                    "     VALUES" +
                    "           (" +b.getIdUser()+
                    "           ," +b.getIdPoint()+
                    "           ,"+b.getIdEvent()+")");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }

    @Override
    public Busy isBusy(Busy b) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT [id]" +
                    "      ,[idUser]" +
                    "      ,[idPoint]" +
                    "      ,[idEvent]" +
                    "  FROM [SOPG].[dbo].[busy] " +
                    "  WHERE [idUser]=" +b.getIdUser()+
                    "      AND [idEvent]=" +b.getIdEvent());
            Busy busy = new Busy();
            while (result.next()) {
                busy = new Busy(result.getInt("id"), result.getInt("idUser"), result.getInt("idPoint"), result.getInt("idEvent"));
                break;
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return busy;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    @Override
    public void delBusy(Busy b) {
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            statement.execute("DELETE FROM [SOPG].[dbo].[busy]" +
                    "      WHERE idPoint="+b.getIdPoint()+";");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
}
