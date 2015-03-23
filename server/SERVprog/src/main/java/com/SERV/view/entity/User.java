package com.SERV.view.entity;

import com.fasterxml.jackson.annotation.JsonAutoDetect;

import java.io.Serializable;

/**
 * Created by Prizrak on 08.07.2014.
 */
@JsonAutoDetect
public class User implements Serializable{
    private String name;
    private UserRole role;
    private String description;
    private String password;
    private String login;
    private int id;
    private int gradebook;

    public User(String name,UserRole role,String description, String login, String password, int id, int gradebook){
        this.name=name;
        this.role=role;
        this.description=description;
        this.login=login;
        this.password=password;
        this.id=id;
        this.gradebook=gradebook;
    }

    public User(String name,String role,String description, String login, String password, int id, int gradebook){
        this.name=name;
        this.role=UserRole.valueOf(role);
        this.description=description;
        this.login=login;
        this.password=password;
        this.id=id;
        this.gradebook=gradebook;
    }

    public User(){}

    public User(String login,String password){
        this.login=login;
        this.password=password;

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

    public String getPassword() {
        return password;
    }
    public void setPassword(String password) {
        this.password = password;
    }

    public void setGradebook(int gradebook) {
        this.gradebook = gradebook;
    }
    public int getGradebook() {
        return gradebook;
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
