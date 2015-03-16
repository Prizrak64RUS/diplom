package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceUser;
import com.SERV.view.entity.User;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by prizrak on 25.11.2014.
 */
public class ProcessingUser  implements InterfaceUser {

    public User isAutch(User user){return ControllerConnections.getUserController().isAutch(user);}

    public void setUsers(ArrayList<User> user){ControllerConnections.getUserController().setUsers(user);}

    public void updateUsers(ArrayList<User> user){ControllerConnections.getUserController().updateUsers(user);}

    public void deleteUsers(ArrayList<User> user){ControllerConnections.getUserController().deleteUsers(user);}

    public ArrayList<User> getUsers(){return ControllerConnections.getUserController().getUsers();}
    public ArrayList<User> getUsers(int idEvent){return ControllerConnections.getUserController().getUsers(idEvent);}
}
