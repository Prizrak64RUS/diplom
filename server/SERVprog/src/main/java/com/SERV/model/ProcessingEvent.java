package com.SERV.model;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceEvent;
import com.SERV.view.entity.Event;

import java.util.ArrayList;

/**
 * Created by prizrak on 16.03.2015.
 */
public class ProcessingEvent implements InterfaceEvent{
    public void setEvent(ArrayList<Event> event){
        ControllerConnections.getEventController().setEvent(event);}

    public Event getEventActiv(){return ControllerConnections.getEventController().getEventActiv();}

    public ArrayList<Event> getEvents(){return ControllerConnections.getEventController().getEvents();}
}