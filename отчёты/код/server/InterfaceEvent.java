package com.SERV.interfaceAbility;

import com.SERV.view.entity.Event;

import java.util.ArrayList;

/**
 * Created by prizrak on 20.01.2015.
 */
public interface InterfaceEvent {
    public void setEvents(ArrayList<Event> event);
    public Event getEventActiv();
    public ArrayList<Event> getEvents();
    public void updEvents(ArrayList<Event> event);
}
