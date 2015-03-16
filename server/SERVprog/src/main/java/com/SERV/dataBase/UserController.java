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
            ResultSet result = statement.executeQuery("SELECT * FROM users where login='"+user.getLogin()+
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

    public void setUsers(ArrayList<User> user){}
    public void updateUsers(ArrayList<User> user){}
    public void deleteUsers(ArrayList<User> user){}
    public ArrayList<User> getUsers(){return  null;}
    public ArrayList<User> getUsers(int idEvent){return  null;}
}
