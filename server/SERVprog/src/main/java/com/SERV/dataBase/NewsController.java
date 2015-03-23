package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceNews;
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
    public void setNews(News news){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();
            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("insert into SOPG.dbo.news values ("+news.getId_event()+", '"+news.getDescription()+"', "+news.getDate_write()+");");
            ConnectionPool.getConnectionPool().putback(conn);
        } catch (SQLException e) {
            e.printStackTrace();
        }
    }
    public ArrayList<News> getNewsOf(int id){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.news where id>"+id+";");
            ArrayList<News> ms = new ArrayList<News>();
            while (result.next()) {
                News m = new News(result.getInt("id"), result.getInt("id_event"), result.getString("description"), result.getString("date"));
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
            ResultSet result = statement.executeQuery("Select top(7) * from [SOPG].[dbo].[news] order by id desc;");
            ArrayList<News> ms = new ArrayList<News>();
            while (result.next()) {
                News m = new News(result.getInt("id"), result.getInt("id_event"), result.getString("description"), result.getString("date"));
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
