package com.SERV.dataBase;

import com.SERV.view.entity.User;
import com.SERV.view.entity.UserRole;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

/**
 * Created by prizrak on 19.11.2014.
 */
public class UserController {
    public User isAuthentication(String login,String password){
        try {
            Connection conn =  ConnectionPool.getConnectionPool().retrieve();

            Statement statement = conn.createStatement();
            ResultSet result = statement.executeQuery("SELECT * FROM users where login='"+login+
                    "' and password='"+password+"';");
            User user=new User();
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
}
