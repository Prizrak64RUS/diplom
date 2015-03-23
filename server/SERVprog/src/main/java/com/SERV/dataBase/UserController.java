package com.SERV.dataBase;

import com.SERV.interfaceAbility.InterfaceUser;
import com.SERV.view.entity.User;
import com.SERV.view.entity.UserRole;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 * Created by prizrak on 19.11.2014.
 */
public class UserController implements InterfaceUser {
    public User isAutch(User user){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.users where login='"+user.getLogin()+
                    "' and password='"+user.getPassword()+"';");
            user.setRole(UserRole.NONE);
            while (result.next()) {
                user.setId(result.getInt("id"));
                user.setDescription(result.getString("description"));
                user.setName(result.getString("name"));
                user.setRole(UserRole.valueOf(result.getString("role")));
            }
            ConnectionPool.getConnectionPool().putback(conn);
            return user;
        } catch (SQLException e) {
            e.printStackTrace();
        }
        return null;
    }

    public void setUsers(ArrayList<User> user){
        for(User us: user){
            if(us.getId()!=0) {continue;}
            try {
                Connection conn =  ConnectionPool.getConnectionPool().retrieve();
                Statement statement = conn.createStatement();
                ResultSet result = statement.executeQuery("insert into SOPG.dbo.users values ("+us.getGradebook()+", '"+us.getName()+"', '"+us.getRole()+"', '"+
                        us.getDescription()+"', '"+us.getLogin()+"', '"+us.getPassword()+"';");
                ConnectionPool.getConnectionPool().putback(conn);
            } catch (SQLException e) {
                e.printStackTrace();
            }
        }
    }
    public void updateUsers(ArrayList<User> user){}
    public void deleteUsers(ArrayList<User> user){}
    public ArrayList<User> getUsers(){
        try {
        Connection conn =  ConnectionPool.getConnectionPool().retrieve();

        Statement statement = conn.createStatement();
        ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.users;");
        ArrayList<User> users = new ArrayList<User>();
        while (result.next()) {
            User us =new User(result.getString("name"),result.getString("role"),result.getString("description"),result.getString("login"),result.getString("password"),
                    result.getInt("id"),result.getInt("Gradebook"));
            users.add(us);
        }
        ConnectionPool.getConnectionPool().putback(conn);
        return users;
    } catch (SQLException e) {
        e.printStackTrace();
    }
        return null;
    }
    public ArrayList<User> getUsers(int idEvent){
    try {
        Connection conn =  ConnectionPool.getConnectionPool().retrieve();

        Statement statement = conn.createStatement();
        ResultSet result = statement.executeQuery("SELECT * FROM SOPG.dbo.users WHERE id_event="+idEvent+";");
        ArrayList<User> users = new ArrayList<User>();
        while (result.next()) {
            User us =new User(result.getString("name"),result.getString("role"),result.getString("description"),result.getString("login"),result.getString("password"),
                    result.getInt("id"),result.getInt("Gradebook"));
            users.add(us);
        }
        ConnectionPool.getConnectionPool().putback(conn);
        return users;
    } catch (SQLException e) {
        e.printStackTrace();
    }
        return null;
    }
}
