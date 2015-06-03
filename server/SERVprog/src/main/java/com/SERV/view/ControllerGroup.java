package com.SERV.view;

import com.SERV.interfaceAbility.InterfaceGroup;
import com.SERV.view.entity.Group;
import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.UrlController;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

/**
 * Created by prizrak on 29.05.2015.
 */
@Controller
@RequestMapping(UrlController.groupObj)
public class ControllerGroup implements InterfaceGroup {

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.groupInsert)
    @ResponseBody
    public boolean setGroup(@RequestBody final Group g) {
        return ControllerConnections.getGroupController().setGroup(g);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.groupUpdate)
    @ResponseBody
    public boolean updGroup(@RequestBody final Group g) {
        return ControllerConnections.getGroupController().updGroup(g);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.groupGet)
    @ResponseBody
    public Group getGroup(@RequestBody final Integer val) {
        return ControllerConnections.getGroupController().getGroup(val);
    }
}
