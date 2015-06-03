package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceBusy;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.view.entity.Busy;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;

/**
 * Created by prizrak on 19.05.2015.
 */

@Controller
@RequestMapping(UrlController.busyObj)
public class ControllerBusy implements InterfaceBusy{


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.busyInsert)
    @ResponseBody
    public void setBusy(@RequestBody final Busy b) {
        ControllerConnections.getBusyController().setBusy(b);

    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.busyIs)
    @ResponseBody
    public Busy[] isBusy(@RequestBody final Busy b) {
        return ControllerConnections.getBusyController().isBusy(b);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.busyDel)
    @ResponseBody
    public void delBusy(@RequestBody final Busy b) {
        ControllerConnections.getBusyController().delBusy(b);
    }
}