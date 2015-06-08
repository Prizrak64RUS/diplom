package com.SERV.view;

import com.SERV.dataBase.ControllerConnections;
import com.SERV.interfaceAbility.InterfaceMaps;
import com.SERV.interfaceAbility.UrlController;
import com.SERV.view.entity.Event;
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
public class ControllerMaps implements InterfaceMaps{

      /*  @RequestMapping(method = RequestMethod.POST, value= "allPoint/{idMap}")
        @ResponseBody
        public List<Point> getMapData(@PathVariable int idMap) {
            return DataProcessing.getProcessingMap().getPoint(idMap);
        }*/

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapFromId_)
    @ResponseBody
    public Maps getMap(@PathVariable  int id){return ControllerConnections.getMapsController().getMap(id);}

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapFromEventAll)
    @ResponseBody
    public ArrayList<Maps> getMaps(@RequestBody Event ev) {
        return ControllerConnections.getMapsController().getMaps(ev);
    }

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapActivEventAll)
    @ResponseBody
    public ArrayList<Maps> getMapsFromActivEvent(){
        return ControllerConnections.getMapsController().getMapsFromActivEvent();
    }

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapAll)
    @ResponseBody
    public ArrayList<Maps> getMaps() {
        return ControllerConnections.getMapsController().getMaps();
    }

    @RequestMapping(method = RequestMethod.POST, consumes="application/json", produces ="application/json", value=UrlController.mapsInsert)
    @ResponseBody
    public void setMap(@RequestBody final ArrayList<Maps> map){ControllerConnections.getMapsController().setMap(map);}

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapsDelete)
    @ResponseBody
    public void delMap(@RequestBody final ArrayList<Maps> map){ControllerConnections.getMapsController().delMap(map);}

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapsUpdate)
    @ResponseBody
    public void updMap(@RequestBody final ArrayList<Maps> map){ControllerConnections.getMapsController().updMap(map);}


    public void sendMapIn(byte[] file, int id){ControllerConnections.getMapsController().sendMapIn(file, id);}

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapsSendIn)
    @ResponseBody
    public void sendMapInByte(@RequestBody final Byte[] file,@PathVariable  int id){ControllerConnections.getMapsController().sendMapIn(byteReparser(file), id);}
   // @RequestMapping(method = RequestMethod.GET, value= UrlController.mapsSendOut)
   // @ResponseBody
    public byte[] sendMapOUT(int id){return ControllerConnections.getMapsController().sendMapOUT(id);}

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapsSendOut)
    @ResponseBody
    public Byte[] sendMapOUTByte(@PathVariable int id){
        return byteParser(sendMapOUT(id));
    }

    @RequestMapping(method = RequestMethod.POST, value= UrlController.mapSize)
    @ResponseBody
    public  long mapSize(@PathVariable int id){
        return ControllerConnections.getMapsController().mapSize(id);
    }

    private Byte[] byteParser(byte[] b){
        Byte[] bb = new Byte[b.length];
        for(int i=0; i<b.length;i++){
            bb[i]=b[i];
        }
        return bb;
    }
    private byte[] byteReparser(Byte[] b){
        byte[] bb = new byte[b.length];
        for(int i=0; i<b.length;i++){
            bb[i]=b[i];
        }
        return bb;
    }
}
