package com.SERV.view.entity;

/**
 * Created by Prizrak on 08.07.2014.
 */
public enum UserRole {
    PORTER("Porter"),
    GUIDES("Guides"),
    HEAD("Head"),
    ADMIN("Admin"),
    WATCHING("Watching"),
    NONE("None");
    private String name;
    private UserRole(String name) {
        this.name=name;
    }
    public String getName(){
        return name;
    }
    public String toString(){
        return name;
    }
}
