package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceEvent;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.view.entity.Event;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import java.util.ArrayList;
/**
 * Created by prizrak on 16.03.2015.
 */
@Controller
@RequestMapping(UrlController.eventObj)
public class ControllerEvent implements InterfaceEvent{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.eventInsert)
    @ResponseBody
    public void setEvents(@RequestBody final ArrayList<Event> event){
        ControllerConnections.getEventController().setEvents(event);}

    @RequestMapping(method = RequestMethod.POST, value=UrlController.eventGetActiv)
    @ResponseBody
    public Event getEventActiv(){return  ControllerConnections.getEventController().getEventActiv();}

    @RequestMapping(method = RequestMethod.POST, value=UrlController.eventAll)
    @ResponseBody
    public ArrayList<Event> getEvents(){return ControllerConnections.getEventController().getEvents();}

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.eventUpd)
    @ResponseBody
    public void updEvents(@RequestBody final ArrayList<Event> event){ControllerConnections.getEventController().updEvents(event);}
}
