package com.SERV.view;

import com.SERV.interfaceAbility.InterfaceEvent;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.model.DataProcessing;
import com.SERV.view.entity.Event;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import java.util.ArrayList;
/**
 * Created by prizrak on 16.03.2015.
 */
@Controller
@RequestMapping(UrlController.eventObj)
public class EventController implements InterfaceEvent{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.eventInsert)
    @ResponseBody
    public void setEvent(@RequestBody final ArrayList<Event> event){DataProcessing.getProcessingEvent().setEvent(event);}

    @RequestMapping(method = RequestMethod.POST, value=UrlController.eventGetActiv)
    @ResponseBody
    public Event getEventActiv(){return  DataProcessing.getProcessingEvent().getEventActiv();}

    @RequestMapping(method = RequestMethod.POST, value=UrlController.eventAll)
    @ResponseBody
    public ArrayList<Event> getEvents(){return DataProcessing.getProcessingEvent().getEvents();}
}
