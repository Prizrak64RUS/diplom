package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfacePoint;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.view.entity.Point;
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
@RequestMapping(UrlController.pointObj)
public class ControllerPoint implements InterfacePoint{

    @RequestMapping(method = RequestMethod.POST, value=UrlController.pointFromMap)
    @ResponseBody
    public ArrayList<Point> getPoints(@RequestBody final Object[] val){return ControllerConnections.getPointController().getPoints(val);}

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointUpdate)
    @ResponseBody
    public void updPoint(@RequestBody final ArrayList<Point> points){ControllerConnections.getPointController().updPoint(points);}

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointsInsert)
    @ResponseBody
    public void setPoints(@RequestBody final ArrayList<Point> points){ControllerConnections.getPointController().setPoints(points);}

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointDelete)
    @ResponseBody
    public void delPoints(@RequestBody final ArrayList<Point> points){ControllerConnections.getPointController().delPoints(points);}


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointBusyInsert)
    @ResponseBody
    public boolean setBusyPoint(@RequestBody Point point) {
        return ControllerConnections.getPointController().setBusyPoint(point);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointBusy)
    @ResponseBody
    public boolean busyPoint(@RequestBody Point point) {
        return ControllerConnections.getPointController().busyPoint(point);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointBusyDelete)
    @ResponseBody
    public boolean delBusyPoint(@RequestBody Point point) {
        return ControllerConnections.getPointController().delBusyPoint(point);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointBusyUpdate)
    @ResponseBody
    public boolean updateBusyPoint(@RequestBody Point point) {
        return ControllerConnections.getPointController().updateBusyPoint(point);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointNotBusy)
    @ResponseBody
    public boolean busyNotPoint(@RequestBody Point point) {
        return ControllerConnections.getPointController().busyNotPoint(point);
    }

    @RequestMapping(method = RequestMethod.POST, value= UrlController.pointGetPoint_)
    @ResponseBody
    public Point getPoint(@PathVariable  int id) {
        return ControllerConnections.getPointController().getPoint(id);
    }

    @RequestMapping(method = RequestMethod.POST, value= UrlController.pointSetPoint)
    @ResponseBody
    public Point setPoints(@RequestBody Point point){
        return ControllerConnections.getPointController().setPoints(point);
    }
    @RequestMapping(method = RequestMethod.POST, value= UrlController.pointDelPoint)
    @ResponseBody
    public boolean delPoints(@RequestBody Point point) {
        return  ControllerConnections.getPointController().delPoints(point);
    }


    @RequestMapping(method = RequestMethod.POST, value= UrlController.pointUpdFree_space)
    @ResponseBody
    public boolean updFree_space(@RequestBody Object[] val) {
        return ControllerConnections.getPointController().updFree_space(val);
    }
}
