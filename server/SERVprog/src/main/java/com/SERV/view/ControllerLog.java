package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.view.entity.Log;
import com.SERV.interfaceAbility.InterfaceLog;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.view.entity.Log;
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
@RequestMapping(UrlController.logObj)
public class ControllerLog{// implements InterfaceLog{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.logInsert)
    @ResponseBody
    public void setLog(Log log){}

    @RequestMapping(method = RequestMethod.POST, value = UrlController.logGetTreeLog)
    @ResponseBody
    public ArrayList<Log> getTreeLogs(@PathVariable int idEvent){ return ControllerConnections.getLogController().getTreeLogs(idEvent);}

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.logGetTreeLogByType)
    @ResponseBody
    public ArrayList<Log> getTreeLogs(@RequestBody final ArrayList<Integer> in){
        return getTreeLogs(in.get(0), in.get(1));
    }
    public ArrayList<Log> getTreeLogs(int idEvent, int type){
        return ControllerConnections.getLogController().getTreeLogs(idEvent, type);
    }
}
