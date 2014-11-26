package com.SERV.dataBase;


import javax.naming.Context;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;
import java.sql.*;

/**
 * Created by prizrak on 18.11.2014.
 */
public class ControllerConnections {
  /*  public Connection getConnection() throws Exception{
        Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
        InitialContext initContext = new InitialContext();
        Context initCtx  = (Context) initContext.lookup("java:/comp/env");
        DataSource ds = (DataSource) initCtx.lookup("jdbc/MyDB");
        Connection conn = ds.getConnection();

        //String connectionUrl = "jdbc:sqlserver://localhost:1433;databaseName=SOPG;user=sopg;password=sopg;";
        //Connection conn = DriverManager.getConnection(connectionUrl);
        Statement statement = conn.createStatement();
        ResultSet result1 = statement.executeQuery("SELECT * FROM event;");
        while (result1.next()) {
            System.out.println("Номер в выборке #" + result1.getRow()
                            + "\t Номер в базе #" + result1.getInt("id")
                            + "\t" + result1.getString("name"));
        }

        System.out.print("NOOOOOOOOOOOOOOOOOOO");
        return null;
    }*/

    public static UserController getUserController(){
        return new UserController();
    }

    public static MapsController getMapsController(){
        return new MapsController();
    }
}
