package com.SERV.model;


import com.SERV.dataBase.ControllerConnections;
import com.SERV.view.entity.User;
import com.SERV.view.entity.UserRole;
import com.SERV.dataBase.ControllerConnections;

import java.util.ArrayList;
import java.util.HashMap;

public class DataProcessing {
    public static ProcessingUser  getProcessingUser(){
        return new ProcessingUser();
    }
    public static ProcessingMap  getProcessingMap(){
        return new ProcessingMap();
    }

}