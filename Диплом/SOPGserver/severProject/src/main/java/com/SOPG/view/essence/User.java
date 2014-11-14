package com.SOPG.view.essence;

import com.fasterxml.jackson.annotation.JsonAutoDetect;
import com.fasterxml.jackson.databind.util.JSONPObject;
import netscape.javascript.JSObject;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class User {
    private String name;
    private UserRole role;
    private String description;
    private String login;
    private int id;

    public User(String name,UserRole role,String description, String login, int id){
        this.name=name;
        this.role=role;
        this.description=description;
        this.login=login;
        this.id=id;
    }

    public User(){}

    public User(String login,UserRole role,int id){
        this.login=login;
        this.role=role;
        this.id=id;

    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public UserRole getRole() {
        return role;
    }

    public void setRole(UserRole role) {
        this.role = role;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    @Override
    public int hashCode(){
        return id;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (getClass() != obj.getClass())
            return false;
        User other = (User) obj;
        if (!login.equals(other.getLogin()))
            return false;
        return true;
    }

    public void setId(int id) {
        this.id = id;
    }
    public int getId() {
        return id;
    }
}
