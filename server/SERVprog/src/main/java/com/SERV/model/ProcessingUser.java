package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.view.entity.User;

import java.util.HashMap;

/**
 * Created by prizrak on 25.11.2014.
 */
public class ProcessingUser {
    public static User getUser(int id){

        return new User("Therru","sdfsdf");
    }

    public static HashMap<String,String> isUser(String login, String password) {
        HashMap<String,String> hm = new HashMap<String, String>();
        hm.put("isUser", Boolean.toString(false));
        return hm;
    }

    public static HashMap<String,User> getUserRole(String role) {

        HashMap<String,User> hm = new HashMap<String, User>();
        return hm;
    }

    public User authentication(User user){

        User usr_tmp = ControllerConnections.getUserController().isAuthentication(user.getLogin(),user.getPassword());

        return usr_tmp;
    }
}
