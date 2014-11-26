package com.SERV.view;

import com.SERV.model.DataProcessing;
import com.SERV.view.entity.Maps;
import com.SERV.view.entity.Point;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

/**
 * Created by prizrak on 25.11.2014.
 */
@Controller
@RequestMapping("/maps/")
public class MapsController {

        @RequestMapping(value= "allPoint/{idMap}")
        @ResponseBody
        public List<Point> getMapData(@PathVariable int idMap) {
            return DataProcessing.getProcessingMap().getPoint(idMap);
        }

        @RequestMapping(value= "allMap/{idEvent}")
        @ResponseBody
        public List<Maps> getMaps(@PathVariable int idEvent) {
        return DataProcessing.getProcessingMap().getAllMaps(idEvent);
    }
}
