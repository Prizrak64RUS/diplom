package com.SERV.view;
import com.SERV.interfaceAbility.InterfaceMasterclass;
import com.SERV.view.entity.Masterclass;
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
@RequestMapping(UrlController.masterclassObj)
public class ControllerMasterclass implements  InterfaceMasterclass{

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.masterclassGetFrom)
    @ResponseBody
    public ArrayList<Masterclass> getMasterclass(@RequestBody final Integer val) {
        return ControllerConnections.getMasterclassController().getMasterclass(val);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.masterclassGet)
    @ResponseBody
    public ArrayList<Masterclass> getMasterclass() {
        return ControllerConnections.getMasterclassController().getMasterclass();
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.masterclassUpd)
    @ResponseBody
    public void updMasterclass(@RequestBody final ArrayList<Masterclass> arr) {
        ControllerConnections.getMasterclassController().updMasterclass(arr);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.masterclassIns)
    @ResponseBody
    public void setMasterclass(@RequestBody final ArrayList<Masterclass> arr) {
        ControllerConnections.getMasterclassController().setMasterclass(arr);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.masterclassDel)
    @ResponseBody
    public void delMasterclass(@RequestBody final ArrayList<Masterclass> arr) {
        ControllerConnections.getMasterclassController().delMasterclass(arr);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.masterclassGetOne)
    @ResponseBody
    public Masterclass getMC(@RequestBody final Integer id) {
        return ControllerConnections.getMasterclassController().getMC(id);
    }
}
