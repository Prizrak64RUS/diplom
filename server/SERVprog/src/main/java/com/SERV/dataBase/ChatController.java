package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceChat;
import com.SERV.view.entity.Message;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.Comparator;

/**
 * Created by prizrak on 20.01.2015.
 */
public class ChatController implements InterfaceChat{
    public void setChatMessage(Message ms){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("insert into SOPG.dbo.message values ("+ms.getIdUserTo()+", '"+ms.getMessage()+"', "+ms.getIdUser()+", GETDATE())");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public ArrayList<Message> getChatOf(int id){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.message where id>"+id+";");
            ArrayList<Message> ms = new ArrayList<Message>();
            while (result.next()) {
                Message m = new Message(result.getInt("id"), result.getString("message"), result.getInt("idUser"), result.getInt("idUserTo"), result.getString("Date"));
                ms.add(m);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return ms;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }


    public ArrayList<Message> getEndSevenMessage(){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("Select top(7) * from [SOPG].[dbo].[message] order by id desc;");
            ArrayList<Message> ms = new ArrayList<Message>();
            while (result.next()) {
                Message m = new Message(result.getInt("id"), result.getString("message"), result.getInt("idUser"), result.getInt("idUserTo"), result.getString("Date"));
                ms.add(m);
            }

            Comparator<Message> byId = new Comparator<Message>() {
                public int compare(Message left, Message right) {
                    if (left.getId()<right.getId()) {
                        return -1;
                    } else {
                        return 1;
                    }
                }
            };
            Collections.sort(ms,byId);
            ConnectionPool.getConnectionPool().putback(conn);
            return ms;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}
