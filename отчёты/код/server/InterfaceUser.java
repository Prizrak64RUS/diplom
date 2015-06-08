package com.SERV.interfaceAbility;

import com.SERV.view.entity.User;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceUser {
    public void setUsers(ArrayList<User> user);
    public void updateUsers(ArrayList<User> user);
    public void deleteUsers(ArrayList<User> user);
    public User isAutch(User user);
    public ArrayList<User> getUsers();
    public ArrayList<User> getUsers(int idEvent);
}
