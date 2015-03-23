package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceEvent;
import com.SERV.view.entity.Event;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public class EventController implements InterfaceEvent{
    public void setEvent(ArrayList<Event> event){
        for(Event ev: event){
            if(ev.getId()!=0) {continue;}
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                ResultSet result = statement.executeQuery("insert into SOPG.dbo.event values ('"+ev.getName()+"', '"+ev.getDescription()+"', '"+ev.getDate()+"', "
                        +((ev.getIsActiv())?1:0)+");");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
    public Event getEventActiv(){
        try {
        Connection conn =  ConnectionPool.getConnectionPool().retrieve();

        Statement statement = conn.createStatement();
        ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.event where isActiv=1;");
        while (result.next()) {
            return new Event(result.getString("name"),result.getInt("isActiv"),result.getString("description"),result.getString("date"),result.getInt("id"));
        }
        ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
        e.printStackTrace();
        }
        return null;
    }
    public ArrayList<Event> getEvents(){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.event;");
            ArrayList<Event> events = new ArrayList<Event>();
            while (result.next()) {
                Event ev =new Event(result.getString("name"),result.getInt("isActiv"),result.getString("description"),result.getString("date"),result.getInt("id"));
                events.add(ev);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return events;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }
}
