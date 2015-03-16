package com.SERV.view;

import com.SERV.interfaceAbility.InterfaceMaps;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.model.DataProcessing;
import com.SERV.view.entity.Maps;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import java.io.File;
import java.util.ArrayList;

/**
 * Created by prizrak on 25.11.2014.
 */
@Controller
@RequestMapping(UrlController.mapsObj)
public class MapsController implements InterfaceMaps{

      /*  @RequestMapping(method = RequestMethod.POST, value= "allPoint/{idMap}")
        @ResponseBody
        public List<Point> getMapData(@PathVariable int idMap) {
            return DataProcessing.getProcessingMap().getPoint(idMap);
        }*/
    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapFromEventAll)
    @ResponseBody
    public ArrayList<Maps> getMaps(@PathVariable int idEvent) {
        return DataProcessing.getProcessingMap().getMaps(idEvent);
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.mapsInsert)
    @ResponseBody
    public void setMap(@RequestBody final Maps map){DataProcessing.getProcessingMap().setMap(map);}

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapsDelete)
    @ResponseBody
    public void delMap(@PathVariable int id){DataProcessing.getProcessingMap().delMap(id);}


    public void sendMapIn(File file){}
    public File sendMapOUT(){return null;}
}
