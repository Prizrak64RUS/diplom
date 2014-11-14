package com.SOPG.model;


import com.SOPG.dataBase.ExtractedData;
import com.SOPG.view.essence.User;
import com.SOPG.view.essence.UserRole;

import java.util.ArrayList;
import java.util.HashMap;

 public class DataProcessing {


    public static User getUser(int id){
        ArrayList<User> users=ExtractedData.getUserList();
        for(User usr:users){
            if (id==usr.getId()){
                return usr;
            }
        }
        return new User("Therru",UserRole.HEAD,3);
    }

    public static HashMap<String,String> isUser(String login, String password) {
        ArrayList<User> users=ExtractedData.getUserList();

        HashMap<String,String> hm = new HashMap<String, String>();
            for(User usr:users){
                if (login.equals(usr.getLogin())){
                    hm.put("isUser", Boolean.toString(true));
                    return hm;
                }
            }
        hm.put("isUser", Boolean.toString(false));
        return hm;
    }

    public static HashMap<String,User> getUserRole(String role) {
        ArrayList<User> users=ExtractedData.getUserList();

        HashMap<String,User> hm = new HashMap<String, User>();
        for(User usr:users){
            if (usr.getRole().getName().equals(role)){
                hm.put("role", usr);
            }
        }
        return hm;
    }
}