package com.SERV.dataBase;

import com.SERV.view.essence.User;
import com.SERV.view.essence.UserRole;

import java.util.ArrayList;

/**
 * Created by Prizrak on 09.07.2014.
 */
public class ExtractedData {
    public static final ArrayList<User> users = new ArrayList<User>();
    //public static final Map<Integer, User> characters = new HashMap<Integer, User>();

    static {
        users.add(new User("Totoro", UserRole.ADMIN, 1));
        users.add(new User("Satsuki Kusakabe",UserRole.GUIDES,2));
        users.add(new User("Therru",UserRole.HEAD,3));
    }

    public static ArrayList<User> getUserList() {
        return users;
    }
}
