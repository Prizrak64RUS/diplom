package com.SERV.view;

import com.SERV.interfaceAbility.InterfacePoint;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.model.DataProcessing;
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
    public ArrayList<Point> getPoints(@PathVariable int idMap){return DataProcessing.getProcessingPoint().getPoints(idMap);}


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointUpdate)
    @ResponseBody
    public void updPoint(@RequestBody final ArrayList<Point> points){DataProcessing.getProcessingPoint().updPoint(points);}


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointsInsert)
    @ResponseBody
    public void setPoints(@RequestBody final ArrayList<Point> points){DataProcessing.getProcessingPoint().setPoints(points);}


    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.pointDelete)
    @ResponseBody
    public void delPoints(@RequestBody final Integer[] ids){DataProcessing.getProcessingPoint().delPoints(ids);}
}
