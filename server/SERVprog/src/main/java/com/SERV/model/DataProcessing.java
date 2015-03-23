package com.SERV.model;


import com.SERV.interfaceAbility.*;

public class DataProcessing {
    public static InterfaceUser getProcessingUser(){
        return new ProcessingUser();
    }
    public static InterfaceMaps  getProcessingMap(){
        return new ProcessingMap();
    }
    public static InterfaceLog getProcessingLog(){
        return new ProcessingLog();
    }
    public static InterfaceChat  getProcessingChat(){
        return new ProcessingChat();
    }
    public static InterfaceEvent getProcessingEvent(){
        return new ProcessingEvent();
    }
    public static InterfacePoint  getProcessingPoint(){
        return new ProcessingPoint();
    }
    public static InterfaceNews getProcessingNews() {return new ProcessingNews();}

}