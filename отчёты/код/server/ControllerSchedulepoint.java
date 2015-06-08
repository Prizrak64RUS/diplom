package com.SERV.view;
import com.SERV.interfaceAbility.InterfaceSchedulepoint;
import com.SERV.view.entity.Schedulepoint;
import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.UrlController;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.ArrayList;

/**
 * Created by prizrak on 02.06.2015.
 */
@Controller
@RequestMapping(UrlController.schedulepointObj)
public class ControllerSchedulepoint implements  InterfaceSchedulepoint{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointGetOne)
    @ResponseBody
    public Schedulepoint getSP(@RequestBody final Integer id) {
        return ControllerConnections.getSchedulepointController().getSP(id);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointDel)
    @ResponseBody
    public void delSchedulepoint(@RequestBody final ArrayList<Schedulepoint> arr) {
        ControllerConnections.getSchedulepointController().delSchedulepoint(arr);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointIns)
    @ResponseBody
    public void setSchedulepoint(@RequestBody final ArrayList<Schedulepoint> arr) {
        ControllerConnections.getSchedulepointController().setSchedulepoint(arr);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointUpd)
    @ResponseBody
    public void updSchedulepoint(@RequestBody final ArrayList<Schedulepoint> arr) {
        ControllerConnections.getSchedulepointController().updSchedulepoint(arr);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointGet)
    @ResponseBody
    public ArrayList<Schedulepoint> getSchedulepoint() {
        return ControllerConnections.getSchedulepointController().getSchedulepoint();
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointGetFrom)
    @ResponseBody
    public ArrayList<Schedulepoint> getSchedulepoint(@RequestBody final Integer val) {
        return ControllerConnections.getSchedulepointController().getSchedulepoint(val);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointFromTime)
    @ResponseBody
    public ArrayList<Schedulepoint> getSchedulepointFromTime(@RequestBody final  Integer val) {
        return ControllerConnections.getSchedulepointController().getSchedulepointFromTime(val);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.schedulepointOneFromTime)
    @ResponseBody
    public Schedulepoint getSchedulepointOneFromTime(@RequestBody final  Integer val) {
        return ControllerConnections.getSchedulepointController().getSchedulepointOneFromTime(val);
    }
}
