package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceNews;
import com.SERV.view.entity.Event;
import com.SERV.view.entity.News;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;

/**
 * Created by prizrak on 20.01.2015.
 */

public class NewsController implements InterfaceNews{

    public static Integer event;
    static Integer getActivEvent(){
        return  new EventController().getEventActiv().getId();
    }

    public void setNews(News news){
        try {
            if(news.getDate_write().equals("-")) news.setDate_write("GETDATE()");
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            statement.execute("insert into SOPG.dbo.news (id_event, description, date_write) values ("+news.getId_event()+", '"+news.getDescription()+"', GETDATE());");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public ArrayList<News> getNewsOf(int id){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.news where id>"+id+" AND id_event="+getActivEvent()+";");
            ArrayList<News> ms = new ArrayList<News>();
            while (result.next()) {
                News m = new News(result.getInt("id"), result.getInt("id_event"), result.getString("description"), result.getString("date_write"));
                ms.add(m);
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return ms;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }


    public ArrayList<News> getEndSevenNews(){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("Select top(7) * from [SOPG].[dbo].[news]  where id_event="+getActivEvent()+" order by id desc;");
            ArrayList<News> ms = new ArrayList<News>();
            while (result.next()) {
                News m = new News(result.getInt("id"), result.getInt("id_event"), result.getString("description"), result.getString("date_write"));
                ms.add(m);
            }

            Comparator<News> byId = new Comparator<News>() {
                public int compare(News left, News right) {
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
